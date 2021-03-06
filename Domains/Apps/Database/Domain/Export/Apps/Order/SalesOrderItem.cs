using System.Linq;

namespace Allors.Domain
{
    using System;
    using System.Collections.Generic;

    using Meta;
    using Resources;

    public partial class SalesOrderItem
    {
        public static readonly TransitionalConfiguration[] StaticTransitionalConfigurations =
        {
            new TransitionalConfiguration(M.SalesOrderItem, M.SalesOrderItem.SalesOrderItemState),
            new TransitionalConfiguration(M.SalesOrderItem, M.SalesOrderItem.SalesOrderItemShipmentState),
            new TransitionalConfiguration(M.SalesOrderItem, M.SalesOrderItem.SalesOrderItemInvoiceState),
            new TransitionalConfiguration(M.SalesOrderItem, M.SalesOrderItem.SalesOrderItemPaymentState),
        };

        public TransitionalConfiguration[] TransitionalConfigurations => StaticTransitionalConfigurations;

        public decimal PriceAdjustment => this.TotalSurcharge - this.TotalDiscount;

        public decimal PriceAdjustmentAsPercentage => Math.Round(((this.TotalSurcharge - this.TotalDiscount) / this.TotalBasePrice) * 100, 2);

        public Part Part
        {
            get
            {
                if (this.ExistProduct)
                {
                    var nonUnifiedGood = this.Product as NonUnifiedGood;
                    var unifiedGood = this.Product as UnifiedGood;
                    return unifiedGood ?? nonUnifiedGood?.Part;
                }

                return null;
            }
        }

        public Party ItemDifferentShippingParty
        {
            get
            {
                if (this.ExistAssignedShipToParty && !this.SalesOrderWhereSalesOrderItem.ShipToCustomer.Equals(this.AssignedShipToParty))
                {
                    return this.AssignedShipToParty;
                }

                return null;
            }
        }

        public PostalAddress ItemDifferentShippingAddress
        {
            get
            {
                if (this.ExistAssignedShipToAddress && !this.SalesOrderWhereSalesOrderItem.ShipToAddress.Equals(this.AssignedShipToAddress))
                {
                    return this.AssignedShipToAddress;
                }

                return null;
            }
        }

        public bool IsValid
        {
            get
            {
                if (this.SalesOrderItemState.Equals(new SalesOrderItemStates(this.Strategy.Session).Cancelled) ||
                    this.SalesOrderItemState.Equals(new SalesOrderItemStates(this.Strategy.Session).Rejected) ||
                    (this.IsSubTotalItem && this.QuantityOrdered == 0) ||
                    (!this.IsSubTotalItem && this.ActualUnitPrice == 0) ||
                    !this.ExistShipToAddress || !this.ExistShipToParty ||
                    (this.ExistCalculatedUnitPrice && this.CalculatedUnitPrice == 0))
                {
                    return false;
                }

                return true;
            }
        }

        public void SetActualDiscountAmount(decimal amount)
        {
            if (!this.ExistDiscountAdjustment)
            {
                this.DiscountAdjustment = new DiscountAdjustmentBuilder(this.Strategy.Session).Build();
            }

            this.DiscountAdjustment.Amount = amount;
            this.DiscountAdjustment.RemovePercentage();
        }

        public void SetActualDiscountPercentage(decimal percentage)
        {
            if (!this.ExistDiscountAdjustment)
            {
                this.DiscountAdjustment = new DiscountAdjustmentBuilder(this.Strategy.Session).Build();
            }

            this.DiscountAdjustment.Percentage = percentage;
            this.DiscountAdjustment.RemoveAmount();
        }

        public void AppsOnBuild(ObjectOnBuild method)
        {
            if (!this.ExistSalesOrderItemState)
            {
                this.SalesOrderItemState = new SalesOrderItemStates(this.Strategy.Session).Created;
            }

            if (this.ExistProduct && !this.ExistInvoiceItemType)
            {
                this.InvoiceItemType = new InvoiceItemTypes(this.Strategy.Session).ProductItem;
            }
        }

        public void AppsOnPreDerive(ObjectOnPreDerive method)
        {
            var derivation = method.Derivation;

            if (this.ExistSalesOrderWhereSalesOrderItem)
            {
                derivation.AddDependency(this.SalesOrderWhereSalesOrderItem, this);
            }
        }

        public void AppsOnDerive(ObjectOnDerive method)
        {
            var derivation = method.Derivation;

            foreach (SalesOrderItem featureItem in this.OrderedWithFeatures)
            {
                featureItem.OnDerive(x => x.WithDerivation(derivation));
            }

            if (this.ExistPreviousProduct && !this.PreviousProduct.Equals(this.Product))
            {
                derivation.Validation.AddError(this, M.SalesOrderItem.Product, ErrorMessages.SalesOrderItemProductChangeNotAllowed);
            }
            else
            {
                this.PreviousProduct = this.Product;
            }

            if (this.ExistSalesOrderItemWhereOrderedWithFeature && !this.ExistProductFeature)
            {
                derivation.Validation.AssertExists(this, M.SalesOrderItem.ProductFeature);
            }

            if (this.ExistProduct && this.ExistQuantityOrdered && this.QuantityOrdered < this.QuantityShipped)
            {
                derivation.Validation.AddError(this, M.SalesOrderItem.QuantityOrdered, ErrorMessages.SalesOrderItemLessThanAlreadeyShipped);
            }

            if (!this.ExistAssignedShipToAddress && this.ExistAssignedShipToParty)
            {
                this.AssignedShipToAddress = this.AssignedShipToParty.ShippingAddress;
            }

            derivation.Validation.AssertExistsAtMostOne(this, M.SalesOrderItem.Product, M.SalesOrderItem.ProductFeature);
            derivation.Validation.AssertExistsAtMostOne(this, M.SalesOrderItem.SerialisedItem, M.SalesOrderItem.ProductFeature);
            derivation.Validation.AssertExistsAtMostOne(this, M.SalesOrderItem.ReservedFromSerialisedInventoryItem, M.SalesOrderItem.ReservedFromNonSerialisedInventoryItem);
            derivation.Validation.AssertExistsAtMostOne(this, M.SalesOrderItem.ActualUnitPrice, M.SalesOrderItem.DiscountAdjustment, M.SalesOrderItem.SurchargeAdjustment);
            derivation.Validation.AssertExistsAtMostOne(this, M.SalesOrderItem.RequiredMarkupPercentage, M.SalesOrderItem.RequiredProfitMargin, M.SalesOrderItem.DiscountAdjustment, M.SalesOrderItem.SurchargeAdjustment);

            this.AppsOnDeriveVatRegime(derivation);
            this.AppsOnDerivePrices(derivation, 0, 0);
            this.AppsOnDeriveDeliveryDate(derivation);
            this.AppsOnDeriveShipTo(derivation);
            this.AppsOnDeriveIsValidOrderItem(derivation);
            this.AppsOnDeriveReservedFromInventoryItem(derivation);

            if (this.ExistQuantityShipNow && this.QuantityShipNow != 0)
            {
                this.AppsShipNow(derivation);

                if (this.ExistReservedFromNonSerialisedInventoryItem)
                {
                    this.ReservedFromNonSerialisedInventoryItem.OnDerive(x => x.WithDerivation(derivation));
                }

                this.SalesOrderWhereSalesOrderItem.OnDerive(x => x.WithDerivation(derivation));
            }

            if (derivation.IsCreated(this) && this.ExistSerialisedItem)
            {
                this.Details = this.SerialisedItem.Details;
            }

            this.AppsOnDeriveCurrentObjectState(derivation);
        }

