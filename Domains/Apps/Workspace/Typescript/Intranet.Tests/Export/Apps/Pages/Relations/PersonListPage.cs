namespace Intranet.Pages.Relations
{
    using Allors.Domain;
    using Allors.Meta;

    using Intranet.Tests;

    using OpenQA.Selenium;

    public class PersonListPage : MainPage
    {
        public PersonListPage(IWebDriver driver)
            : base(driver)
        {
        }

        public Input LastName => new Input(this.Driver, formControlName: "lastName");

        public Button Export => new Button(this.Driver, By.XPath("//button[.//mat-icon[contains(text(),'cloud_download')]]"));

        public Anchor AddNew => new Anchor(this.Driver, By.CssSelector("[mat-fab]"));

        public MaterialList List => new MaterialList(this.Driver);

        public PersonOverviewPage Select(Person person)
        {
            var listItem = this.List.FindListItem(person);
            listItem.Click();
            return new PersonOverviewPage(this.Driver);
        }
    }
}