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
    using System.Linq;
    
    public class SerialisedInventoryItemTests : DomainTest
    {
        [Fact]
        public void GivenInventoryItem_WhenDeriving_ThenRequiredRelationsMustExist()
        {
            // Arrange
            var serialItem = new SerialisedItemBuilder(this.Session).WithSerialNumber("1").Build();
            var part = new NonUnifiedPartBuilder(this.Session).WithName("part")
                .WithInventoryItemKind(new InventoryItemKinds(this.Session).Serialised)
                .WithProductIdentification(new PartNumberBuilder(this.Session)
                    .WithIdentification("P1")
                    .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Part).Build())
                .WithSerialisedItem(serialItem)
                .Build();

            this.Session.Derive(true);
            this.Session.Commit();

            var builder = new SerialisedInventoryItemBuilder(this.Session).WithPart(part);
            builder.Build();

            // Act
            var derivation = this.Session.Derive(false);

            // Assert
            Assert.True(derivation.HasErrors);

            // Re-arrange
            this.Session.Rollback();

            builder.WithSerialisedItem(serialItem);
            builder.Build();

            // Act
            derivation = this.Session.Derive(false);

            // Assert
            Assert.False(derivation.HasErrors);
        }

        [Fact]
        public void GivenInventoryItem_WhenBuild_ThenPostBuildRelationsMustExist()
        {
            // Arrange
            var available = new SerialisedInventoryItemStates(this.Session).Available;
            var warehouse = new Facilities(this.Session).FindBy(M.Facility.FacilityType, new FacilityTypes(this.Session).Warehouse);
            var kinds = new InventoryItemKinds(this.Session);

            var serialItem = new SerialisedItemBuilder(this.Session).WithSerialNumber("1").Build();
            var finishedGood = CreatePart("1", kinds.Serialised);
            finishedGood.AddSerialisedItem(serialItem);
            var serialInventoryItem = new SerialisedInventoryItemBuilder(this.Session).WithSerialisedItem(serialItem).WithPart(finishedGood).Build();

            // Act
            this.Session.Derive(true);

            // Assert
            Assert.Equal(available, serialInventoryItem.SerialisedInventoryItemState);
            Assert.Equal(warehouse, serialInventoryItem.Facility);
        }

        [Fact]
        public void GivenFinishedGoodWithSerializedInventory_WhenDeriving_ThenQuantityOnHandUpdated()
        {
            // Arrange
            var available = new SerialisedInventoryItemStates(this.Session).Available;
            var warehouse = new Facilities(this.Session).FindBy(M.Facility.FacilityType, new FacilityTypes(this.Session).Warehouse);

            var kinds = new InventoryItemKinds(this.Session);
            var unitsOfMeasure = new UnitsOfMeasure(this.Session);
            var unknown = new InventoryTransactionReasons(this.Session).Unknown;

            var vatRate21 = new VatRateBuilder(this.Session).WithRate(21).Build();
            var category = new ProductCategoryBuilder(this.Session).WithName("category").Build();
            var serialPart = CreatePart("FG1", kinds.Serialised);
            var serialItem1 = new SerialisedItemBuilder(this.Session).WithSerialNumber("1").Build();
            var serialItem2 = new SerialisedItemBuilder(this.Session).WithSerialNumber("2").Build();
            var serialItem3 = new SerialisedItemBuilder(this.Session).WithSerialNumber("3").Build();

            serialPart.AddSerialisedItem(serialItem1);
            serialPart.AddSerialisedItem(serialItem2);
            serialPart.AddSerialisedItem(serialItem3);

            var good = CreateGood("10101", vatRate21, "good1", unitsOfMeasure.Piece, category, serialPart);

            // Act
            this.Session.Derive(true);

            CreateInventoryTransaction(1, unknown, serialPart, serialItem1);
            CreateInventoryTransaction(1, unknown, serialPart, serialItem2);
            CreateInventoryTransaction(1, unknown, serialPart, serialItem3);

            this.Session.Derive(true);

            // Assert
            Assert.Equal(3, serialPart.QuantityOnHand);
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
            var unknown = new InventoryTransactionReasons(this.Session).Unknown;

            var vatRate21 = new VatRateBuilder(this.Session).WithRate(21).Build();
            var category = new ProductCategoryBuilder(this.Session).WithName("category").Build();
            var finishedGood = CreatePart("FG1", serialized);
            var serialItem1 = new SerialisedItemBuilder(this.Session).WithSerialNumber("1").Build();
            var serialItem2 = new SerialisedItemBuilder(this.Session).WithSerialNumber("2").Build();

            finishedGood.AddSerialisedItem(serialItem1);
            finishedGood.AddSerialisedItem(serialItem2);

            var good = CreateGood("10101", vatRate21, "good1", piece, category, finishedGood);

            // Act
            this.Session.Derive(true);

            CreateInventoryTransaction(1, unknown, finishedGood, serialItem1, warehouse1);
            CreateInventoryTransaction(1, unknown, finishedGood, serialItem2, warehouse2);

            this.Session.Derive(true);

            // Assert
            var item1 = (SerialisedInventoryItem)new InventoryItems(this.Session).Extent().First(i => i.Facility.Equals(warehouse1));
            Assert.Equal(1, item1.QuantityOnHand);

            var item2 = (SerialisedInventoryItem)new InventoryItems(this.Session).Extent().First(i => i.Facility.Equals(warehouse2));
            Assert.Equal(1, item2.QuantityOnHand);

            Assert.Equal(2, finishedGood.QuantityOnHand);
        }

        private Facility CreateFacility(string name, FacilityType type, InternalOrganisation owner)
            => new FacilityBuilder(this.Session).WithName(name).WithFacilityType(type).WithOwner(owner).Build();

        private Good CreateGood(string sku, VatRate vatRate, string name, UnitOfMeasure uom, ProductCategory category, Part part)
            => new NonUnifiedGoodBuilder(this.Session)
                .WithProductIdentification(new SkuIdentificationBuilder(this.Session)
                    .WithIdentification(sku)
                    .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Sku).Build())
                .WithVatRate(vatRate)
                .WithName(name)
                .WithUnitOfMeasure(uom)
                .WithPart(part)
                .Build();        

        private Part CreatePart(string partId, InventoryItemKind kind)
            => new NonUnifiedPartBuilder(this.Session)
                .WithProductIdentification(new PartNumberBuilder(this.Session)
                    .WithIdentification(partId)
                    .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Part).Build())
                .WithInventoryItemKind(kind).Build();

        private InventoryItemTransaction CreateInventoryTransaction(int quantity, InventoryTransactionReason reason, Part part, SerialisedItem serialisedItem)
           => new InventoryItemTransactionBuilder(this.Session).WithQuantity(quantity).WithReason(reason).WithPart(part).WithSerialisedItem(serialisedItem).Build();

        private InventoryItemTransaction CreateInventoryTransaction(int quantity, InventoryTransactionReason reason, Part part, SerialisedItem serialisedItem, Facility facility)
           => new InventoryItemTransactionBuilder(this.Session).WithQuantity(quantity).WithReason(reason).WithPart(part).WithSerialisedItem(serialisedItem).WithFacility(facility).Build();
    }
}