        public void AppsOnPostDerive(ObjectOnPostDerive method)
        {
            if (this.ExistSalesOrderItemInvoiceState && this.SalesOrderItemInvoiceState.Equals(new SalesOrderItemInvoiceStates(this.Strategy.Session).Invoiced))
            {
                this.AddDeniedPermission(new Permissions(this.strategy.Session).Get(this.Meta.Class, this.Meta.QuantityOrdered, Operations.Write));
                this.AddDeniedPermission(new Permissions(this.strategy.Session).Get(this.Meta.Class, this.Meta.ActualUnitPrice, Operations.Write));
                this.AddDeniedPermission(new Permissions(this.strategy.Session).Get(this.Meta.Class, this.Meta.InvoiceItemType, Operations.Write));
                this.AddDeniedPermission(new Permissions(this.strategy.Session).Get(this.Meta.Class, this.Meta.Product, Operations.Write));
            }
        }

        public void AppsOnDeriveIsValidOrderItem(IDerivation derivation)
        {
            if (this.ExistSalesOrderWhereSalesOrderItem)
            {
                this.SalesOrderWhereSalesOrderItem.RemoveValidOrderItem(this);

                if (this.IsValid)
                {
                    this.SalesOrderWhereSalesOrderItem.AddValidOrderItem(this);
                }
            }
        }

        public void AppsOnDeriveCurrentObjectState(IDerivation derivation)
        {
            if (this.ExistOrderWhereValidOrderItem)
            {
                var order = this.SalesOrderWhereSalesOrderItem;

                if (order.SalesOrderState.Equals(new SalesOrderStates(this.Strategy.Session).InProcess))
                {
                    if (this.SalesOrderItemState.Equals(new SalesOrderItemStates(this.Strategy.Session).Created))
                    {
                        this.Confirm();
                    }
                }

                if (order.SalesOrderState.Equals(new SalesOrderStates(this.Strategy.Session).Finished))
                {
                    this.SalesOrderItemState = new SalesOrderItemStates(this.Strategy.Session).Finished;
                }

                if (order.SalesOrderState.Equals(new SalesOrderStates(this.Strategy.Session).Cancelled))
                {
                    this.Cancel();
                }

                if (order.SalesOrderState.Equals(new SalesOrderStates(this.Strategy.Session).Rejected))
                {
                    this.Reject();
                }
            }

            if (this.SalesOrderItemState.Equals(new SalesOrderItemStates(this.Strategy.Session).InProcess)
                && (!this.ExistSalesOrderItemShipmentState || !this.SalesOrderItemShipmentState.Equals(new SalesOrderItemShipmentStates(this.Strategy.Session).Shipped)))
            {
                if (this.ExistReservedFromNonSerialisedInventoryItem)
                {
                    this.AppsOnDeriveQuantities(derivation);

                    this.PreviousQuantity = this.QuantityOrdered;
                    this.PreviousReservedFromNonSerialisedInventoryItem = this.ReservedFromNonSerialisedInventoryItem;
                    this.PreviousProduct = this.Product;
                }

                if (this.ExistReservedFromSerialisedInventoryItem)
                {
                    this.ReservedFromSerialisedInventoryItem.SerialisedInventoryItemState = new SerialisedInventoryItemStates(this.strategy.Session).Assigned;
                    this.QuantityReserved = 1;
                    this.QuantityRequestsShipping = 1;
                }
            }

            if (this.SalesOrderItemState.Equals(new SalesOrderItemStates(this.Strategy.Session).Cancelled) ||
                this.SalesOrderItemState.Equals(new SalesOrderItemStates(this.Strategy.Session).Rejected))
            {
                if (this.ExistReservedFromNonSerialisedInventoryItem)
                {
                    this.AppsOnDeriveQuantities(derivation);
                }

                if (this.ExistReservedFromSerialisedInventoryItem)
                {
                    this.ReservedFromSerialisedInventoryItem.SerialisedInventoryItemState = new SerialisedInventoryItemStates(this.strategy.Session).Available;
                }
            }
        }

        public void AppsCancel(OrderItemCancel method)
        {
            this.SalesOrderItemState = new SalesOrderItemStates(this.Strategy.Session).Cancelled;
        }

        public void AppsConfirm(OrderItemConfirm method)
        {
            this.SalesOrderItemState = new SalesOrderItemStates(this.Strategy.Session).InProcess;
        }

        public void AppsReject(OrderItemReject method)
        {
            this.SalesOrderItemState = new SalesOrderItemStates(this.Strategy.Session).Rejected;
        }

        public void AppsApprove(OrderItemApprove method)
        {
            this.SalesOrderItemState = new SalesOrderItemStates(this.Strategy.Session).InProcess;
        }

