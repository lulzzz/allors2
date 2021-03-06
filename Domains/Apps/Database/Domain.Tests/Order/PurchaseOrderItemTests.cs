//------------------------------------------------------------------------------------------------- 
// <copyright file="PurchaseOrderItemTests.cs" company="Allors bvba">
// Copyright 2002-2009 Allors bvba.
// 
// Dual Licensed under
//   a) the General Public Licence v3 (GPL)
//   b) the Allors License
// 
// The GPL License is included in the file gpl.txt.
// The Allors License is an addendum to your contract.
// 
// Allors Platform is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// For more information visit http://www.allors.com/legal
// </copyright>
// <summary>Defines the MediaTests type.</summary>
//-------------------------------------------------------------------------------------------------

namespace Allors.Domain
{
    using System;

    using Meta;
    using Xunit;

    public class PurchaseOrderItemTests : DomainTest
    {
        private Part finishedGood;
        private SupplierOffering currentPurchasePrice;
        private PurchaseOrder order;
        private Organisation supplier;
        
        public PurchaseOrderItemTests()
        {
            var euro = new Currencies(this.Session).FindBy(M.Currency.IsoCode, "EUR");

            var mechelen = new CityBuilder(this.Session).WithName("Mechelen").Build();
            ContactMechanism takenViaContactMechanism = new PostalAddressBuilder(this.Session).WithGeographicBoundary(mechelen).WithAddress1("Haverwerf 15").Build();

            var supplierContactMechanism = new PartyContactMechanismBuilder(this.Session)
                .WithContactMechanism(takenViaContactMechanism)
                .WithUseAsDefault(true)
                .WithContactPurpose(new ContactMechanismPurposes(this.Session).BillingAddress)
                .Build();

            this.supplier = new OrganisationBuilder(this.Session).WithName("supplier").Build();
            this.supplier.AddPartyContactMechanism(supplierContactMechanism);

            new SupplierRelationshipBuilder(this.Session).WithSupplier(supplier).Build();

            var good1 = new NonUnifiedGoods(this.Session).FindBy(M.Good.Name, "good1");
            this.finishedGood = good1.Part;

            new SupplierOfferingBuilder(this.Session)
                .WithPart(this.finishedGood)
                .WithSupplier(this.supplier)
                .WithFromDate(DateTime.UtcNow.AddYears(-1))
                .WithThroughDate(DateTime.UtcNow.AddDays(-1))
                .WithCurrency(euro)
                .WithUnitOfMeasure(new UnitsOfMeasure(this.Session).Piece)
                .WithPrice(8)
                .Build();

            this.currentPurchasePrice = new SupplierOfferingBuilder(this.Session)
                .WithPart(this.finishedGood)
                .WithSupplier(this.supplier)
                .WithFromDate(DateTime.UtcNow)
                .WithThroughDate(DateTime.UtcNow.AddYears(1).AddDays(-1))
                .WithCurrency(euro)
                .WithUnitOfMeasure(new UnitsOfMeasure(this.Session).Piece)
                .WithPrice(10)
                .Build();

            new SupplierOfferingBuilder(this.Session)
                .WithPart(this.finishedGood)
                .WithSupplier(this.supplier)
                .WithFromDate(DateTime.UtcNow.AddYears(1))
                .WithCurrency(euro)
                .WithUnitOfMeasure(new UnitsOfMeasure(this.Session).Piece)
                .WithPrice(8)
                .Build();

            this.order = new PurchaseOrderBuilder(this.Session)
                .WithTakenViaSupplier(this.supplier)
                .WithBillToContactMechanism(takenViaContactMechanism)
                .WithDeliveryDate(DateTime.UtcNow)
                .WithVatRegime(new VatRegimes(this.Session).Exempt)
                .Build();

            this.Session.Derive();
            this.Session.Commit();
        }

