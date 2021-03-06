// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnifiedGood.cs" company="Allors bvba">
//   Copyright 2002-2012 Allors bvba.
// Dual Licensed under
//   a) the General Public Licence v3 (GPL)
//   b) the Allors License
// The GPL License is included in the file gpl.txt.
// The Allors License is an addendum to your contract.
// Allors Applications is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// For more information visit http://www.allors.com/legal
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Allors.Domain
{
    using System;
    using System.Linq;

    using Allors.Meta;

    public partial class UnifiedGood
    {
        private bool IsDeletable => !this.ExistDeploymentsWhereProductOffering && 
                                    !this.ExistEngagementItemsWhereProduct && 
                                    !this.ExistGeneralLedgerAccountsWhereCostUnitsAllowed && 
                                    !this.ExistGeneralLedgerAccountsWhereDefaultCostUnit && 
                                    !this.ExistQuoteItemsWhereProduct && 
                                    !this.ExistShipmentItemsWhereGood && 
                                    !this.ExistWorkEffortGoodStandardsWhereGood && 
                                    !this.ExistMarketingPackageWhereProductsUsedIn && 
                                    !this.ExistMarketingPackagesWhereProduct && 
                                    !this.ExistOrganisationGlAccountsWhereProduct && 
                                    !this.ExistProductConfigurationsWhereProductsUsedIn && 
                                    !this.ExistProductConfigurationsWhereProduct && 
                                    !this.ExistRequestItemsWhereProduct && 
                                    !this.ExistSalesInvoiceItemsWhereProduct && 
                                    !this.ExistSalesOrderItemsWhereProduct && 
                                    !this.ExistWorkEffortTypesWhereProductToProduce && 
                                    !this.ExistEngagementItemsWhereProduct && 
                                    !this.ExistProductWhereVariant;

        public void AppsOnBuild(ObjectOnBuild method)
        {
            if (!this.ExistInventoryItemKind)
            {
                this.InventoryItemKind = new InventoryItemKinds(this.Strategy.Session).NonSerialised;
            }

            if (!this.ExistUnitOfMeasure)
            {
                this.UnitOfMeasure = new UnitsOfMeasure(this.strategy.Session).Piece;
            }

            if (!this.ExistDefaultFacility)
            {
                this.DefaultFacility = this.strategy.Session.GetSingleton().Settings.DefaultFacility;
            }
        }

        public void AppsOnPreDerive(ObjectOnPreDerive method)
        {
            var derivation = method.Derivation;

            if (derivation.ChangeSet.Associations.Contains(this.Id))
            {
                if (this.ExistInventoryItemsWherePart)
                {
                    foreach (InventoryItem inventoryItem in this.InventoryItemsWherePart)
                    {
                        derivation.AddDependency(this, inventoryItem);
                    }
                }
            }
        }

        public void AppsOnDerive(ObjectOnDerive method)
        {
            var derivation = method.Derivation;
            var defaultLocale = this.strategy.Session.GetSingleton().DefaultLocale;
            var settings = this.strategy.Session.GetSingleton().Settings;

            if (derivation.HasChangedRoles(this, new RoleType[] { this.Meta.UnitOfMeasure, this.Meta.DefaultFacility }))
            {
                this.SyncDefaultInventoryItem();
            }

            var identifications = this.ProductIdentifications;
            identifications.Filter.AddEquals(M.ProductIdentification.ProductIdentificationType, new ProductIdentificationTypes(this.strategy.Session).Good);
            var goodNumber = identifications.FirstOrDefault();

            if (goodNumber == null && settings.UseProductNumberCounter)
            {
                this.AddProductIdentification(new ProductNumberBuilder(this.strategy.Session)
                    .WithIdentification(settings.NextProductNumber())
                    .WithProductIdentificationType(new ProductIdentificationTypes(this.strategy.Session).Good).Build());
            }

            if (!this.ExistProductIdentifications)
            {
                derivation.Validation.AssertExists(this, M.Good.ProductIdentifications);
            }

            if (this.LocalisedNames.Any(x => x.Locale.Equals(defaultLocale)))
            {
                this.Name = this.LocalisedNames.First(x => x.Locale.Equals(defaultLocale)).Text;
            }

            if (this.LocalisedDescriptions.Any(x => x.Locale.Equals(defaultLocale)))
            {
                this.Description = this.LocalisedDescriptions.First(x => x.Locale.Equals(defaultLocale)).Text;
            }

            foreach (SupplierOffering supplierOffering in this.SupplierOfferingsWherePart)
            {
                if (supplierOffering.FromDate <= DateTime.UtcNow
                    && (!supplierOffering.ExistThroughDate || supplierOffering.ThroughDate >= DateTime.UtcNow))
                {
                    this.AddSuppliedBy(supplierOffering.Supplier);
                }

                if (supplierOffering.FromDate > DateTime.UtcNow
                    || (supplierOffering.ExistThroughDate && supplierOffering.ThroughDate < DateTime.UtcNow))
                {
                    this.RemoveSuppliedBy(supplierOffering.Supplier);
                }
            }

            this.DeriveVirtualProductPriceComponent();
            this.DeriveProductCharacteristics(derivation);
            this.DeriveQuantityOnHand();
            this.DeriveAvailableToPromise();
            this.DeriveQuantityCommittedOut();
            this.DeriveQuantityExpectedIn();
        }

        public void DeriveVirtualProductPriceComponent()
        {
            if (!this.ExistProductWhereVariant)
            {
                this.RemoveVirtualProductPriceComponents();
            }

            if (this.ExistVariants)
            {
                this.RemoveVirtualProductPriceComponents();

                var priceComponents = this.PriceComponentsWhereProduct;

                foreach (Good product in this.Variants)
                {
                    foreach (PriceComponent priceComponent in priceComponents)
                    {
                        product.AddVirtualProductPriceComponent(priceComponent);

                        if (priceComponent is BasePrice basePrice && !priceComponent.ExistProductFeature)
                        {
                            product.AddToBasePrice(basePrice);
                        }
                    }
                }
            }
        }

        public void AppsDelete(DeletableDelete method)
        {
            if (this.IsDeletable)
            {
                foreach (LocalisedText localisedText in this.LocalisedNames)
                {
                    localisedText.Delete();
                }

                foreach (LocalisedText localisedText in this.LocalisedDescriptions)
                {
                    localisedText.Delete();
                }

                foreach (PriceComponent priceComponent in this.VirtualProductPriceComponents)
                {
                    priceComponent.Delete();
                }

                foreach (EstimatedProductCost estimatedProductCosts in this.EstimatedProductCosts)
                {
                    estimatedProductCosts.Delete();
                }
            }
        }

        private void SyncDefaultInventoryItem()
        {
            if (this.InventoryItemKind.IsNonSerialized)
            {
                var inventoryItems = this.InventoryItemsWherePart;

                if (!inventoryItems.Any(i => i.Facility.Equals(this.DefaultFacility) && i.UnitOfMeasure.Equals(this.UnitOfMeasure)))
                {
                    var inventoryItem = (InventoryItem)new NonSerialisedInventoryItemBuilder(this.Strategy.Session)
                        .WithFacility(this.DefaultFacility)
                        .WithUnitOfMeasure(this.UnitOfMeasure)
                        .WithPart(this)
                        .Build();
                }
            }
        }

        private void DeriveProductCharacteristics(IDerivation derivation)
        {
            var characteristicsToDelete = this.SerialisedItemCharacteristics.ToList();

            if (this.ExistProductType)
            {
                foreach (SerialisedItemCharacteristicType characteristicType in this.ProductType.SerialisedItemCharacteristicTypes)
                {
                    var characteristic = this.SerialisedItemCharacteristics.FirstOrDefault(v => Equals(v.SerialisedItemCharacteristicType, characteristicType));
                    if (characteristic == null)
                    {
                        this.AddSerialisedItemCharacteristic(
                            new SerialisedItemCharacteristicBuilder(this.strategy.Session)
                                .WithSerialisedItemCharacteristicType(characteristicType)
                                .Build());
                    }
                    else
                    {
                        characteristicsToDelete.Remove(characteristic);
                    }
                }
            }

            foreach (SerialisedItemCharacteristic characteristic in characteristicsToDelete)
            {
                this.RemoveSerialisedItemCharacteristic(characteristic);
            }
        }

        private void DeriveQuantityOnHand()
        {
            this.QuantityOnHand = 0;

            foreach (InventoryItem inventoryItem in this.InventoryItemsWherePart)
            {
                if (inventoryItem is NonSerialisedInventoryItem nonSerialisedItem)
                {
                    this.QuantityOnHand += nonSerialisedItem.QuantityOnHand;
                }
                else if (inventoryItem is SerialisedInventoryItem serialisedItem)
                {
                    this.QuantityOnHand += serialisedItem.QuantityOnHand;
                }
            }
        }

        private void DeriveAvailableToPromise()
        {
            this.AvailableToPromise = 0;

            foreach (InventoryItem inventoryItem in this.InventoryItemsWherePart)
            {
                if (inventoryItem is NonSerialisedInventoryItem nonSerialisedItem)
                {
                    this.AvailableToPromise += nonSerialisedItem.AvailableToPromise;
                }
                else if (inventoryItem is SerialisedInventoryItem serialisedItem)
                {
                    this.AvailableToPromise += serialisedItem.AvailableToPromise;
                }
            }
        }

        private void DeriveQuantityCommittedOut()
        {
            this.QuantityCommittedOut = 0;

            foreach (InventoryItem inventoryItem in this.InventoryItemsWherePart)
            {
                if (inventoryItem is NonSerialisedInventoryItem nonSerialised)
                {
                    this.QuantityCommittedOut += nonSerialised.QuantityCommittedOut;
                }
            }
        }

        private void DeriveQuantityExpectedIn()
        {
            this.QuantityExpectedIn = 0;

            foreach (InventoryItem inventoryItem in this.InventoryItemsWherePart)
            {
                if (inventoryItem is NonSerialisedInventoryItem nonSerialised)
                {
                    this.QuantityExpectedIn += nonSerialised.QuantityExpectedIn;
                }
            }
        }
    }
}