        public void AppsContinue(SalesOrderItemContinue method)
        {
            this.SalesOrderItemState = new SalesOrderItemStates(this.Strategy.Session).InProcess;
        }

        public void AppsOnDeriveDeliveryDate(IDerivation derivation)
        {
            if (this.AssignedDeliveryDate.HasValue)
            {
                this.DeliveryDate = this.AssignedDeliveryDate.Value;
            }
            else if (this.ExistSalesOrderWhereSalesOrderItem && this.SalesOrderWhereSalesOrderItem.ExistDeliveryDate)
            {
                this.DeliveryDate = this.SalesOrderWhereSalesOrderItem.DeliveryDate;
            }
        }

        public void AppsOnDeriveShipTo(IDerivation derivation)
        {
            if (this.ExistSalesOrderWhereSalesOrderItem)
            {
                this.ShipToAddress = this.ExistAssignedShipToAddress ? this.AssignedShipToAddress : this.SalesOrderWhereSalesOrderItem.ShipToAddress;
                this.ShipToParty = this.ExistAssignedShipToParty ? this.AssignedShipToParty : this.SalesOrderWhereSalesOrderItem.ShipToCustomer;
            }
        }

        public void AppsOnDeriveReservedFromInventoryItem(IDerivation derivation)
        {
            var internalOrganisation = this.SalesOrderWhereSalesOrderItem.TakenBy;

            if (this.Part != null && internalOrganisation != null)
            {
                if (this.Part.InventoryItemKind.Equals(new InventoryItemKinds(this.strategy.Session).Serialised))
                {
                    if (this.ExistSerialisedItem)
                    {
                        if (this.SerialisedItem.ExistSerialisedInventoryItemsWhereSerialisedItem)
                        {
                            this.ReservedFromSerialisedInventoryItem = this.SerialisedItem.SerialisedInventoryItemsWhereSerialisedItem.FirstOrDefault(v => v.Quantity == 1); 
                        }
                    }
                    else
                    {
                        var inventoryItems = this.Part.InventoryItemsWherePart;
                        inventoryItems.Filter.AddEquals(M.InventoryItem.Facility, this.SalesOrderWhereSalesOrderItem.OriginFacility);
                        this.ReservedFromSerialisedInventoryItem = inventoryItems.First as SerialisedInventoryItem;
                    }
                }
                else
                {
                    var inventoryItems = this.Part.InventoryItemsWherePart;
                    inventoryItems.Filter.AddEquals(M.InventoryItem.Facility, this.SalesOrderWhereSalesOrderItem.OriginFacility);
                    this.ReservedFromNonSerialisedInventoryItem = inventoryItems.First as NonSerialisedInventoryItem;
                }
            }
        }

        public void AppsOnDeriveQuantities(IDerivation derivation)
        {
            var order = (SalesOrder)this.SalesOrderWhereSalesOrderItem;
            if (order.ScheduledManually)
            {
                this.AppsOnDeriveQuantitiesmanualShipment(derivation);
            }
            else
            {
                this.AppsOnDeriveQuantitiesAutomaticShipment(derivation);
            }
        }

        public void AppsOnDeriveQuantitiesmanualShipment(IDerivation derivation)
        {
            foreach (SalesOrderItem item in this.OrderedWithFeatures)
            {
                this.QuantityOrdered = item.QuantityOrdered;
            }

            if (this.ExistReservedFromNonSerialisedInventoryItem &&
                this.SalesOrderItemState.Equals(new SalesOrderItemStates(this.Strategy.Session).InProcess) &&
                (this.QuantityReserved > 0 || this.QuantityPendingShipment > 0))
            {
                if (this.ExistPreviousQuantity && !this.QuantityOrdered.Equals(this.PreviousQuantity))
                {
                    var diff = this.QuantityOrdered - this.PreviousQuantity;

                    if (diff < 0)
                    {
                        var leftToShip = this.PreviousQuantity - this.QuantityShipped - this.QuantityPendingShipment;
                        var shipmentCorrection = leftToShip + diff;

                        this.QuantityReserved += shipmentCorrection;

                        if (this.QuantityShortFalled > 0)
                        {
                            this.QuantityShortFalled += diff;
                            if (this.QuantityShortFalled < 0)
                            {
                                this.QuantityShortFalled = 0;
                            }
                        }

                        if (this.QuantityRequestsShipping > this.QuantityReserved)
                        {
                            this.QuantityRequestsShipping = this.QuantityReserved;
                        }

                        if (this.ExistQuantityPendingShipment && shipmentCorrection < 0)
                        {
                            this.DecreasePendingShipmentQuantity(derivation, 0 - shipmentCorrection);
                        }

                        this.ReservedFromNonSerialisedInventoryItem.OnDerive(x => x.WithDerivation(derivation));
                    }
                }

                this.PreviousQuantity = this.QuantityOrdered;
            }

            if (this.ExistReservedFromNonSerialisedInventoryItem &&
                (this.SalesOrderItemState.Equals(new SalesOrderItemStates(this.Strategy.Session).Cancelled) ||
                this.SalesOrderItemState.Equals(new SalesOrderItemStates(this.Strategy.Session).Rejected)))
            {
                if (this.ExistQuantityPendingShipment)
                {
                    this.DecreasePendingShipmentQuantity(derivation, this.QuantityPendingShipment);
                }

                this.ReservedFromNonSerialisedInventoryItem.OnDerive(x => x.WithDerivation(derivation));
            }
        }