        [Fact]
        public void GivenOrderItem_WhenDeriving_ThenRequiredRelationsMustExist()
        {
            this.InstantiateObjects(this.Session);

            var buyer = new OrganisationBuilder(this.Session).WithName("buyer").Build();
            var mechelen = new CityBuilder(this.Session).WithName("Mechelen").Build();
            var shipToContactMechanism = new PostalAddressBuilder(this.Session).WithGeographicBoundary(mechelen).WithAddress1("Haverwerf 15").Build();
            var partyContactMechanism = new PartyContactMechanismBuilder(this.Session).WithContactMechanism(shipToContactMechanism).Build();
            var part = new NonUnifiedPartBuilder(this.Session)
                .WithProductIdentification(new PartNumberBuilder(this.Session)
                    .WithIdentification("1")
                    .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Part).Build())
                .Build();
            buyer.AddPartyContactMechanism(partyContactMechanism);

            this.Session.Derive();
            this.Session.Commit();

            var builder = new PurchaseOrderItemBuilder(this.Session);
            order.AddPurchaseOrderItem(builder.Build());

            Assert.True(this.Session.Derive(false).HasErrors);

            this.Session.Rollback();

            builder.WithPart(part);
            order.AddPurchaseOrderItem(builder.Build());

            Assert.False(this.Session.Derive(false).HasErrors);
        }

        [Fact]
        public void GivenConfirmedOrderItemForGood_WhenOrderItemIsRemoved_ThenItemIsRemovedFromValidOrderItems()
        {
            this.InstantiateObjects(this.Session);

            var item = new PurchaseOrderItemBuilder(this.Session)
                .WithPart(this.finishedGood)
                .WithQuantityOrdered(3)
                .WithActualUnitPrice(5)
                .Build();

            this.order.AddPurchaseOrderItem(item);

            this.Session.Derive();

            this.order.Confirm();

            this.Session.Derive();

            Assert.Equal(1, this.order.ValidOrderItems.Count);

            item.Cancel();

            this.Session.Derive();

            Assert.Equal(0, this.order.ValidOrderItems.Count);
        }

        [Fact]
        public void GivenOrderItemForPart_WhenDerivingPrices_ThenUsePartCurrentPurchasePrice()
        {
            this.InstantiateObjects(this.Session);

            const decimal QuantityOrdered = 3;
            var item1 = new PurchaseOrderItemBuilder(this.Session).WithPart(this.finishedGood).WithQuantityOrdered(QuantityOrdered).Build();
            this.order.AddPurchaseOrderItem(item1);

            this.Session.Derive();

            Assert.Equal(this.currentPurchasePrice.Price, item1.UnitBasePrice);
            Assert.Equal(0, item1.UnitDiscount);
            Assert.Equal(0, item1.UnitSurcharge);
            Assert.Equal(this.currentPurchasePrice.Price, item1.CalculatedUnitPrice);

            Assert.Equal(this.currentPurchasePrice.Price * QuantityOrdered, item1.TotalBasePrice);
            Assert.Equal(0, item1.TotalDiscount);
            Assert.Equal(0, item1.TotalSurcharge);
            Assert.Equal(this.currentPurchasePrice.Price * QuantityOrdered, item1.TotalExVat);

            Assert.Equal(this.currentPurchasePrice.Price * QuantityOrdered, this.order.TotalBasePrice);
            Assert.Equal(0, this.order.TotalDiscount);
            Assert.Equal(0, this.order.TotalSurcharge);
            Assert.Equal(this.currentPurchasePrice.Price * QuantityOrdered, this.order.TotalExVat);
        }

