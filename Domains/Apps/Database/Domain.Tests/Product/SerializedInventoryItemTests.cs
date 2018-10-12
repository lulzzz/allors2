//------------------------------------------------------------------------------------------------- 
// <copyright file="SerialisedInventoryItemTests.cs" company="Allors bvba">
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
    using Meta;
    using Xunit;
    using Should;
    using System.Linq;
    
    public class SerialisedInventoryItemTests : DomainTest
    {
        [Fact]
        public void GivenInventoryItem_WhenDeriving_ThenRequiredRelationsMustExist()
        {
            // Arrange
            var part = new PartBuilder(this.Session).WithName("part")
                .WithInventoryItemKind(new InventoryItemKinds(this.Session).Serialised)
                .WithPartId("1")
                .Build();

            this.Session.Derive(true);
            this.Session.Commit();

            var builder = new SerialisedInventoryItemBuilder(this.Session).WithPart(part);
            builder.Build();

            // Act
            var derivation = this.Session.Derive(false);

            // Assert
            derivation.HasErrors.ShouldBeTrue();

            // Re-arrange
            this.Session.Rollback();

            builder.WithSerialNumber("1");
            builder.Build();

            // Act
            derivation = this.Session.Derive(false);

            // Assert
            derivation.HasErrors.ShouldBeFalse();
        }

        [Fact]
        public void GivenInventoryItem_WhenBuild_ThenPostBuildRelationsMustExist()
        {
            // Arrange
            var available = new SerialisedInventoryItemStates(this.Session).Available;
            var warehouse = new Facilities(this.Session).FindBy(M.Facility.FacilityType, new FacilityTypes(this.Session).Warehouse);
            var kinds = new InventoryItemKinds(this.Session);

            var finishedGood = CreatePart("1", kinds.Serialised);
            var serializedItem = CreateSerialzedInventoryItem("1", finishedGood);

            // Act
            this.Session.Derive(true);

            // Assert
            serializedItem.SerialisedInventoryItemState.ShouldEqual(available);
            serializedItem.Facility.ShouldEqual(warehouse);
        }

        [Fact]
        public void GivenFinishedGoodWithSerializedInventory_WhenDeriving_ThenQuantityOnHandUpdated()
        {
            // Arrange
            var available = new SerialisedInventoryItemStates(this.Session).Available;
            var warehouse = new Facilities(this.Session).FindBy(M.Facility.FacilityType, new FacilityTypes(this.Session).Warehouse);

            var kinds = new InventoryItemKinds(this.Session);
            var unitsOfMeasure = new UnitsOfMeasure(this.Session);
            var unknown = new VarianceReasons(this.Session).Unknown;

            var vatRate21 = new VatRateBuilder(this.Session).WithRate(21).Build();
            var category = new ProductCategoryBuilder(this.Session).WithName("category").Build();
            var finishedGood = CreatePart("FG1", kinds.Serialised);
            var good = CreateGood("10101", vatRate21, "good1", unitsOfMeasure.Piece, category, finishedGood);
            var serialItem1 = CreateSerialzedInventoryItem("1", finishedGood);
            var serialItem2 = CreateSerialzedInventoryItem("2", finishedGood);
            var serialItem3 = CreateSerialzedInventoryItem("3", finishedGood);

            // Act
            this.Session.Derive(true);

            serialItem1.AddInventoryItemVariance(CreateInventoryVariance(1, unknown));
            serialItem2.AddInventoryItemVariance(CreateInventoryVariance(1, unknown));
            serialItem3.AddInventoryItemVariance(CreateInventoryVariance(1, unknown));

            this.Session.Derive(true);

            // Assert
            finishedGood.QuantityOnHand.ShouldEqual(3);
        }

        [Fact]
        public void GivenSerializedItemInMultipleFacilities_WhenDeriving_ThenMultipleQuantityOnHandTracked()
        {
            // Arrange
            var warehouseType = new FacilityTypes(this.Session).Warehouse;
            var warehouse1 = CreateFacility("WH1", warehouseType, this.InternalOrganisation);
            var warehouse2 = CreateFacility("WH2", warehouseType, this.InternalOrganisation);

            var serialized = new InventoryItemKinds(this.Session).Serialised;
            var piece = new UnitsOfMeasure(this.Session).Piece;
            var unknown = new VarianceReasons(this.Session).Unknown;

            var vatRate21 = new VatRateBuilder(this.Session).WithRate(21).Build();
            var category = new ProductCategoryBuilder(this.Session).WithName("category").Build();
            var finishedGood = CreatePart("FG1", serialized);
            var good = CreateGood("10101", vatRate21, "good1", piece, category, finishedGood);
            var serialItem1 = CreateSerialzedInventoryItem("1", finishedGood, warehouse1);
            var serialItem2 = CreateSerialzedInventoryItem("2", finishedGood, warehouse2);

            // Act
            this.Session.Derive(true);

            serialItem1.AddInventoryItemVariance(CreateInventoryVariance(1, unknown));
            serialItem2.AddInventoryItemVariance(CreateInventoryVariance(1, unknown));

            this.Session.Derive(true);

            // Assert
            var item1 = (SerialisedInventoryItem)new InventoryItems(this.Session).Extent().First(i => i.Facility.Equals(warehouse1));
            item1.QuantityOnHand.ShouldEqual(1);

            var item2 = (SerialisedInventoryItem)new InventoryItems(this.Session).Extent().First(i => i.Facility.Equals(warehouse2));
            item2.QuantityOnHand.ShouldEqual(1);

            finishedGood.QuantityOnHand.ShouldEqual(2);
        }

        private Facility CreateFacility(string name, FacilityType type, InternalOrganisation owner)
            => new FacilityBuilder(this.Session).WithName(name).WithFacilityType(type).WithOwner(owner).Build();

        private Good CreateGood(string sku, VatRate vatRate, string name, UnitOfMeasure uom, ProductCategory category, Part part)
            => new GoodBuilder(this.Session)
                .WithSku(sku)
                .WithVatRate(vatRate)
                .WithName(name)
                .WithUnitOfMeasure(uom)
                .WithPrimaryProductCategory(category)
                .WithPart(part)
                .Build();

        private SerialisedInventoryItem CreateSerialzedInventoryItem(string serialNumber, Part part)
            => new SerialisedInventoryItemBuilder(this.Session).WithSerialNumber(serialNumber).WithPart(part).Build();

        private SerialisedInventoryItem CreateSerialzedInventoryItem(string serialNumber, Part part, Facility facility)
            => new SerialisedInventoryItemBuilder(this.Session).WithSerialNumber(serialNumber).WithPart(part).WithFacility(facility).Build();

        private Part CreatePart(string partId, InventoryItemKind kind)
            => new PartBuilder(this.Session).WithPartId(partId).WithInventoryItemKind(kind).Build();

        private InventoryItemVariance CreateInventoryVariance(int quantity, VarianceReason reason)
           => new InventoryItemVarianceBuilder(this.Session).WithQuantity(quantity).WithReason(reason).Build();
    }
}