        public void AppsOnDeriveQuantitiesAutomaticShipment(IDerivation derivation)
        {
            foreach (SalesOrderItem item in this.OrderedWithFeatures)
            {
                this.QuantityOrdered = item.QuantityOrdered;
            }

            if (this.ExistReservedFromNonSerialisedInventoryItem 
                && this.SalesOrderItemState.Equals(new SalesOrderItemStates(this.Strategy.Session).InProcess)
                && !this.ExistSalesOrderItemShipmentState)
            {
                if (this.ExistPreviousReservedFromNonSerialisedInventoryItem && !this.ReservedFromNonSerialisedInventoryItem.Equals(this.PreviousReservedFromNonSerialisedInventoryItem))
                {
                    this.PreviousReservedFromNonSerialisedInventoryItem.OnDerive(x => x.WithDerivation(derivation));

                    this.SetQuantitiesWithInventoryFirstTime(derivation);
                }
                else
                {
                    if (this.ExistPreviousQuantity && !this.QuantityOrdered.Equals(this.PreviousQuantity))
                    {
                        var diff = this.QuantityOrdered - this.PreviousQuantity;

                        if (diff > 0)
                        {
                            this.QuantityReserved += diff;

                            if (diff > this.ReservedFromNonSerialisedInventoryItem.AvailableToPromise)
                            {
                                this.QuantityRequestsShipping += this.ReservedFromNonSerialisedInventoryItem.AvailableToPromise;
                                this.QuantityShortFalled += diff - this.ReservedFromNonSerialisedInventoryItem.AvailableToPromise;
                            }
                            else
                            {
                                this.QuantityRequestsShipping += diff;
                            }
                        }
                        else
                        {
                            var leftToShip = this.PreviousQuantity - this.QuantityShipped - this.QuantityPendingShipment;

                            this.QuantityReserved += diff;

                            if (this.QuantityShortFalled > 0)
                            {
                                this.QuantityShortFalled += diff;
                                if (this.QuantityShortFalled < 0)
                                {
                                    this.QuantityShortFalled = 0;
                                }
                            }

                            if (this.QuantityRequestsShipping > this.QuantityReserved)
                            {
                                this.QuantityRequestsShipping = this.QuantityReserved;
                            }

                            var shipmentCorrection = leftToShip + diff;
                            if (this.ExistQuantityPendingShipment && shipmentCorrection < 0)
                            {
                                this.DecreasePendingShipmentQuantity(derivation, 0 - shipmentCorrection);
                            }
                        }

                        this.ReservedFromNonSerialisedInventoryItem.OnDerive(x => x.WithDerivation(derivation));
                    }

                    //// When first Confirmed.
                    if (!this.ExistPreviousQuantity)
                    {
                        this.SetQuantitiesWithInventoryFirstTime(derivation);
                    }
                }

                this.PreviousQuantity = this.QuantityOrdered;
            }

            if (this.ExistReservedFromNonSerialisedInventoryItem &&
                (this.SalesOrderItemState.Equals(new SalesOrderItemStates(this.Strategy.Session).Cancelled) ||
                this.SalesOrderItemState.Equals(new SalesOrderItemStates(this.Strategy.Session).Rejected)))
            {
                if (this.ExistQuantityPendingShipment)
                {
                    this.DecreasePendingShipmentQuantity(derivation, this.QuantityPendingShipment);
                }

                this.ReservedFromNonSerialisedInventoryItem.OnDerive(x => x.WithDerivation(derivation));
            }
        }

        private void SetQuantitiesWithInventoryFirstTime(IDerivation derivation)
        {
            this.QuantityReserved = 0;
            this.QuantityRequestsShipping = 0;
            this.QuantityShortFalled = 0;

            this.QuantityRequestsShipping = this.QuantityOrdered > this.ReservedFromNonSerialisedInventoryItem.AvailableToPromise ?
                this.ReservedFromNonSerialisedInventoryItem.AvailableToPromise : this.QuantityOrdered;

            if (this.QuantityRequestsShipping < 0)
            {
                this.QuantityRequestsShipping = 0;
            }

            this.QuantityReserved = this.QuantityOrdered;
            this.QuantityShortFalled = this.QuantityOrdered - this.QuantityRequestsShipping;

            this.ReservedFromNonSerialisedInventoryItem.OnDerive(x => x.WithDerivation(derivation));
        }

        private void DecreasePendingShipmentQuantity(IDerivation derivation, decimal diff)
        {
            var pendingShipment = this.ShipToParty.AppsGetPendingCustomerShipmentForStore(this.ShipToAddress, this.SalesOrderWhereSalesOrderItem.Store, this.SalesOrderWhereSalesOrderItem.ShipmentMethod);

            if (pendingShipment != null)
            {
                foreach (ShipmentItem shipmentItem in pendingShipment.ShipmentItems)
                {
                    foreach (OrderShipment orderShipment in shipmentItem.OrderShipmentsWhereShipmentItem)
                    {
                        if (orderShipment.OrderItem.Equals(this))
                        {
                            this.QuantityPendingShipment -= diff;
                            pendingShipment.AppsOnDeriveQuantityDecreased(derivation, shipmentItem, this, diff);
                            break;
                        }
                    }
                }
            }
        }

        public void AppsOnDeriveOrderItemState(IDerivation derivation)
        {
            if (this.ExistSalesOrderItemShipmentState && this.SalesOrderItemShipmentState.Equals(new SalesOrderItemShipmentStates(this.Strategy.Session).Shipped) &&
                this.ExistSalesOrderItemInvoiceState && this.SalesOrderItemInvoiceState.Equals(new SalesOrderItemInvoiceStates(this.Strategy.Session).Invoiced))
            {
                this.SalesOrderItemState = new SalesOrderItemStates(this.Strategy.Session).Completed;
                this.AppsOnDeriveCurrentObjectState(derivation);
            }

            if (this.ExistSalesOrderItemState && this.SalesOrderItemState.Equals(new SalesOrderItemStates(this.Strategy.Session).Completed) &&
                this.ExistSalesOrderItemPaymentState && this.SalesOrderItemPaymentState.Equals(new SalesOrderItemPaymentStates(this.Strategy.Session).Paid))
            {
                this.SalesOrderItemState = new SalesOrderItemStates(this.Strategy.Session).Finished;
                this.AppsOnDeriveCurrentObjectState(derivation);
            }
        }

