﻿namespace Allors.Domain
{
    using System;

    using Allors.Meta;

    public partial class Settingses
    {
        protected override void AppsPrepare(Setup setup)
        {
            base.AppsPrepare(setup);

            setup.AddDependency(this.ObjectType, M.Singleton);
            setup.AddDependency(this.ObjectType, M.InventoryStrategy);
        }

        protected override void AppsSetup(Setup setup)
        {
            var settings = new SettingsBuilder(this.Session)
                .WithInventoryStrategy(new InventoryStrategies(this.Session).Standard)
                .WithSkuPrefix("Sku")
                .WithSkuCounter(new CounterBuilder(this.Session).WithUniqueId(Guid.NewGuid()).WithValue(0).Build())
                .WithSerialisedItemPrefix("S")
                .WithSerialisedItemCounter(new CounterBuilder(this.Session).WithUniqueId(Guid.NewGuid()).WithValue(0).Build())
                .WithPreferredCurrency(new Currencies(this.Session).FindBy(M.Currency.IsoCode, "EUR"))
                .WithProductNumberCounter(new CounterBuilder(this.Session).WithUniqueId(Guid.NewGuid()).WithValue(0).Build())
                .WithProductNumberPrefix("art-")
                .WithUseProductNumberCounter(true)
                .WithPartNumberCounter(new CounterBuilder(this.Session).WithUniqueId(Guid.NewGuid()).WithValue(0).Build())
                .WithPartNumberPrefix("part-")
                .WithUsePartNumberCounter(true)
                .Build();

            this.Session.GetSingleton().Settings = settings;
        }
    }
}
