﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseMediaController.cs" company="Allors bvba">
//   Copyright 2002-2017 Allors bvba.
//
// Dual Licensed under
//   a) the General Public Licence v3 (GPL)
//   b) the Allors License
//
// The GPL License is included in the file gpl.txt.
// The Allors License is an addendum to your contract.
//
// Allors Applications is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// For more information visit http://www.allors.com/legal
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Allors.Server
{
    using System;

    using Allors.Domain;
    using Allors.Meta;
    using Allors.Services;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public abstract partial class BaseMediaController : Controller
    {
        private const int OneYearInSeconds = 60 * 60 * 24 * 356;

        protected BaseMediaController(ISessionService sessionService)
        {
            this.Session = sessionService.Session;
        }

        private ISession Session { get; }

        [AllowAnonymous]
        public virtual ActionResult Download(string id)
        {
            if (Guid.TryParse(id, out var uniqueId))
            {
                var media = new Medias(this.Session).FindBy(M.Media.UniqueId, uniqueId);
                if (media != null)
                {
                    return this.RedirectToAction("DownloadWithRevision", new { id, revision = media.Revision });
                }
            }

            return this.NotFound("Media with unique id " + id + " not found.");
        }

        [AllowAnonymous]
        [ResponseCache(Location = ResponseCacheLocation.Client, Duration = OneYearInSeconds, VaryByQueryKeys = new[] { "revision" })]
        public virtual ActionResult DownloadWithRevision(string id, string revision)
        {
            if (Guid.TryParse(id, out var uniqueId))
            {
                var media = new Medias(this.Session).FindBy(M.Media.UniqueId, uniqueId);
                if (media != null)
                {
                    if (media.MediaContent?.Data == null)
                    {
                        return this.NoContent();
                    }

                    return this.File(media.MediaContent.Data, media.MediaContent.Type, media.FileName);
                }
            }

            return this.NotFound("Media with unique id " + id + " not found.");
        }
    }
}