        public void AppsCalculatePurchasePrice(IDerivation derivation)
        {
            this.UnitPurchasePrice = 0;

            if (this.Part != null &&
                this.Part.ExistSupplierOfferingsWherePart &&
                this.Part.SupplierOfferingsWherePart.Select(v => v.Supplier).Distinct().Count() == 1)
            {
                decimal price = 0;
                UnitOfMeasure uom = null;

                foreach (SupplierOffering supplierOffering in this.Part.SupplierOfferingsWherePart)
                {
                    if (supplierOffering.FromDate <= this.SalesOrderWhereSalesOrderItem.OrderDate &&
                        (!supplierOffering.ExistThroughDate || supplierOffering.ThroughDate >= this.SalesOrderWhereSalesOrderItem.OrderDate))
                    {
                        price = supplierOffering.Price;
                        uom = supplierOffering.UnitOfMeasure;
                    }
                }

                if (price != 0)
                {
                    this.UnitPurchasePrice = price;
                    if (uom != null && !uom.Equals(this.Product.UnitOfMeasure))
                    {
                        foreach (UnitOfMeasureConversion unitOfMeasureConversion in uom.UnitOfMeasureConversions)
                        {
                            if (unitOfMeasureConversion.ToUnitOfMeasure.Equals(this.Product.UnitOfMeasure))
                            {
                                this.UnitPurchasePrice = Math.Round(this.UnitPurchasePrice * (1 / unitOfMeasureConversion.ConversionFactor), 2);
                            }
                        }
                    }
                }
            }
        }

        public void AppsCalculateUnitPrice(IDerivation derivation)
        {
            if (this.RequiredMarkupPercentage.HasValue && this.UnitPurchasePrice > 0)
            {
                this.ActualUnitPrice = Math.Round((1 + (this.RequiredMarkupPercentage.Value / 100)) * this.UnitPurchasePrice, 2);
            }

            if (this.RequiredProfitMargin.HasValue && this.UnitPurchasePrice > 0)
            {
                this.ActualUnitPrice = Math.Round(this.UnitPurchasePrice / (1 - (this.RequiredProfitMargin.Value / 100)), 2);
            }
        }

        public void AppsOnDerivePrices(IDerivation derivation, decimal quantityOrdered, decimal totalBasePrice)
        {
            this.RemoveCurrentPriceComponents();

            this.UnitBasePrice = 0;
            this.UnitDiscount = 0;
            this.UnitSurcharge = 0;
            this.CalculatedUnitPrice = 0;
            decimal discountAdjustmentAmount = 0;
            decimal surchargeAdjustmentAmount = 0;

            var singleton = this.Strategy.Session.GetSingleton();
            var customer = this.SalesOrderWhereSalesOrderItem.BillToCustomer;
            var salesOrder = this.SalesOrderWhereSalesOrderItem;

            var priceComponents = this.GetPriceComponents();

            foreach (var priceComponent in priceComponents)
            {
                if (priceComponent.Strategy.Class.Equals(M.BasePrice.ObjectType))
                {
                    if (PriceComponents.AppsIsEligible(new PriceComponents.IsEligibleParams
                    {
                        PriceComponent = priceComponent,
                        Customer = customer,
                        Product = this.Product,
                        SalesOrder = salesOrder,
                        QuantityOrdered = quantityOrdered,
                        ValueOrdered = totalBasePrice,
                    }))
                    {
                        if (priceComponent.ExistPrice)
                        {
                            if (this.UnitBasePrice == 0 || priceComponent.Price < this.UnitBasePrice)
                            {
                                this.UnitBasePrice = priceComponent.Price ?? 0;

                                this.RemoveCurrentPriceComponents();
                                this.AddCurrentPriceComponent(priceComponent);
                            }
                        }
                    }
                }
            }

            ////SafeGuard
            if (this.ExistProduct && !this.ExistActualUnitPrice)
            {
                var invalid = true;
                foreach (BasePrice basePrice in this.CurrentPriceComponents)
                {
                    if (basePrice.Price > 0)
                    {
                        invalid = false;
                    }
                }

                if (invalid)
                {
                    this.QuantityOrdered = 0;
                }
            }

            if (!this.ExistActualUnitPrice)
            {
                var revenueBreakDiscount = 0M;
                var revenueBreakSurcharge = 0M;

                foreach (var priceComponent in priceComponents)
                {
                    if (priceComponent.Strategy.Class.Equals(M.DiscountComponent.ObjectType) || priceComponent.Strategy.Class.Equals(M.SurchargeComponent.ObjectType))
                    {
                        if (PriceComponents.AppsIsEligible(new PriceComponents.IsEligibleParams
                        {
                            PriceComponent = priceComponent,
                            Customer = customer,
                            Product = this.Product,
                            SalesOrder = salesOrder,
                            QuantityOrdered = quantityOrdered,
                            ValueOrdered = totalBasePrice,
                        }))
                        {
                            this.AddCurrentPriceComponent(priceComponent);

                            revenueBreakDiscount = this.SetUnitDiscount(priceComponent, revenueBreakDiscount);
                            revenueBreakSurcharge = this.SetUnitSurcharge(priceComponent, revenueBreakSurcharge);
                        }
                    }
                }

                var adjustmentBase = this.UnitBasePrice - this.UnitDiscount + this.UnitSurcharge;

                if (this.ExistDiscountAdjustment)
                {
                    if (this.DiscountAdjustment.Percentage.HasValue)
                    {
                        discountAdjustmentAmount = Math.Round((adjustmentBase * this.DiscountAdjustment.Percentage.Value) / 100, 2);
                    }
                    else
                    {
                        discountAdjustmentAmount = this.DiscountAdjustment.Amount ?? 0;
                    }

                    this.UnitDiscount += discountAdjustmentAmount;
                }

                if (this.ExistSurchargeAdjustment)
                {
                    if (this.SurchargeAdjustment.Percentage.HasValue)
                    {
                        surchargeAdjustmentAmount = Math.Round((adjustmentBase * this.SurchargeAdjustment.Percentage.Value) / 100, 2);
                    }
                    else
                    {
                        surchargeAdjustmentAmount = this.SurchargeAdjustment.Amount ?? 0;
                    }

                    this.UnitSurcharge += surchargeAdjustmentAmount;
                }
            }

            var price = this.ActualUnitPrice ?? this.UnitBasePrice;

            decimal vat = 0;
            if (this.ExistDerivedVatRate)
            {
                var vatRate = this.DerivedVatRate.Rate;
                var vatBase = price - this.UnitDiscount + this.UnitSurcharge;
                vat = Math.Round((vatBase * vatRate) / 100, 2);
            }

            this.UnitVat = vat;
            this.TotalBasePrice = price * this.QuantityOrdered;
            this.TotalDiscount = this.UnitDiscount * this.QuantityOrdered;
            this.TotalSurcharge = this.UnitSurcharge * this.QuantityOrdered;
            this.TotalOrderAdjustment = (0 - discountAdjustmentAmount + surchargeAdjustmentAmount) * this.QuantityOrdered;

            if (this.TotalBasePrice > 0)
            {
                this.TotalDiscountAsPercentage = Math.Round((this.TotalDiscount / this.TotalBasePrice) * 100, 2);
                this.TotalSurchargeAsPercentage = Math.Round((this.TotalSurcharge / this.TotalBasePrice) * 100, 2);
            }

            if (this.ActualUnitPrice.HasValue)
            {
                this.CalculatedUnitPrice = this.ActualUnitPrice.Value;
            }
            else
            {
                this.CalculatedUnitPrice = this.UnitBasePrice - this.UnitDiscount + this.UnitSurcharge;
            }

            this.TotalExVat = this.CalculatedUnitPrice * this.QuantityOrdered;
            this.TotalVat = this.UnitVat * this.QuantityOrdered;
            this.TotalIncVat = this.TotalExVat + this.TotalVat;

            foreach (SalesOrderItem featureItem in this.OrderedWithFeatures)
            {
                this.CalculatedUnitPrice += featureItem.CalculatedUnitPrice;
                this.TotalBasePrice += featureItem.TotalBasePrice;
                this.TotalDiscount += featureItem.TotalDiscount;
                this.TotalSurcharge += featureItem.TotalSurcharge;
                this.TotalExVat += featureItem.TotalExVat;
                this.TotalVat += featureItem.TotalVat;
                this.TotalIncVat += featureItem.TotalIncVat;
            }

            var toCurrency = this.SalesOrderWhereSalesOrderItem.Currency;
            var fromCurrency = this.SalesOrderWhereSalesOrderItem.TakenBy?.PreferredCurrency;

            if (fromCurrency != null && toCurrency != null)
            {
                if (fromCurrency != null && toCurrency != null && fromCurrency.Equals(toCurrency))
                {
                    this.TotalBasePriceCustomerCurrency = this.TotalBasePrice;
                    this.TotalDiscountCustomerCurrency = this.TotalDiscount;
                    this.TotalSurchargeCustomerCurrency = this.TotalSurcharge;
                    this.TotalExVatCustomerCurrency = this.TotalExVat;
                    this.TotalVatCustomerCurrency = this.TotalVat;
                    this.TotalIncVatCustomerCurrency = this.TotalIncVat;
                }
                else
                {
                    this.TotalBasePriceCustomerCurrency =
                        Currencies.ConvertCurrency(this.TotalBasePrice, fromCurrency, toCurrency);
                    this.TotalDiscountCustomerCurrency =
                        Currencies.ConvertCurrency(this.TotalDiscount, fromCurrency, toCurrency);
                    this.TotalSurchargeCustomerCurrency =
                        Currencies.ConvertCurrency(this.TotalSurcharge, fromCurrency, toCurrency);
                    this.TotalExVatCustomerCurrency =
                        Currencies.ConvertCurrency(this.TotalExVat, fromCurrency, toCurrency);
                    this.TotalVatCustomerCurrency = Currencies.ConvertCurrency(this.TotalVat, fromCurrency, toCurrency);
                    this.TotalIncVatCustomerCurrency =
                        Currencies.ConvertCurrency(this.TotalIncVat, fromCurrency, toCurrency);
                }
            }

            this.AppsOnDeriveMarkupAndProfitMargin(derivation);
        }

