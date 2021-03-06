namespace Server.Tests
{
    using System;

    using Allors.Domain;
    using Allors.Server.Protocol.Sync;

    using Xunit;

    [Collection("Server")]
    public class SyncTests : ServerTest
    {
        [Fact]
        public async void ExistingObject()
        {
            var administrator = new Users(this.Session).GetUser("administrator");
            await this.SignIn(administrator);

            var people = new People(this.Session).Extent();
            var person = people[0];

            var uri = new Uri(@"Database/Sync", UriKind.Relative);

            var syncRequest = new SyncRequest
                                  {
                                      Objects = new[] { person.Id.ToString() }
                                  };
            var response = await this.PostAsJsonAsync(uri, syncRequest);
            var syncResponse = await this.ReadAsAsync<SyncResponse>(response);
            
            Assert.Single(syncResponse.Objects);
            var syncObject = syncResponse.Objects[0];

            Assert.Equal(person.Id.ToString(), syncObject.I);
            Assert.Equal(person.GetType().Name, syncObject.T);
            Assert.Equal(person.Strategy.ObjectVersion.ToString(), syncObject.V);
        }


        [Fact]
        public async void DeletedObject()
        {
            var administrator = new Users(this.Session).GetUser("administrator");
            await this.SignIn(administrator);

            var organisation = new OrganisationBuilder(this.Session).Build();
            this.Session.Commit();
            
            var uri = new Uri(@"Database/Sync", UriKind.Relative);

            var syncRequest = new SyncRequest
                                  {
                                      Objects = new[] { organisation.Id.ToString() }
                                  };
            var response = await this.PostAsJsonAsync(uri, syncRequest);

            organisation.Strategy.Delete();

            this.Session.Commit();

            response = await this.PostAsJsonAsync(uri, syncRequest);
            var syncResponse = await this.ReadAsAsync<SyncResponse>(response);
            
            Assert.Empty(syncResponse.Objects);
        }
    }
}