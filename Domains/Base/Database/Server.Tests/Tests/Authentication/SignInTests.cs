namespace Server.Tests
{
    using System;

    using Allors.Domain;
    using Allors.Server;

    using Microsoft.AspNetCore.Identity;
    using Xunit;

    [Collection("Server")]

    public class SignInTests : ServerTest
    {
        public SignInTests()
        {
            var passwordHasher = new PasswordHasher<string>();

            new PersonBuilder(this.Session).WithUserName("John").Build();

            var hash = passwordHasher.HashPassword("Jane", "p@ssw0rd");
            new PersonBuilder(this.Session).WithUserName("Jane").WithUserPasswordHash(hash).Build();
            this.Session.Commit();
        }

        [Fact]
        public async void CorrectUserAndPassword()
        {
            var args = new AuthenticationTokenRequest
                            {
                                UserName = "Jane",
                                Password = "p@ssw0rd"
                            };

            var uri = new Uri("Authentication/Token", UriKind.Relative);
            var response = await this.PostAsJsonAsync(uri, args);
            var siginInResponse = await this.ReadAsAsync<AuthenticationTokenResponse>(response);

            Assert.True(siginInResponse.Authenticated);
        }


        [Fact]
        public async void NonExistingUser()
        {
            var args = new AuthenticationTokenRequest
                            {
                                UserName = "Jeff",
                                Password = "p@ssw0rd"
                            };

            var uri = new Uri("Authentication/Token", UriKind.Relative);
            var response = await this.PostAsJsonAsync(uri, args);
            var siginInResponse = await this.ReadAsAsync<AuthenticationTokenResponse>(response);

            Assert.False(siginInResponse.Authenticated);
        }

        [Fact]
        public async void EmptyStringPassword()
        {
            var args = new AuthenticationTokenRequest
                            {
                                UserName = "John",
                                Password = ""
                            };

            var uri = new Uri("Authentication/Token", UriKind.Relative);
            var response = await this.PostAsJsonAsync(uri, args);
            var siginInResponse = await this.ReadAsAsync<AuthenticationTokenResponse>(response);

            Assert.False(siginInResponse.Authenticated);
        }

        [Fact]
        public async void NoPassword()
        {
            var args = new AuthenticationTokenRequest
                            {
                                UserName = "John"
                            };

            var uri = new Uri("Authentication/Token", UriKind.Relative);
            var response = await this.PostAsJsonAsync(uri, args);
            var siginInResponse = await this.ReadAsAsync<AuthenticationTokenResponse>(response);

            Assert.False(siginInResponse.Authenticated);
        }
    }
}