        private List<PriceComponent> GetPriceComponents()
        {
            var priceComponents = new List<PriceComponent>();

            var extent = new PriceComponents(this.strategy.Session).Extent();
            if (this.ExistProduct)
            {
                foreach (PriceComponent priceComponent in extent)
                {
                    if (priceComponent.ExistProduct && priceComponent.Product.Equals(this.Product) && !priceComponent.ExistProductFeature &&
                        priceComponent.FromDate <= this.SalesOrderWhereSalesOrderItem.OrderDate &&
                        (!priceComponent.ExistThroughDate || priceComponent.ThroughDate >= this.SalesOrderWhereSalesOrderItem.OrderDate))
                    {
                        priceComponents.Add(priceComponent);
                    }
                }

                if (priceComponents.Count == 0 && this.Product.ExistProductWhereVariant)
                {
                    extent = new PriceComponents(this.strategy.Session).Extent();
                    foreach (PriceComponent priceComponent in extent)
                    {
                        if (priceComponent.ExistProduct && priceComponent.Product.Equals(this.Product.ProductWhereVariant) && !priceComponent.ExistProductFeature &&
                            priceComponent.FromDate <= this.SalesOrderWhereSalesOrderItem.OrderDate &&
                            (!priceComponent.ExistThroughDate || priceComponent.ThroughDate >= this.SalesOrderWhereSalesOrderItem.OrderDate))
                        {
                            priceComponents.Add(priceComponent);
                        }
                    }
                }
            }

            if (this.ExistProductFeature && !this.ExistSalesOrderItemWhereOrderedWithFeature)
            {
                foreach (PriceComponent priceComponent in extent)
                {
                    if (priceComponent.ExistProductFeature && priceComponent.ProductFeature.Equals(this.ProductFeature) && !priceComponent.ExistProduct &&
                        priceComponent.FromDate <= this.SalesOrderWhereSalesOrderItem.OrderDate &&
                        (!priceComponent.ExistThroughDate || priceComponent.ThroughDate >= this.SalesOrderWhereSalesOrderItem.OrderDate))
                    {
                        priceComponents.Add(priceComponent);
                    }
                }
            }

            if (this.ExistProductFeature && this.ExistSalesOrderItemWhereOrderedWithFeature)
            {
                extent = new PriceComponents(this.strategy.Session).Extent();
                var found = false;
                foreach (PriceComponent priceComponent in extent)
                {
                    if (priceComponent.ExistProduct && priceComponent.Product.Equals(this.SalesOrderItemWhereOrderedWithFeature.Product) &&
                        priceComponent.ExistProductFeature && priceComponent.ProductFeature.Equals(this.ProductFeature) &&
                        priceComponent.FromDate <= this.SalesOrderWhereSalesOrderItem.OrderDate &&
                        (!priceComponent.ExistThroughDate || priceComponent.ThroughDate >= this.SalesOrderWhereSalesOrderItem.OrderDate))
                    {
                        found = true;
                        priceComponents.Add(priceComponent);
                    }
                }

                if (!found)
                {
                    foreach (PriceComponent priceComponent in extent)
                    {
                        if (priceComponent.ExistProductFeature && priceComponent.ProductFeature.Equals(this.ProductFeature) &&
                            priceComponent.FromDate <= this.SalesOrderWhereSalesOrderItem.OrderDate &&
                            (!priceComponent.ExistThroughDate || priceComponent.ThroughDate >= this.SalesOrderWhereSalesOrderItem.OrderDate))
                        {
                            priceComponents.Add(priceComponent);
                        }
                    }
                }
            }

            // Discounts and surcharges can be specified without product or product feature, these need te be added to collection of pricecomponents
            extent = new PriceComponents(this.strategy.Session).Extent();
            foreach (PriceComponent priceComponent in extent)
            {
                if (!priceComponent.ExistProduct && !priceComponent.ExistPart && !priceComponent.ExistProductFeature &&
                    priceComponent.FromDate <= this.SalesOrderWhereSalesOrderItem.OrderDate &&
                    (!priceComponent.ExistThroughDate || priceComponent.ThroughDate >= this.SalesOrderWhereSalesOrderItem.OrderDate))
                {
                    priceComponents.Add(priceComponent);
                }
            }

            return priceComponents;
        }