        [Fact]
        public void GivenOrderItemForProduct_WhenDerivingPrices_ThenUseProductCurrentPurchasePrice()
        {
            var euro = new Currencies(this.Session).FindBy(M.Currency.IsoCode, "EUR");

            new SupplierOfferingBuilder(this.Session)
                .WithPart(this.finishedGood)
                .WithSupplier(this.supplier)
                .WithFromDate(DateTime.UtcNow.AddYears(-1))
                .WithThroughDate(DateTime.UtcNow.AddDays(-1))
                .WithCurrency(euro)
                .WithUnitOfMeasure(new UnitsOfMeasure(this.Session).Piece)
                .WithPrice(8)
                .Build();

            var currentOffer = new SupplierOfferingBuilder(this.Session)
                .WithPart(this.finishedGood)
                .WithSupplier(this.supplier)
                .WithFromDate(DateTime.UtcNow.AddMinutes(-1))
                .WithThroughDate(DateTime.UtcNow.AddYears(1).AddDays(-1))
                .WithPrice(10)
                .WithCurrency(euro)
                .WithUnitOfMeasure(new UnitsOfMeasure(this.Session).Piece)
                .Build();

            new SupplierOfferingBuilder(this.Session)
                .WithPart(this.finishedGood)
                .WithSupplier(this.supplier)
                .WithFromDate(DateTime.UtcNow.AddYears(1))
                .WithPrice(8)
                .WithCurrency(euro)
                .WithUnitOfMeasure(new UnitsOfMeasure(this.Session).Piece)
                .Build();

            this.Session.Derive();
            this.Session.Commit();

            this.InstantiateObjects(this.Session);

            const decimal QuantityOrdered = 3;
            var item1 = new PurchaseOrderItemBuilder(this.Session).WithPart(this.finishedGood).WithQuantityOrdered(QuantityOrdered).Build();
            this.order.AddPurchaseOrderItem(item1);

            this.Session.Derive();

            Assert.Equal(currentOffer.Price, item1.UnitBasePrice);
            Assert.Equal(0, item1.UnitDiscount);
            Assert.Equal(0, item1.UnitSurcharge);
            Assert.Equal(currentOffer.Price, item1.CalculatedUnitPrice);

            Assert.Equal(currentOffer.Price * QuantityOrdered, item1.TotalBasePrice);
            Assert.Equal(0, item1.TotalDiscount);
            Assert.Equal(0, item1.TotalSurcharge);
            Assert.Equal(currentOffer.Price * QuantityOrdered, item1.TotalExVat);

            Assert.Equal(currentOffer.Price * QuantityOrdered, this.order.TotalBasePrice);
            Assert.Equal(0, this.order.TotalDiscount);
            Assert.Equal(0, this.order.TotalSurcharge);
            Assert.Equal(currentOffer.Price * QuantityOrdered, this.order.TotalExVat);
        }

        [Fact]
        public void GivenOrderItemForPartWithActualPrice_WhenDerivingPrices_ThenUseActualPrice()
        {
            this.InstantiateObjects(this.Session);

            var item1 = new PurchaseOrderItemBuilder(this.Session).WithPart(this.finishedGood).WithQuantityOrdered(3).WithActualUnitPrice(15).Build();
            this.order.AddPurchaseOrderItem(item1);

            this.Session.Derive();

            Assert.Equal(15, item1.UnitBasePrice);
            Assert.Equal(0, item1.UnitDiscount);
            Assert.Equal(0, item1.UnitSurcharge);
            Assert.Equal(15, item1.CalculatedUnitPrice);
            Assert.Equal(0, item1.UnitVat);
            Assert.Equal(45, item1.TotalBasePrice);
            Assert.Equal(0, item1.TotalDiscount);
            Assert.Equal(0, item1.TotalSurcharge);
            Assert.Equal(45, item1.TotalExVat);
            Assert.Equal(0, item1.TotalVat);
            Assert.Equal(45, item1.TotalIncVat);

            Assert.Equal(45, this.order.TotalBasePrice);
            Assert.Equal(0, this.order.TotalDiscount);
            Assert.Equal(0, this.order.TotalSurcharge);
            Assert.Equal(45, this.order.TotalExVat);
            Assert.Equal(0, this.order.TotalVat);
            Assert.Equal(45, this.order.TotalIncVat);
        }

        [Fact]
        public void GivenOrderItem_WhenObjectStateIsCreated_ThenItemMayBeDeletedButNotCancelledOrRejected()
        {
            var administrator = new PersonBuilder(this.Session).WithFirstName("Koen").WithUserName("admin").Build();
            var administrators = new UserGroups(this.Session).Administrators;
            administrators.AddMember(administrator);
            
            this.Session.Derive();
            this.Session.Commit();

            this.InstantiateObjects(this.Session);

            this.SetIdentity("admin");

            var item = new PurchaseOrderItemBuilder(this.Session)
                .WithPart(this.finishedGood)
                .WithQuantityOrdered(3)
                .WithActualUnitPrice(5)
                .Build();

            this.order.AddPurchaseOrderItem(item);

            this.Session.Derive();
            this.Session.Commit();

            Assert.Equal(new PurchaseOrderItemStates(this.Session).Created, item.PurchaseOrderItemState);
            var currentUser = this.Session.GetUser();
            var acl = new AccessControlList(item, currentUser);

            Assert.True(acl.CanExecute(M.PurchaseOrderItem.Delete));
            Assert.False(acl.CanExecute(M.PurchaseOrderItem.Cancel));
            Assert.False(acl.CanExecute(M.PurchaseOrderItem.Reject));
        }

