namespace Angular.Material
{
    using System.Diagnostics.CodeAnalysis;

    using Allors.Meta;

    using Angular;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class MaterialChips : Component
    {
        public MaterialChips(IWebDriver driver, RoleType roleType)
            : base(driver)
        {
            this.Selector = By.CssSelector($"a-mat-chips *[data-allors-roletype='{roleType.IdAsNumberString}']");
        }

        public By Selector { get; }

        public IWebElement Input => this.Driver.FindElement(new ByChained(this.Selector, By.CssSelector("input")));
        
        public void Add(string value, string selection = null)
        {
            this.Driver.WaitForAngular();
            this.ScrollToElement(this.Input);
            this.Input.Clear();
            this.Input.SendKeys(value);
            
            this.Driver.WaitForAngular();
            var optionSelector = By.CssSelector($"mat-option[data-allors-option-display='{selection ?? value}'] span");
            var option = this.Driver.FindElement(optionSelector);
            option.Click();
        }

        public void Remove(string value)
        {
            this.Driver.WaitForAngular();

            var listItem = this.Driver.FindElement(new ByChained(this.Selector, By.CssSelector($"mat-chip[data-allors-chip-display='{value}'] mat-icon")));
            this.ScrollToElement(listItem);
            listItem.Click();
        }
    }

    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed. Suppression is OK here.")]
    public class MaterialChips<T> : MaterialChips where T : Page
    {
        public MaterialChips(T page, RoleType roleType)
            : base(page.Driver, roleType)
        {
            this.Page = page;
        }

        public T Page { get; }

        public new T Add(string value, string selection = null)
        {
            base.Add(value, selection);
            return this.Page;
        }

        public new T Remove(string value)
        {
            base.Remove(value);
            return this.Page;
        }
    }
}