        public void AppsOnDeriveMarkupAndProfitMargin(IDerivation derivation)
        {
            this.InitialMarkupPercentage = 0;
            this.MaintainedMarkupPercentage = 0;
            this.InitialProfitMargin = 0;
            this.MaintainedProfitMargin = 0;

            ////internet wiki page on markup business
            if (this.ExistUnitPurchasePrice && this.UnitPurchasePrice != 0 && this.CalculatedUnitPrice != 0 && this.UnitBasePrice != 0)
            {
                this.InitialMarkupPercentage = Math.Round(((this.UnitBasePrice / this.UnitPurchasePrice) - 1) * 100, 2);
                this.MaintainedMarkupPercentage = Math.Round(((this.CalculatedUnitPrice / this.UnitPurchasePrice) - 1) * 100, 2);

                this.InitialProfitMargin = Math.Round(((this.UnitBasePrice - this.UnitPurchasePrice) / this.UnitBasePrice) * 100, 2);
                this.MaintainedProfitMargin = Math.Round(((this.CalculatedUnitPrice - this.UnitPurchasePrice) / this.CalculatedUnitPrice) * 100, 2);
            }
        }

        public void AppsOnDeriveOnShip(IDerivation derivation)
        {
            this.QuantityPendingShipment += this.QuantityRequestsShipping;
            this.QuantityRequestsShipping = 0;
        }

        public void AppsOnDeriveOnShipped(IDerivation derivation, decimal quantity)
        {
            this.QuantityPicked -= quantity;
            this.QuantityPendingShipment -= quantity;
            this.QuantityShipped += quantity;

            this.AppsOnDeriveShipmentState(derivation);
        }

        public void AppsOnDeriveOnPicked(IDerivation derivation, decimal quantity)
        {
            this.QuantityPicked += quantity;
            this.QuantityReserved -= quantity;
        }

        public void AppsOnDeriveAddToShipping(IDerivation derivation, decimal quantity)
        {
            this.QuantityRequestsShipping += quantity;
            this.QuantityShortFalled -= quantity;
        }

        public void AppsShipNow(IDerivation derivation)
        {
            var order = (SalesOrder)this.SalesOrderWhereSalesOrderItem;
            if (order.ScheduledManually)
            {
                var quantity = this.QuantityShipNow ?? 0;

                if (this.ExistReservedFromNonSerialisedInventoryItem && quantity > this.ReservedFromNonSerialisedInventoryItem.AvailableToPromise)
                {
                    derivation.Validation.AddError(this, M.SalesOrderItem.QuantityShipNow, ErrorMessages.SalesOrderItemQuantityToShipNowNotAvailable);
                }
                else if (quantity > this.QuantityOrdered)
                {
                    derivation.Validation.AddError(this, M.SalesOrderItem.QuantityShipNow, ErrorMessages.SalesOrderItemQuantityToShipNowIsLargerThanQuantityOrdered);
                }
                else if (quantity > this.QuantityOrdered - this.QuantityShipped - this.QuantityPendingShipment + this.QuantityReturned)
                {
                    derivation.Validation.AddError(this, M.SalesOrderItem.QuantityShipNow, ErrorMessages.SalesOrderItemQuantityToShipNowIsLargerThanQuantityRemaining);
                }
                else
                {
                    if (quantity > 0)
                    {
                        this.QuantityReserved += quantity;
                        this.QuantityRequestsShipping += quantity;
                    }
                    else
                    {
                        this.DecreasePendingShipmentQuantity(derivation, 0 - quantity);
                    }

                    this.QuantityShipNow = 0;
                }
            }
        }

        public void AppsOnDeriveSubtractFromShipping(IDerivation derivation, decimal quantity)
        {
            this.QuantityRequestsShipping -= quantity;
            if (this.QuantityRequestsShipping < 0)
            {
                this.QuantityRequestsShipping = 0;
            }

            this.QuantityShortFalled = this.QuantityOrdered - this.QuantityRequestsShipping;
        }