        [Fact]
        public void GivenOrderItem_WhenObjectStateIsConfirmed_ThenItemMayBeCancelledOrRejectedButNotDeleted()
        {
            var administrator = new PersonBuilder(this.Session).WithFirstName("Koen").WithUserName("admin").Build();
            var administrators = new UserGroups(this.Session).Administrators;
            administrators.AddMember(administrator);
            
            this.Session.Derive();
            this.Session.Commit();

            this.InstantiateObjects(this.Session);

            this.SetIdentity("admin");

            var item = new PurchaseOrderItemBuilder(this.Session)
                .WithPart(this.finishedGood)
                .WithQuantityOrdered(3)
                .WithActualUnitPrice(5)
                .Build();

            this.order.AddPurchaseOrderItem(item);

            this.order.Confirm();

            this.Session.Derive();
            this.Session.Commit();

            Assert.Equal(new PurchaseOrderItemStates(this.Session).InProcess, item.PurchaseOrderItemState);
            var acl = new AccessControlList(item, this.Session.GetUser());
            Assert.True(acl.CanExecute(M.PurchaseOrderItem.Cancel));
            Assert.True(acl.CanExecute(M.PurchaseOrderItem.Reject));
            Assert.False(acl.CanExecute(M.PurchaseOrderItem.Delete));
        }

        [Fact]
        public void GivenOrderItem_WhenObjectStateIsPartiallyReceived_ThenItemMayNotBeCancelledOrRejectedOrDeleted()
        {
            var administrator = new PersonBuilder(this.Session).WithFirstName("Koen").WithUserName("admin").Build();
            var administrators = new UserGroups(this.Session).Administrators;
            administrators.AddMember(administrator);
            
            this.Session.Derive();
            this.Session.Commit();

            this.InstantiateObjects(this.Session);

            this.SetIdentity("admin");

            var item = new PurchaseOrderItemBuilder(this.Session)
                .WithPart(this.finishedGood)
                .WithQuantityOrdered(20)
                .WithActualUnitPrice(5)
                .Build();

            this.order.AddPurchaseOrderItem(item);

            this.order.Confirm();

            this.Session.Derive();

            var shipment = new PurchaseShipmentBuilder(this.Session).WithShipmentMethod(new ShipmentMethods(this.Session).Ground).WithShipFromParty(this.supplier).Build();
            var shipmentItem = new ShipmentItemBuilder(this.Session).WithPart(this.finishedGood).Build();
            shipment.AddShipmentItem(shipmentItem);

            new ShipmentReceiptBuilder(this.Session)
                .WithQuantityAccepted(3)
                .WithShipmentItem(shipmentItem)
                .WithOrderItem(item)
                .Build();

            this.Session.Derive();

            shipment.AppsComplete();

            this.Session.Derive();

            Assert.Equal(new PurchaseOrderItemStates(this.Session).PartiallyReceived, item.PurchaseOrderItemState);
            var acl = new AccessControlList(item, this.Session.GetUser());
            Assert.False(acl.CanExecute(M.PurchaseOrderItem.Cancel));
            Assert.False(acl.CanExecute(M.PurchaseOrderItem.Reject));
            Assert.False(acl.CanExecute(M.PurchaseOrderItem.Delete));
        }

        [Fact]
        public void GivenOrderItem_WhenObjectStateIsCancelled_ThenItemMayNotBeCancelledOrRejectedOrDeleted()
        {
            var administrator = new PersonBuilder(this.Session).WithFirstName("Koen").WithUserName("admin").Build();
            var administrators = new UserGroups(this.Session).Administrators;
            administrators.AddMember(administrator);
            
            this.Session.Derive();           
            this.Session.Commit();

            this.InstantiateObjects(this.Session);

            this.SetIdentity("admin");

            var item = new PurchaseOrderItemBuilder(this.Session)
                .WithPart(this.finishedGood)
                .WithQuantityOrdered(3)
                .WithActualUnitPrice(5)
                .Build();

            this.order.AddPurchaseOrderItem(item);            

            this.Session.Derive();
            this.Session.Commit();

            item.Cancel();

            this.Session.Derive();

            Assert.Equal(new PurchaseOrderItemStates(this.Session).Cancelled, item.PurchaseOrderItemState);
            var acl = new AccessControlList(item, this.Session.GetUser());
            Assert.False(acl.CanExecute(M.PurchaseOrderItem.Cancel));
            Assert.False(acl.CanExecute(M.PurchaseOrderItem.Reject));
            Assert.False(acl.CanExecute(M.PurchaseOrderItem.Delete));
        }

