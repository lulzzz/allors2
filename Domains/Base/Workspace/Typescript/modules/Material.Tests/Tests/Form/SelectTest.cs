namespace Tests
{
    using System.Linq;

    using Allors.Domain;
    using Allors.Meta;

    using Angular;
    using Pages.Relations;

    using Xunit;

    [Collection("Test collection")]
    public class SelectTest : Test
    {
        private readonly FormPage page;

        public SelectTest(TestFixture fixture)
            : base(fixture)
        {
            var dashboard = this.Login();
            this.page = dashboard.Sidenav.NavigateToForm();
        }

        [Fact]
        public void Initial()
        {
            var jane = new People(this.Session).FindBy(M.Person.UserName, "jane@doe.org");

            var before = new Datas(this.Session).Extent().ToArray();

            this.page.AutoCompleteFilter.Select("jane", "jane@doe.org");

            this.page.Save.Click();

            this.Driver.WaitForAngular();
            this.Session.Rollback();

            var after = new Datas(this.Session).Extent().ToArray();

            Assert.Equal(after.Length, before.Length + 1);

            var data = after.Except(before).First();

            Assert.Equal(jane, data.AutocompleteFilter);
        }
    }
}