        public void AppsOnDeriveSalesRep(IDerivation derivation)
        {
            this.RemoveSalesReps();

            if (this.ExistProduct)
            {
                foreach (ProductCategory productCategory in this.Product.ProductCategoriesWhereAllProduct)
                {
                    this.AddSalesRep(SalesRepRelationships.SalesRep(this.ShipToParty, productCategory, this.SalesOrderWhereSalesOrderItem.OrderDate));
                }
            }

            this.AddSalesRep(SalesRepRelationships.SalesRep(this.ShipToParty, null, this.SalesOrderWhereSalesOrderItem.OrderDate));
        }

        public void AppsOnDeriveVatRegime(IDerivation derivation)
        {
            if (this.ExistSalesOrderWhereSalesOrderItem)
            {
                this.VatRegime = this.ExistAssignedVatRegime ? this.AssignedVatRegime : this.SalesOrderWhereSalesOrderItem.VatRegime;

                this.AppsOnDeriveVatRate(derivation);
            }
        }

        public void AppsOnDeriveVatRate(IDerivation derivation)
        {
            if (this.ExistVatRegime && this.VatRegime.ExistVatRate)
            {
                this.DerivedVatRate = this.VatRegime.VatRate;
            }

            if (!this.ExistDerivedVatRate && (this.ExistProduct || this.ExistProductFeature))
            {
                this.DerivedVatRate = this.ExistProduct ? this.Product.VatRate : this.ProductFeature.VatRate;
            }
        }

        public void AppsOnDerivePaymentState(IDerivation derivation)
        {
            SalesOrderItemPaymentState state = null;

            foreach (OrderItemBilling orderItemBilling in this.OrderItemBillingsWhereOrderItem)
            {
                if (orderItemBilling.InvoiceItem is SalesInvoiceItem salesInvoiceItem)
                {
                    if (salesInvoiceItem.SalesInvoiceWhereSalesInvoiceItem.SalesInvoiceState.Equals(new SalesInvoiceStates(this.Strategy.Session).Paid))
                    {
                        state = new SalesOrderItemPaymentStates(this.Strategy.Session).Paid;
                    }

                    if (salesInvoiceItem.SalesInvoiceWhereSalesInvoiceItem.SalesInvoiceState.Equals(new SalesInvoiceStates(this.Strategy.Session).PartiallyPaid))
                    {
                        state = new SalesOrderItemPaymentStates(this.Strategy.Session).PartiallyPaid;
                    }
                }
            }

            foreach (OrderShipment orderShipment in this.OrderShipmentsWhereOrderItem)
            {
                foreach (ShipmentItemBilling shipmentItemBilling in orderShipment.ShipmentItem.ShipmentItemBillingsWhereShipmentItem)
                {
                    if (shipmentItemBilling.InvoiceItem is SalesInvoiceItem salesInvoiceItem)
                    {
                        if (salesInvoiceItem.SalesInvoiceWhereSalesInvoiceItem.SalesInvoiceState.Equals(new SalesInvoiceStates(this.Strategy.Session).Paid))
                        {
                            state = new SalesOrderItemPaymentStates(this.Strategy.Session).Paid;
                        }

                        if (salesInvoiceItem.SalesInvoiceWhereSalesInvoiceItem.SalesInvoiceState.Equals(new SalesInvoiceStates(this.Strategy.Session).PartiallyPaid))
                        {
                            state = new SalesOrderItemPaymentStates(this.Strategy.Session).PartiallyPaid;
                        }
                    }
                }
            }

            if (state != null)
            {
                if (!this.ExistSalesOrderItemPaymentState || !this.SalesOrderItemPaymentState.Equals(state))
                {
                    this.SalesOrderItemPaymentState = state;
                }
            }

            this.AppsOnDeriveOrderItemState(derivation);
        }

        public void AppsOnDeriveShipmentState(IDerivation derivation)
        {
            if (this.QuantityShipped > 0)
            {
                if (this.QuantityShipped < this.QuantityOrdered)
                {
                    if (!this.ExistSalesOrderItemShipmentState || !this.SalesOrderItemShipmentState.Equals(new SalesOrderItemShipmentStates(this.Strategy.Session).PartiallyShipped))
                    {
                        this.SalesOrderItemShipmentState = new SalesOrderItemShipmentStates(this.Strategy.Session).PartiallyShipped;
                    }
                }
                else
                {
                    if (!this.ExistSalesOrderItemShipmentState || !this.SalesOrderItemShipmentState.Equals(new SalesOrderItemShipmentStates(this.Strategy.Session).Shipped))
                    {
                        this.SalesOrderItemShipmentState = new SalesOrderItemShipmentStates(this.Strategy.Session).Shipped;
                    }
                }
            }

            this.AppsOnDeriveOrderItemState(derivation);
        }

        public void AppsOnDeriveInvoiceState(IDerivation derivation)
        {
            var amountAlreadyInvoiced = this.OrderItemBillingsWhereOrderItem?.Sum(v => v.Amount);
            if (amountAlreadyInvoiced == 0)
            {
                foreach (OrderShipment orderShipment in OrderShipmentsWhereOrderItem)
                {
                    foreach (ShipmentItemBilling shipmentItemBilling in orderShipment.ShipmentItem.ShipmentItemBillingsWhereShipmentItem)
                    {
                        amountAlreadyInvoiced += shipmentItemBilling.Amount;
                    }
                }
            }

            var leftToInvoice = (this.QuantityOrdered * this.ActualUnitPrice) - amountAlreadyInvoiced;

            if (amountAlreadyInvoiced > 0 && leftToInvoice > 0)
            {
                this.SalesOrderItemInvoiceState = new SalesOrderItemInvoiceStates(this.Strategy.Session).PartiallyInvoiced;
            }

            if (amountAlreadyInvoiced > 0 && leftToInvoice <= 0)
            {
                this.SalesOrderItemInvoiceState = new SalesOrderItemInvoiceStates(this.Strategy.Session).Invoiced;
            }

            this.AppsOnDeriveOrderItemState(derivation);
        }

        private bool AppsIsSubTotalItem =>
            this.ExistInvoiceItemType &&
            (this.InvoiceItemType.Equals(new InvoiceItemTypes(this.Strategy.Session).ProductItem)
            || this.InvoiceItemType.Equals(new InvoiceItemTypes(this.Strategy.Session).PartItem));
    }
}