        [Fact]
        public void GivenOrderItem_WhenObjectStateIsRejected_ThenItemMayNotBeCancelledOrRejectedOrDeleted()
        {
            var administrator = new PersonBuilder(this.Session).WithFirstName("Koen").WithUserName("admin").Build();
            var administrators = new UserGroups(this.Session).Administrators;
            administrators.AddMember(administrator);
            
            this.Session.Derive();
            this.Session.Commit();

            this.InstantiateObjects(this.Session);

            this.SetIdentity("admin");

            var item = new PurchaseOrderItemBuilder(this.Session)
                .WithPart(this.finishedGood)
                .WithQuantityOrdered(3)
                .WithActualUnitPrice(5)
                .Build();

            this.order.AddPurchaseOrderItem(item);
            
            this.Session.Derive();

            item.Reject();

            this.Session.Derive();

            Assert.Equal(new PurchaseOrderItemStates(this.Session).Rejected, item.PurchaseOrderItemState);
            var acl = new AccessControlList(item, this.Session.GetUser());
            Assert.False(acl.CanExecute(M.PurchaseOrderItem.Cancel));
            Assert.False(acl.CanExecute(M.PurchaseOrderItem.Reject));
            Assert.False(acl.CanExecute(M.PurchaseOrderItem.Delete));
        }

        [Fact]
        public void GivenOrderItem_WhenObjectStateIsCompleted_ThenItemMayNotBeCancelledOrRejectedOrDeleted()
        {
            var administrator = new PersonBuilder(this.Session).WithFirstName("Koen").WithUserName("admin").Build();
            var administrators = new UserGroups(this.Session).Administrators;
            administrators.AddMember(administrator);
            
            this.Session.Derive();
            this.Session.Commit();

            this.InstantiateObjects(this.Session);

            this.SetIdentity("admin");

            var item = new PurchaseOrderItemBuilder(this.Session)
                .WithPart(this.finishedGood)
                .WithQuantityOrdered(3)
                .WithActualUnitPrice(5)
                .Build();

            this.order.AddPurchaseOrderItem(item);
            
            this.order.Confirm();
            
            this.Session.Derive();

            var shipment = new PurchaseShipmentBuilder(this.Session).WithShipFromParty(this.supplier).WithShipmentMethod(new ShipmentMethods(this.Session).Ground).Build();
            var shipmentItem = new ShipmentItemBuilder(this.Session).WithPart(this.finishedGood).Build();
            shipment.AddShipmentItem(shipmentItem);

            new ShipmentReceiptBuilder(this.Session)
                .WithQuantityAccepted(3)
                .WithShipmentItem(shipmentItem)
                .WithOrderItem(item)
                .Build();

            this.Session.Derive();

            shipment.AppsComplete();
            
            this.Session.Derive();

            Assert.Equal(new PurchaseOrderItemStates(this.Session).Completed, item.PurchaseOrderItemState);
            var acl = new AccessControlList(item, this.Session.GetUser());
            Assert.False(acl.CanExecute(M.PurchaseOrderItem.Cancel));
            Assert.False(acl.CanExecute(M.PurchaseOrderItem.Reject));
            Assert.False(acl.CanExecute(M.PurchaseOrderItem.Delete));
        }

