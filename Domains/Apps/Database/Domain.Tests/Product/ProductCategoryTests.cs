 //------------------------------------------------------------------------------------------------- 
// <copyright file="ProductCategoryTests.cs" company="Allors bvba">
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

    public class ProductCategoryTests : DomainTest
    {
        [Fact]
        public void GivenProductCategory_WhenDeriving_ThenRequiredRelationsMustExist()
        {
            var builder = new ProductCategoryBuilder(this.Session);
            var productCategory = builder.Build();

            Assert.True(this.Session.Derive(false).HasErrors);

            this.Session.Rollback();

            builder.WithName("category");
            builder.Build();

            Assert.False(this.Session.Derive(false).HasErrors);
        }

        [Fact]
        public void GivenProductCategory_WhenDeriving_ThenSuperJacentAreSet()
        {
            var productCategory1 = new ProductCategoryBuilder(this.Session)
                .WithName("1")
                .Build();
            var productCategory2 = new ProductCategoryBuilder(this.Session)
                .WithName("2")
                .Build();
            var productCategory11 = new ProductCategoryBuilder(this.Session)
                .WithName("1.1")
                .WithParent(productCategory1)
                .WithParent(productCategory2)
                .Build();
            var productCategory12 = new ProductCategoryBuilder(this.Session)
                .WithName("1.2")
                .WithParent(productCategory1)
                .WithParent(productCategory2)
                .Build();
            var productCategory111 = new ProductCategoryBuilder(this.Session)
                .WithName("1.1.1")
                .WithParent(productCategory11)
                .Build();
            var productCategory121 = new ProductCategoryBuilder(this.Session)
                .WithName("1.2.1")
                .WithParent(productCategory12)
                .Build();
            var productCategory122 = new ProductCategoryBuilder(this.Session)
                .WithName("1.2.2")
                .WithParent(productCategory12)
                .Build();

            this.Session.Derive(); 

            Assert.False(productCategory1.ExistSuperJacent);
            Assert.False(productCategory2.ExistSuperJacent);

            Assert.Equal(2, productCategory11.SuperJacent.Count);
            Assert.Contains(productCategory1, productCategory11.SuperJacent);
            Assert.Contains(productCategory2, productCategory11.SuperJacent);

            Assert.Equal(2, productCategory12.SuperJacent.Count);
            Assert.Contains(productCategory1, productCategory12.SuperJacent);
            Assert.Contains(productCategory2, productCategory12.SuperJacent);

            Assert.Equal(3, productCategory111.SuperJacent.Count);
            Assert.Contains(productCategory11, productCategory111.SuperJacent);
            Assert.Contains(productCategory1, productCategory111.SuperJacent);
            Assert.Contains(productCategory2, productCategory111.SuperJacent);

            Assert.Equal(3, productCategory121.SuperJacent.Count);
            Assert.Contains(productCategory12, productCategory121.SuperJacent);
            Assert.Contains(productCategory1, productCategory121.SuperJacent);
            Assert.Contains(productCategory2, productCategory121.SuperJacent);

            Assert.Equal(3, productCategory122.SuperJacent.Count);
            Assert.Contains(productCategory12, productCategory122.SuperJacent);
            Assert.Contains(productCategory1, productCategory122.SuperJacent);
            Assert.Contains(productCategory2, productCategory122.SuperJacent);
        }

        [Fact]
        public void GivenProductCategory_WhenNewParentsAreInserted_ThenSuperJacentAreRecalculated()
        {
            var productCategory1 = new ProductCategoryBuilder(this.Session)
                .WithName("1")
                .Build();
            var productCategory2 = new ProductCategoryBuilder(this.Session)
                .WithName("2")
                .Build();
            var productCategory11 = new ProductCategoryBuilder(this.Session)
                .WithName("1.1")
                .WithParent(productCategory1)
                .WithParent(productCategory2)
                .Build();
            var productCategory12 = new ProductCategoryBuilder(this.Session)
                .WithName("1.2")
                .WithParent(productCategory1)
                .WithParent(productCategory2)
                .Build();
            var productCategory111 = new ProductCategoryBuilder(this.Session)
                .WithName("1.1.1")
                .WithParent(productCategory11)
                .Build();
            var productCategory121 = new ProductCategoryBuilder(this.Session)
                .WithName("1.2.1")
                .WithParent(productCategory12)
                .Build();
            var productCategory122 = new ProductCategoryBuilder(this.Session)
                .WithName("1.2.2")
                .WithParent(productCategory12)
                .Build();

            this.Session.Derive(); 

            Assert.False(productCategory1.ExistSuperJacent);
            Assert.False(productCategory2.ExistSuperJacent);

            Assert.Equal(2, productCategory11.SuperJacent.Count);
            Assert.Contains(productCategory1, productCategory11.SuperJacent);
            Assert.Contains(productCategory2, productCategory11.SuperJacent);

            Assert.Equal(2, productCategory12.SuperJacent.Count);
            Assert.Contains(productCategory1, productCategory12.SuperJacent);
            Assert.Contains(productCategory2, productCategory12.SuperJacent);

            Assert.Equal(3, productCategory111.SuperJacent.Count);
            Assert.Contains(productCategory11, productCategory111.SuperJacent);
            Assert.Contains(productCategory1, productCategory111.SuperJacent);
            Assert.Contains(productCategory2, productCategory111.SuperJacent);

            Assert.Equal(3, productCategory121.SuperJacent.Count);
            Assert.Contains(productCategory12, productCategory121.SuperJacent);
            Assert.Contains(productCategory1, productCategory121.SuperJacent);
            Assert.Contains(productCategory2, productCategory121.SuperJacent);

            Assert.Equal(3, productCategory122.SuperJacent.Count);
            Assert.Contains(productCategory12, productCategory122.SuperJacent);
            Assert.Contains(productCategory1, productCategory122.SuperJacent);
            Assert.Contains(productCategory2, productCategory122.SuperJacent);

            var productCategory3 = new ProductCategoryBuilder(this.Session)
                .WithName("3")
                .Build();
            productCategory11.AddParent(productCategory3);

            this.Session.Derive();

            Assert.False(productCategory1.ExistSuperJacent);
            Assert.False(productCategory2.ExistSuperJacent);
            Assert.False(productCategory3.ExistSuperJacent);

            Assert.Equal(3, productCategory11.SuperJacent.Count);
            Assert.Contains(productCategory1, productCategory11.SuperJacent);
            Assert.Contains(productCategory2, productCategory11.SuperJacent);
            Assert.Contains(productCategory3, productCategory11.SuperJacent);

            Assert.Equal(2, productCategory12.SuperJacent.Count);
            Assert.Contains(productCategory1, productCategory12.SuperJacent);
            Assert.Contains(productCategory2, productCategory12.SuperJacent);

            Assert.Equal(4, productCategory111.SuperJacent.Count);
            Assert.Contains(productCategory11, productCategory111.SuperJacent);
            Assert.Contains(productCategory1, productCategory111.SuperJacent);
            Assert.Contains(productCategory2, productCategory111.SuperJacent);
            Assert.Contains(productCategory3, productCategory111.SuperJacent);

            Assert.Equal(3, productCategory121.SuperJacent.Count);
            Assert.Contains(productCategory12, productCategory121.SuperJacent);
            Assert.Contains(productCategory1, productCategory121.SuperJacent);
            Assert.Contains(productCategory2, productCategory121.SuperJacent);

            Assert.Equal(3, productCategory122.SuperJacent.Count);
            Assert.Contains(productCategory12, productCategory122.SuperJacent);
            Assert.Contains(productCategory1, productCategory122.SuperJacent);
            Assert.Contains(productCategory2, productCategory122.SuperJacent);

            var productCategory13 = new ProductCategoryBuilder(this.Session)
                .WithName("1.3")
                .WithParent(productCategory1)
                .Build();
            productCategory122.AddParent(productCategory13);

            this.Session.Derive();

            Assert.False(productCategory1.ExistSuperJacent);
            Assert.False(productCategory2.ExistSuperJacent);
            Assert.False(productCategory3.ExistSuperJacent);

            Assert.Equal(3, productCategory11.SuperJacent.Count);
            Assert.Contains(productCategory1, productCategory11.SuperJacent);
            Assert.Contains(productCategory2, productCategory11.SuperJacent);
            Assert.Contains(productCategory3, productCategory11.SuperJacent);

            Assert.Equal(2, productCategory12.SuperJacent.Count);
            Assert.Contains(productCategory1, productCategory12.SuperJacent);
            Assert.Contains(productCategory2, productCategory12.SuperJacent);

            Assert.Equal(1, productCategory13.SuperJacent.Count);
            Assert.Contains(productCategory1, productCategory13.SuperJacent);

            Assert.Equal(4, productCategory111.SuperJacent.Count);
            Assert.Contains(productCategory11, productCategory111.SuperJacent);
            Assert.Contains(productCategory1, productCategory111.SuperJacent);
            Assert.Contains(productCategory2, productCategory111.SuperJacent);
            Assert.Contains(productCategory3, productCategory111.SuperJacent);

            Assert.Equal(3, productCategory121.SuperJacent.Count);
            Assert.Contains(productCategory12, productCategory121.SuperJacent);
            Assert.Contains(productCategory1, productCategory121.SuperJacent);
            Assert.Contains(productCategory2, productCategory121.SuperJacent);

            Assert.Equal(4, productCategory122.SuperJacent.Count);
            Assert.Contains(productCategory12, productCategory122.SuperJacent);
            Assert.Contains(productCategory13, productCategory122.SuperJacent);
            Assert.Contains(productCategory1, productCategory122.SuperJacent);
            Assert.Contains(productCategory2, productCategory122.SuperJacent);
        }

        [Fact]
        public void GivenProductCategory_WhenNewParentsAreRemoved_ThenSuperJacentAreRecalculated()
        {
            var productCategory1 = new ProductCategoryBuilder(this.Session)
                .WithName("1")
                .Build();
            var productCategory2 = new ProductCategoryBuilder(this.Session)
                .WithName("2")
                .Build();
            var productCategory11 = new ProductCategoryBuilder(this.Session)
                .WithName("1.1")
                .WithParent(productCategory1)
                .WithParent(productCategory2)
                .Build();
            var productCategory12 = new ProductCategoryBuilder(this.Session)
                .WithName("1.2")
                .WithParent(productCategory1)
                .WithParent(productCategory2)
                .Build();
            var productCategory111 = new ProductCategoryBuilder(this.Session)
                .WithName("1.1.1")
                .WithParent(productCategory11)
                .Build();
            var productCategory121 = new ProductCategoryBuilder(this.Session)
                .WithName("1.2.1")
                .WithParent(productCategory12)
                .Build();
            var productCategory122 = new ProductCategoryBuilder(this.Session)
                .WithName("1.2.2")
                .WithParent(productCategory12)
                .Build();

            this.Session.Derive(); 

            Assert.False(productCategory1.ExistSuperJacent);
            Assert.False(productCategory2.ExistSuperJacent);

            Assert.Equal(2, productCategory11.SuperJacent.Count);
            Assert.Contains(productCategory1, productCategory11.SuperJacent);
            Assert.Contains(productCategory2, productCategory11.SuperJacent);

            Assert.Equal(2, productCategory12.SuperJacent.Count);
            Assert.Contains(productCategory1, productCategory12.SuperJacent);
            Assert.Contains(productCategory2, productCategory12.SuperJacent);

            Assert.Equal(3, productCategory111.SuperJacent.Count);
            Assert.Contains(productCategory11, productCategory111.SuperJacent);
            Assert.Contains(productCategory1, productCategory111.SuperJacent);
            Assert.Contains(productCategory2, productCategory111.SuperJacent);

            Assert.Equal(3, productCategory121.SuperJacent.Count);
            Assert.Contains(productCategory12, productCategory121.SuperJacent);
            Assert.Contains(productCategory1, productCategory121.SuperJacent);
            Assert.Contains(productCategory2, productCategory121.SuperJacent);

            Assert.Equal(3, productCategory122.SuperJacent.Count);
            Assert.Contains(productCategory12, productCategory122.SuperJacent);
            Assert.Contains(productCategory1, productCategory122.SuperJacent);
            Assert.Contains(productCategory2, productCategory122.SuperJacent);

            productCategory11.RemoveParent(productCategory2);

            this.Session.Derive();

            Assert.False(productCategory1.ExistSuperJacent);
            Assert.False(productCategory2.ExistSuperJacent);

            Assert.Equal(1, productCategory11.SuperJacent.Count);
            Assert.Contains(productCategory1, productCategory11.SuperJacent);

            Assert.Equal(2, productCategory12.SuperJacent.Count);
            Assert.Contains(productCategory1, productCategory12.SuperJacent);
            Assert.Contains(productCategory2, productCategory12.SuperJacent);

            Assert.Equal(2, productCategory111.SuperJacent.Count);
            Assert.Contains(productCategory11, productCategory111.SuperJacent);
            Assert.Contains(productCategory1, productCategory111.SuperJacent);

            Assert.Equal(3, productCategory121.SuperJacent.Count);
            Assert.Contains(productCategory12, productCategory121.SuperJacent);
            Assert.Contains(productCategory1, productCategory121.SuperJacent);
            Assert.Contains(productCategory2, productCategory121.SuperJacent);

            Assert.Equal(3, productCategory122.SuperJacent.Count);
            Assert.Contains(productCategory12, productCategory122.SuperJacent);
            Assert.Contains(productCategory1, productCategory122.SuperJacent);
            Assert.Contains(productCategory2, productCategory122.SuperJacent);
        }

        [Fact]
        public void GivenProductCategory_WhenDeriving_ThenChildrenAreSet()
        {
            var productCategory1 = new ProductCategoryBuilder(this.Session)
                .WithName("1")
                .Build();
            var productCategory2 = new ProductCategoryBuilder(this.Session)
                .WithName("2")
                .Build();
            var productCategory11 = new ProductCategoryBuilder(this.Session)
                .WithName("1.1")
                .WithParent(productCategory1)
                .Build();
            var productCategory12 = new ProductCategoryBuilder(this.Session)
                .WithName("1.2")
                .WithParent(productCategory1)
                .WithParent(productCategory2)
                .Build();
            var productCategory111 = new ProductCategoryBuilder(this.Session)
                .WithName("1.1.1")
                .WithParent(productCategory11)
                .Build();
            var productCategory121 = new ProductCategoryBuilder(this.Session)
                .WithName("1.2.1")
                .WithParent(productCategory12)
                .Build();
            var productCategory122 = new ProductCategoryBuilder(this.Session)
                .WithName("1.2.2")
                .WithParent(productCategory12)
                .Build();

            this.Session.Derive(); 

            Assert.Equal(5, productCategory1.Children.Count);
            Assert.Contains(productCategory11, productCategory1.Children);
            Assert.Contains(productCategory12, productCategory1.Children);
            Assert.Contains(productCategory111, productCategory1.Children);
            Assert.Contains(productCategory121, productCategory1.Children);
            Assert.Contains(productCategory122, productCategory1.Children);

            Assert.Equal(3, productCategory2.Children.Count);
            Assert.Contains(productCategory12, productCategory2.Children);
            Assert.Contains(productCategory121, productCategory2.Children);
            Assert.Contains(productCategory122, productCategory2.Children);

            Assert.Equal(1, productCategory11.Children.Count);
            Assert.Contains(productCategory111, productCategory11.Children);

            Assert.Equal(2, productCategory12.Children.Count);
            Assert.Contains(productCategory121, productCategory12.Children);
            Assert.Contains(productCategory122, productCategory12.Children);

            Assert.False(productCategory111.ExistChildren);
            Assert.False(productCategory121.ExistChildren);
            Assert.False(productCategory122.ExistChildren);
        }

        [Fact]
        public void GivenProductCategoryHierarchy_WhenDeriving_ThenAllProductAreSet()
        {
            var vatRate21 = new VatRateBuilder(this.Session).WithRate(21).Build();

            var good1 = new NonUnifiedGoodBuilder(this.Session)
                .WithName("good1")
                .WithProductIdentification(new ProductNumberBuilder(this.Session)
                    .WithIdentification("good1")
                    .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Good).Build())
                .WithVatRate(vatRate21)
                .WithPart(new NonUnifiedPartBuilder(this.Session)
                            .WithProductIdentification(new PartNumberBuilder(this.Session)
                                .WithIdentification("1")
                                .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Part).Build())
                            .WithInventoryItemKind(new InventoryItemKinds(this.Session).NonSerialised).Build())
                .Build();

            var good2 = new NonUnifiedGoodBuilder(this.Session)
                .WithName("good2")
                .WithProductIdentification(new ProductNumberBuilder(this.Session)
                    .WithIdentification("good2")
                    .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Good).Build())
                .WithVatRate(vatRate21)
                .WithPart(new NonUnifiedPartBuilder(this.Session)
                            .WithProductIdentification(new PartNumberBuilder(this.Session)
                                .WithIdentification("2")
                                .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Part).Build())
                            .WithInventoryItemKind(new InventoryItemKinds(this.Session).NonSerialised).Build())
                .Build();

            var good11 = new NonUnifiedGoodBuilder(this.Session)
                .WithName("good11")
                .WithProductIdentification(new ProductNumberBuilder(this.Session)
                    .WithIdentification("good11")
                    .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Good).Build())
                .WithVatRate(vatRate21)
                .WithPart(new NonUnifiedPartBuilder(this.Session)
                            .WithProductIdentification(new PartNumberBuilder(this.Session)
                                .WithIdentification("3")
                                .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Part).Build())
                            .WithInventoryItemKind(new InventoryItemKinds(this.Session).NonSerialised).Build())
                .Build();

            var good12 = new NonUnifiedGoodBuilder(this.Session)
                .WithName("good12")
                .WithProductIdentification(new ProductNumberBuilder(this.Session)
                    .WithIdentification("good12")
                    .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Good).Build())
                .WithVatRate(vatRate21)
                .WithPart(new NonUnifiedPartBuilder(this.Session)
                            .WithProductIdentification(new PartNumberBuilder(this.Session)
                                .WithIdentification("4")
                                .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Part).Build())
                            .WithInventoryItemKind(new InventoryItemKinds(this.Session).NonSerialised).Build())
                .Build();

            var good111 = new NonUnifiedGoodBuilder(this.Session)
                .WithName("good111")
                .WithProductIdentification(new ProductNumberBuilder(this.Session)
                    .WithIdentification("good111")
                    .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Good).Build())
                .WithVatRate(vatRate21)
                .WithPart(new NonUnifiedPartBuilder(this.Session)
                    .WithProductIdentification(new PartNumberBuilder(this.Session)
                        .WithIdentification("5")
                        .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Part).Build())
                    .WithInventoryItemKind(new InventoryItemKinds(this.Session).NonSerialised).Build())
                .Build();

            var good121 = new NonUnifiedGoodBuilder(this.Session)
                .WithName("good121")
                .WithProductIdentification(new ProductNumberBuilder(this.Session)
                    .WithIdentification("good121")
                    .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Good).Build())
                .WithVatRate(vatRate21)
                .WithPart(new NonUnifiedPartBuilder(this.Session)
                    .WithProductIdentification(new PartNumberBuilder(this.Session)
                        .WithIdentification("6")
                        .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Part).Build())
                    .WithInventoryItemKind(new InventoryItemKinds(this.Session).NonSerialised).Build())
                .Build();

            var good122 = new NonUnifiedGoodBuilder(this.Session)
                .WithName("good122")
                .WithProductIdentification(new ProductNumberBuilder(this.Session)
                    .WithIdentification("good122")
                    .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Good).Build())
                .WithVatRate(vatRate21)
                .WithPart(new NonUnifiedPartBuilder(this.Session)
                    .WithProductIdentification(new PartNumberBuilder(this.Session)
                        .WithIdentification("7")
                        .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Part).Build())
                    .WithInventoryItemKind(new InventoryItemKinds(this.Session).NonSerialised).Build())
                .Build();

            var productCategory1 = new ProductCategoryBuilder(this.Session)
                .WithName("1")
                .WithProduct(good1)
                .Build();
            var productCategory2 = new ProductCategoryBuilder(this.Session)
                .WithName("2")
                .WithProduct(good2)
                .Build();
            var productCategory11 = new ProductCategoryBuilder(this.Session)
                .WithName("1.1")
                .WithParent(productCategory1)
                .WithProduct(good11)
                .Build();
            var productCategory12 = new ProductCategoryBuilder(this.Session)
                .WithName("1.2")
                .WithParent(productCategory1)
                .WithParent(productCategory2)
                .WithProduct(good12)
                .Build();
            var productCategory111 = new ProductCategoryBuilder(this.Session)
                .WithName("1.1.1")
                .WithParent(productCategory11)
                .WithProduct(good111)
                .Build();
            var productCategory121 = new ProductCategoryBuilder(this.Session)
                .WithName("1.2.1")
                .WithParent(productCategory12)
                .WithProduct(good121)
                .Build();
            var productCategory122 = new ProductCategoryBuilder(this.Session)
                .WithName("1.2.2")
                .WithParent(productCategory12)
                .WithProduct(good122)
                .Build();


            this.Session.Derive();

            Assert.Equal(6, productCategory1.AllProducts.Count);
            Assert.Contains(good1, productCategory1.AllProducts);
            Assert.Contains(good11, productCategory1.AllProducts);
            Assert.Contains(good12, productCategory1.AllProducts);
            Assert.Contains(good111, productCategory1.AllProducts);
            Assert.Contains(good121, productCategory1.AllProducts);
            Assert.Contains(good122, productCategory1.AllProducts);

            Assert.Equal(4, productCategory2.AllProducts.Count);
            Assert.Contains(good2, productCategory2.AllProducts);
            Assert.Contains(good12, productCategory2.AllProducts);
            Assert.Contains(good121, productCategory2.AllProducts);
            Assert.Contains(good122, productCategory2.AllProducts);

            Assert.Equal(2, productCategory11.AllProducts.Count);
            Assert.Contains(good11, productCategory11.AllProducts);
            Assert.Contains(good111, productCategory11.AllProducts);

            Assert.Equal(3, productCategory12.AllProducts.Count);
            Assert.Contains(good12, productCategory12.AllProducts);
            Assert.Contains(good121, productCategory12.AllProducts);
            Assert.Contains(good122, productCategory12.AllProducts);

            Assert.Equal(1, productCategory111.AllProducts.Count);
            Assert.Contains(good111, productCategory111.AllProducts);

            Assert.Equal(1, productCategory121.AllProducts.Count);
            Assert.Contains(good121, productCategory121.AllProducts);

            Assert.Equal(1, productCategory122.AllProducts.Count);
            Assert.Contains(good122, productCategory122.AllProducts);
        }

        [Fact]
        public void GivenProductCategoryHierarchy_WhenDeriving_ThenAllSerialisedItemsForSaleAreSet()
        {
            var vatRate21 = new VatRateBuilder(this.Session).WithRate(21).Build();

            var good1 = new NonUnifiedGoodBuilder(this.Session)
                .WithName("good1")
                .WithProductIdentification(new ProductNumberBuilder(this.Session)
                    .WithIdentification("good1")
                    .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Good).Build())
                .WithVatRate(vatRate21)
                .WithPart(new NonUnifiedPartBuilder(this.Session)
                            .WithProductIdentification(new PartNumberBuilder(this.Session)
                                .WithIdentification("1")
                                .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Part).Build())
                            .WithInventoryItemKind(new InventoryItemKinds(this.Session).Serialised)
                            .Build())
                .Build();

            var serialisedItem1 = new SerialisedItemBuilder(this.Session).WithSerialNumber("1").WithAvailableForSale(true).Build();
            var serialisedItem1Not = new SerialisedItemBuilder(this.Session).WithSerialNumber("1Not").Build();  // This one must be excluded
            good1.Part.AddSerialisedItem(serialisedItem1);
            good1.Part.AddSerialisedItem(serialisedItem1Not);

            var good2 = new NonUnifiedGoodBuilder(this.Session)
                .WithName("good2")
                .WithProductIdentification(new ProductNumberBuilder(this.Session)
                    .WithIdentification("good2")
                    .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Good).Build())
                .WithVatRate(vatRate21)
                .WithPart(new NonUnifiedPartBuilder(this.Session)
                            .WithProductIdentification(new PartNumberBuilder(this.Session)
                                .WithIdentification("2")
                                .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Part).Build())
                            .WithInventoryItemKind(new InventoryItemKinds(this.Session).Serialised)
                            .Build())
                .Build();

            var serialisedItem2a = new SerialisedItemBuilder(this.Session).WithSerialNumber("2a").WithAvailableForSale(true).Build();
            var serialisedItem2b = new SerialisedItemBuilder(this.Session).WithSerialNumber("2b").WithAvailableForSale(true).Build();
            good2.Part.AddSerialisedItem(serialisedItem2a);
            good2.Part.AddSerialisedItem(serialisedItem2b);

            var good11 = new NonUnifiedGoodBuilder(this.Session)
                .WithName("good11")
                .WithProductIdentification(new ProductNumberBuilder(this.Session)
                    .WithIdentification("good11")
                    .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Good).Build())
                .WithVatRate(vatRate21)
                .WithPart(new NonUnifiedPartBuilder(this.Session)
                            .WithProductIdentification(new PartNumberBuilder(this.Session)
                                .WithIdentification("3")
                                .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Part).Build())
                            .WithInventoryItemKind(new InventoryItemKinds(this.Session).Serialised)
                            .Build())
                .Build();

            var serialisedItem11 = new SerialisedItemBuilder(this.Session).WithSerialNumber("11").WithAvailableForSale(true).Build();
            good11.Part.AddSerialisedItem(serialisedItem11);

            var good12 = new NonUnifiedGoodBuilder(this.Session)
                .WithName("good12")
                .WithProductIdentification(new ProductNumberBuilder(this.Session)
                    .WithIdentification("good12")
                    .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Good).Build())
                .WithVatRate(vatRate21)
                .WithPart(new NonUnifiedPartBuilder(this.Session)
                            .WithProductIdentification(new PartNumberBuilder(this.Session)
                                .WithIdentification("4")
                                .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Part).Build())
                            .WithInventoryItemKind(new InventoryItemKinds(this.Session).Serialised)
                            .Build())
                .Build();

            var serialisedItem12 = new SerialisedItemBuilder(this.Session).WithSerialNumber("12").WithAvailableForSale(true).Build();
            good12.Part.AddSerialisedItem(serialisedItem12);

            var good111 = new NonUnifiedGoodBuilder(this.Session)
                .WithName("good111")
                .WithProductIdentification(new ProductNumberBuilder(this.Session)
                    .WithIdentification("good111")
                    .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Good).Build())
                .WithVatRate(vatRate21)
                .WithPart(new NonUnifiedPartBuilder(this.Session)
                            .WithProductIdentification(new PartNumberBuilder(this.Session)
                                .WithIdentification("5")
                                .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Part).Build())
                            .WithInventoryItemKind(new InventoryItemKinds(this.Session).Serialised)
                            .Build())
                .Build();

            var serialisedItem111 = new SerialisedItemBuilder(this.Session).WithSerialNumber("111").WithAvailableForSale(true).Build();
            good111.Part.AddSerialisedItem(serialisedItem111);

            var good121 = new NonUnifiedGoodBuilder(this.Session)
                .WithName("good121")
                .WithProductIdentification(new ProductNumberBuilder(this.Session)
                    .WithIdentification("good121")
                    .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Good).Build())
                .WithVatRate(vatRate21)
                .WithPart(new NonUnifiedPartBuilder(this.Session)
                            .WithProductIdentification(new PartNumberBuilder(this.Session)
                                .WithIdentification("6")
                                .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Part).Build())
                            .WithInventoryItemKind(new InventoryItemKinds(this.Session).Serialised)
                            .Build())
                .Build();

            var serialisedItem121 = new SerialisedItemBuilder(this.Session).WithSerialNumber("121").WithAvailableForSale(true).Build();
            good121.Part.AddSerialisedItem(serialisedItem121);

            var good122 = new NonUnifiedGoodBuilder(this.Session)
                .WithName("good122")
                .WithProductIdentification(new ProductNumberBuilder(this.Session)
                    .WithIdentification("good122")
                    .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Good).Build())
                .WithVatRate(vatRate21)
                .WithPart(new NonUnifiedPartBuilder(this.Session)
                            .WithProductIdentification(new PartNumberBuilder(this.Session)
                                .WithIdentification("7")
                                .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Part).Build())
                            .WithInventoryItemKind(new InventoryItemKinds(this.Session).Serialised)
                            .Build())
                .Build();

            var serialisedItem122 = new SerialisedItemBuilder(this.Session).WithSerialNumber("122").WithAvailableForSale(true).Build();
            good122.Part.AddSerialisedItem(serialisedItem122);

            var productCategory1 = new ProductCategoryBuilder(this.Session)
                .WithName("1")
                .WithProduct(good1)
                .Build();
            var productCategory2 = new ProductCategoryBuilder(this.Session)
                .WithName("2")
                .WithProduct(good2)
                .Build();
            var productCategory11 = new ProductCategoryBuilder(this.Session)
                .WithName("1.1")
                .WithParent(productCategory1)
                .WithProduct(good11)
                .Build();
            var productCategory12 = new ProductCategoryBuilder(this.Session)
                .WithName("1.2")
                .WithParent(productCategory1)
                .WithParent(productCategory2)
                .WithProduct(good12)
                .Build();
            var productCategory111 = new ProductCategoryBuilder(this.Session)
                .WithName("1.1.1")
                .WithParent(productCategory11)
                .WithProduct(good111)
                .Build();
            var productCategory121 = new ProductCategoryBuilder(this.Session)
                .WithName("1.2.1")
                .WithParent(productCategory12)
                .WithProduct(good121)
                .Build();
            var productCategory122 = new ProductCategoryBuilder(this.Session)
                .WithName("1.2.2")
                .WithParent(productCategory12)
                .WithProduct(good122)
                .Build();


            this.Session.Derive();

            Assert.Equal(6, productCategory1.AllSerialisedItemsForSale.Count);
            Assert.Contains(serialisedItem1, productCategory1.AllSerialisedItemsForSale);
            Assert.Contains(serialisedItem11, productCategory1.AllSerialisedItemsForSale);
            Assert.Contains(serialisedItem12, productCategory1.AllSerialisedItemsForSale);
            Assert.Contains(serialisedItem111, productCategory1.AllSerialisedItemsForSale);
            Assert.Contains(serialisedItem121, productCategory1.AllSerialisedItemsForSale);
            Assert.Contains(serialisedItem122, productCategory1.AllSerialisedItemsForSale);

            Assert.Equal(5, productCategory2.AllSerialisedItemsForSale.Count);
            Assert.Contains(serialisedItem2a, productCategory2.AllSerialisedItemsForSale);
            Assert.Contains(serialisedItem2b, productCategory2.AllSerialisedItemsForSale);
            Assert.Contains(serialisedItem12, productCategory2.AllSerialisedItemsForSale);
            Assert.Contains(serialisedItem121, productCategory2.AllSerialisedItemsForSale);
            Assert.Contains(serialisedItem122, productCategory2.AllSerialisedItemsForSale);

            Assert.Equal(2, productCategory11.AllSerialisedItemsForSale.Count);
            Assert.Contains(serialisedItem11, productCategory11.AllSerialisedItemsForSale);
            Assert.Contains(serialisedItem111, productCategory11.AllSerialisedItemsForSale);

            Assert.Equal(3, productCategory12.AllSerialisedItemsForSale.Count);
            Assert.Contains(serialisedItem12, productCategory12.AllSerialisedItemsForSale);
            Assert.Contains(serialisedItem121, productCategory12.AllSerialisedItemsForSale);
            Assert.Contains(serialisedItem122, productCategory12.AllSerialisedItemsForSale);

            Assert.Equal(1, productCategory111.AllSerialisedItemsForSale.Count);
            Assert.Contains(serialisedItem111, productCategory111.AllSerialisedItemsForSale);

            Assert.Equal(1, productCategory121.AllSerialisedItemsForSale.Count);
            Assert.Contains(serialisedItem121, productCategory121.AllSerialisedItemsForSale);

            Assert.Equal(1, productCategory122.AllSerialisedItemsForSale.Count);
            Assert.Contains(serialisedItem122, productCategory122.AllSerialisedItemsForSale);
        }

        [Fact]
        public void GivenProductCategoryHierarchy_WhenDeriving_ThenAllNonSerialisedInventoryItemsForSaleAreSet()
        {
            var vatRate21 = new VatRateBuilder(this.Session).WithRate(21).Build();

            var good1 = new NonUnifiedGoodBuilder(this.Session)
                .WithName("good1")
                .WithProductIdentification(new ProductNumberBuilder(this.Session)
                    .WithIdentification("good1")
                    .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Good).Build())
                .WithVatRate(vatRate21)
                .WithPart(new NonUnifiedPartBuilder(this.Session)
                            .WithProductIdentification(new PartNumberBuilder(this.Session)
                                .WithIdentification("1")
                                .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Part).Build())
                            .WithInventoryItemKind(new InventoryItemKinds(this.Session).NonSerialised)
                            .Build())
                .Build();

            var item1 = new NonSerialisedInventoryItemBuilder(this.Session).WithPart(good1.Part).WithNonSerialisedInventoryItemState(new NonSerialisedInventoryItemStates(this.Session).Good).Build();
            var item1Not = new NonSerialisedInventoryItemBuilder(this.Session).WithPart(good1.Part).WithNonSerialisedInventoryItemState(new NonSerialisedInventoryItemStates(this.Session).Scrap).Build();

            var good2 = new NonUnifiedGoodBuilder(this.Session)
                .WithName("good2")
                .WithProductIdentification(new ProductNumberBuilder(this.Session)
                    .WithIdentification("good2")
                    .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Good).Build())
                .WithVatRate(vatRate21)
                .WithPart(new NonUnifiedPartBuilder(this.Session)
                            .WithProductIdentification(new PartNumberBuilder(this.Session)
                                .WithIdentification("2")
                                .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Part).Build())
                            .WithInventoryItemKind(new InventoryItemKinds(this.Session).NonSerialised)
                            .Build())
                .Build();

            var item2a = new NonSerialisedInventoryItemBuilder(this.Session).WithPart(good2.Part).WithNonSerialisedInventoryItemState(new NonSerialisedInventoryItemStates(this.Session).Good).Build();
            var item2b = new NonSerialisedInventoryItemBuilder(this.Session).WithPart(good2.Part).WithNonSerialisedInventoryItemState(new NonSerialisedInventoryItemStates(this.Session).SlightlyDamaged).Build();

            var good11 = new NonUnifiedGoodBuilder(this.Session)
                .WithName("good11")
                .WithProductIdentification(new ProductNumberBuilder(this.Session)
                    .WithIdentification("good11")
                    .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Good).Build())
                .WithVatRate(vatRate21)
                .WithPart(new NonUnifiedPartBuilder(this.Session)
                            .WithProductIdentification(new PartNumberBuilder(this.Session)
                                .WithIdentification("3")
                                .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Part).Build())
                            .WithInventoryItemKind(new InventoryItemKinds(this.Session).NonSerialised)
                            .Build())
                .Build();

            var item11 = new NonSerialisedInventoryItemBuilder(this.Session).WithPart(good11.Part).WithNonSerialisedInventoryItemState(new NonSerialisedInventoryItemStates(this.Session).Good).Build();

            var good12 = new NonUnifiedGoodBuilder(this.Session)
                .WithName("good12")
                .WithProductIdentification(new ProductNumberBuilder(this.Session)
                    .WithIdentification("good12")
                    .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Good).Build())
                .WithVatRate(vatRate21)
                .WithPart(new NonUnifiedPartBuilder(this.Session)
                            .WithProductIdentification(new PartNumberBuilder(this.Session)
                                .WithIdentification("4")
                                .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Part).Build())
                            .WithInventoryItemKind(new InventoryItemKinds(this.Session).NonSerialised)
                            .Build())
                .Build();

            var item12 = new NonSerialisedInventoryItemBuilder(this.Session).WithPart(good12.Part).WithNonSerialisedInventoryItemState(new NonSerialisedInventoryItemStates(this.Session).Good).Build();

            var good111 = new NonUnifiedGoodBuilder(this.Session)
                .WithName("good111")
                .WithProductIdentification(new ProductNumberBuilder(this.Session)
                    .WithIdentification("good111")
                    .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Good).Build())
                .WithVatRate(vatRate21)
                .WithPart(new NonUnifiedPartBuilder(this.Session)
                            .WithProductIdentification(new PartNumberBuilder(this.Session)
                                .WithIdentification("5")
                                .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Part).Build())
                            .WithInventoryItemKind(new InventoryItemKinds(this.Session).NonSerialised)
                            .Build())
                .Build();

            var item111 = new NonSerialisedInventoryItemBuilder(this.Session).WithPart(good111.Part).WithNonSerialisedInventoryItemState(new NonSerialisedInventoryItemStates(this.Session).Good).Build();

            var good121 = new NonUnifiedGoodBuilder(this.Session)
                .WithName("good121")
                .WithProductIdentification(new ProductNumberBuilder(this.Session)
                    .WithIdentification("good121")
                    .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Good).Build())
                .WithVatRate(vatRate21)
                .WithPart(new NonUnifiedPartBuilder(this.Session)
                            .WithProductIdentification(new PartNumberBuilder(this.Session)
                                .WithIdentification("6")
                                .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Part).Build())
                            .WithInventoryItemKind(new InventoryItemKinds(this.Session).NonSerialised)
                            .Build())
                .Build();

            var item121 = new NonSerialisedInventoryItemBuilder(this.Session).WithPart(good121.Part).WithNonSerialisedInventoryItemState(new NonSerialisedInventoryItemStates(this.Session).Good).Build();

            var good122 = new NonUnifiedGoodBuilder(this.Session)
                .WithName("good122")
                .WithProductIdentification(new ProductNumberBuilder(this.Session)
                    .WithIdentification("good122")
                    .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Good).Build())
                .WithVatRate(vatRate21)
                .WithPart(new NonUnifiedPartBuilder(this.Session)
                            .WithProductIdentification(new PartNumberBuilder(this.Session)
                                .WithIdentification("7")
                                .WithProductIdentificationType(new ProductIdentificationTypes(this.Session).Part).Build())
                            .WithInventoryItemKind(new InventoryItemKinds(this.Session).NonSerialised)
                            .Build())
                .Build();

            var item122 = new NonSerialisedInventoryItemBuilder(this.Session).WithPart(good122.Part).WithNonSerialisedInventoryItemState(new NonSerialisedInventoryItemStates(this.Session).Good).Build();

            var productCategory1 = new ProductCategoryBuilder(this.Session)
                .WithName("1")
                .WithProduct(good1)
                .Build();
            var productCategory2 = new ProductCategoryBuilder(this.Session)
                .WithName("2")
                .WithProduct(good2)
                .Build();
            var productCategory11 = new ProductCategoryBuilder(this.Session)
                .WithName("1.1")
                .WithParent(productCategory1)
                .WithProduct(good11)
                .Build();
            var productCategory12 = new ProductCategoryBuilder(this.Session)
                .WithName("1.2")
                .WithParent(productCategory1)
                .WithParent(productCategory2)
                .WithProduct(good12)
                .Build();
            var productCategory111 = new ProductCategoryBuilder(this.Session)
                .WithName("1.1.1")
                .WithParent(productCategory11)
                .WithProduct(good111)
                .Build();
            var productCategory121 = new ProductCategoryBuilder(this.Session)
                .WithName("1.2.1")
                .WithParent(productCategory12)
                .WithProduct(good121)
                .Build();
            var productCategory122 = new ProductCategoryBuilder(this.Session)
                .WithName("1.2.2")
                .WithParent(productCategory12)
                .WithProduct(good122)
                .Build();

            this.Session.Derive();

            Assert.Equal(6, productCategory1.AllNonSerialisedInventoryItemsForSale.Count);
            Assert.Contains(item1, productCategory1.AllNonSerialisedInventoryItemsForSale);
            Assert.Contains(item11, productCategory1.AllNonSerialisedInventoryItemsForSale);
            Assert.Contains(item12, productCategory1.AllNonSerialisedInventoryItemsForSale);
            Assert.Contains(item111, productCategory1.AllNonSerialisedInventoryItemsForSale);
            Assert.Contains(item121, productCategory1.AllNonSerialisedInventoryItemsForSale);
            Assert.Contains(item122, productCategory1.AllNonSerialisedInventoryItemsForSale);

            Assert.Equal(5, productCategory2.AllNonSerialisedInventoryItemsForSale.Count);
            Assert.Contains(item2a, productCategory2.AllNonSerialisedInventoryItemsForSale);
            Assert.Contains(item2b, productCategory2.AllNonSerialisedInventoryItemsForSale);
            Assert.Contains(item12, productCategory2.AllNonSerialisedInventoryItemsForSale);
            Assert.Contains(item121, productCategory2.AllNonSerialisedInventoryItemsForSale);
            Assert.Contains(item122, productCategory2.AllNonSerialisedInventoryItemsForSale);

            Assert.Equal(2, productCategory11.AllNonSerialisedInventoryItemsForSale.Count);
            Assert.Contains(item11, productCategory11.AllNonSerialisedInventoryItemsForSale);
            Assert.Contains(item111, productCategory11.AllNonSerialisedInventoryItemsForSale);

            Assert.Equal(3, productCategory12.AllNonSerialisedInventoryItemsForSale.Count);
            Assert.Contains(item12, productCategory12.AllNonSerialisedInventoryItemsForSale);
            Assert.Contains(item121, productCategory12.AllNonSerialisedInventoryItemsForSale);
            Assert.Contains(item122, productCategory12.AllNonSerialisedInventoryItemsForSale);

            Assert.Equal(1, productCategory111.AllNonSerialisedInventoryItemsForSale.Count);
            Assert.Contains(item111, productCategory111.AllNonSerialisedInventoryItemsForSale);

            Assert.Equal(1, productCategory121.AllNonSerialisedInventoryItemsForSale.Count);
            Assert.Contains(item121, productCategory121.AllNonSerialisedInventoryItemsForSale);

            Assert.Equal(1, productCategory122.AllNonSerialisedInventoryItemsForSale.Count);
            Assert.Contains(item122, productCategory122.AllNonSerialisedInventoryItemsForSale);
        }
    }
}
