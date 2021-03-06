namespace Pages
{
    using Angular;

    using OpenQA.Selenium;

    using Tests;

    public abstract class MainPage : Page
    {
        protected MainPage(IWebDriver driver) : base(driver)
        {
        }
        
        public Sidenav Sidenav => new Sidenav(this.Driver);
    }
}
