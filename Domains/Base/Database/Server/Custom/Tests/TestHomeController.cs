﻿namespace Allors.Server.Controllers
{
    using Allors.Domain;
    using Allors.Meta;
    using Allors.Server;
    using Allors.Services;

    using Microsoft.AspNetCore.Mvc;

    public class TestHomeController : Controller
    {
        public TestHomeController(ISessionService sessionService)
        {
            this.Session = sessionService.Session;
        }

        private ISession Session { get; }

        [HttpPost]
        public IActionResult Pull()
        {
            var response = new PullResponseBuilder(this.Session.GetUser());
            var organisation = new Organisations(this.Session).FindBy(M.Organisation.Owner, this.Session.GetUser());
            response.AddObject("root", organisation, M.Organisation.AngularShareholders);
            return this.Ok(response.Build());
        }
    }
}