        [Fact]
        public void GivenOrderItem_WhenObjectStateIsFinished_ThenItemMayNotBeCancelledOrRejectedOrDeleted()
        {
            var administrator = new PersonBuilder(this.Session).WithFirstName("Koen").WithUserName("admin").Build();
            var administrators = new UserGroups(this.Session).Administrators;
            administrators.AddMember(administrator);
            
            this.Session.Derive();
            this.Session.Commit();

            this.InstantiateObjects(this.Session);

            this.SetIdentity("admin");

            var item = new PurchaseOrderItemBuilder(this.Session)
                .WithPart(this.finishedGood)
                .WithQuantityOrdered(3)
                .WithActualUnitPrice(5)
                .Build();

            this.order.AddPurchaseOrderItem(item);

            this.Session.Derive();

            this.order.PurchaseOrderState = new PurchaseOrderStates(this.Session).Finished;
            
            this.Session.Derive();

            Assert.Equal(new PurchaseOrderItemStates(this.Session).Finished, item.PurchaseOrderItemState);
            var acl = new AccessControlList(item, this.Session.GetUser());
            Assert.False(acl.CanExecute(M.PurchaseOrderItem.Cancel));
            Assert.False(acl.CanExecute(M.PurchaseOrderItem.Reject));
            Assert.False(acl.CanExecute(M.PurchaseOrderItem.Delete));
        }

        [Fact]
        public void GivenOrderItem_WhenObjectStateIsPartiallyReceived_ThenProductChangeIsNotAllowed()
        {
            var administrator = new PersonBuilder(this.Session).WithFirstName("Koen").WithUserName("admin").Build();
            var administrators = new UserGroups(this.Session).Administrators;
            administrators.AddMember(administrator);
            
            this.Session.Derive(); 
            this.Session.Commit();

            this.InstantiateObjects(this.Session);

            this.SetIdentity("admin");

            var item = new PurchaseOrderItemBuilder(this.Session)
                .WithPart(this.finishedGood)
                .WithQuantityOrdered(3)
                .WithActualUnitPrice(5)
                .Build();

            this.order.AddPurchaseOrderItem(item);

            this.order.Confirm();
            
            this.Session.Derive();

            var shipment = new PurchaseShipmentBuilder(this.Session).WithShipmentMethod(new ShipmentMethods(this.Session).Ground).WithShipFromParty(this.supplier).Build();
            var shipmentItem = new ShipmentItemBuilder(this.Session).WithPart(this.finishedGood).Build();
            shipment.AddShipmentItem(shipmentItem);

            new ShipmentReceiptBuilder(this.Session)
                .WithQuantityAccepted(1)
                .WithShipmentItem(shipmentItem)
                .WithOrderItem(item)
                .Build();

            this.Session.Derive();

            shipment.AppsComplete();
            
            this.Session.Derive();

            Assert.Equal(new PurchaseOrderItemStates(this.Session).PartiallyReceived, item.PurchaseOrderItemState);
            var acl = new AccessControlList(item, this.Session.GetUser());
            Assert.False(acl.CanWrite(M.PurchaseOrderItem.Part));
        }

        [Fact]
        public void GivenOrderItemWithAssignedDeliveryDate_WhenDeriving_ThenDeliveryDateIsOrderItemAssignedDeliveryDate()
        {
            this.InstantiateObjects(this.Session);

            var item = new PurchaseOrderItemBuilder(this.Session)
                .WithPart(this.finishedGood)
                .WithQuantityOrdered(1)
                .WithAssignedDeliveryDate(DateTime.UtcNow.AddMonths(1))
                .Build();

            this.order.AddPurchaseOrderItem(item);
            
            this.Session.Derive();

            Assert.Equal(item.DeliveryDate, item.AssignedDeliveryDate);
        }

        [Fact]
        public void GivenOrderItemWithoutDeliveryDate_WhenDeriving_ThenDerivedDeliveryDateIsOrderDeliveryDate()
        {
            this.InstantiateObjects(this.Session);

            var item = new PurchaseOrderItemBuilder(this.Session)
                .WithPart(this.finishedGood)
                .WithQuantityOrdered(1)
                .Build();

            this.order.AddPurchaseOrderItem(item);
            
            this.Session.Derive();

            Assert.Equal(item.DeliveryDate, this.order.DeliveryDate);
        }

        private void InstantiateObjects(ISession session)
        {
            this.finishedGood = (Part)session.Instantiate(this.finishedGood);
            this.currentPurchasePrice = (SupplierOffering)session.Instantiate(this.currentPurchasePrice);
            this.order = (PurchaseOrder)session.Instantiate(this.order);
            this.supplier = (Organisation)session.Instantiate(this.supplier);
        }
    }
}
