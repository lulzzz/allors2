// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserExtensions.cs" company="Allors bvba">
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

namespace Allors.Domain
{
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    using Allors.Services;

    using Microsoft.Extensions.DependencyInjection;

    public static partial class UserExtensions
    {
        public static void BaseOnPostBuild(this User @this, ObjectOnPostBuild method)
        {
            if (!@this.ExistNormalizedUserName)
            {
                @this.NormalizedUserName = @this.UserName?.ToUpperInvariant();
            }
        }
        
        public static void SetPassword(this User @this, string clearTextPassword)
        {
            var securityService = @this.Strategy.Session.ServiceProvider.GetRequiredService<IPasswordService>();
            var passwordHash = securityService.HashPassword(@this.UserName, clearTextPassword);
            @this.UserPasswordHash = passwordHash;
        }

        public static bool VerifyPassword(this User @this, string clearTextPassword)
        {
            if (string.IsNullOrWhiteSpace(clearTextPassword))
            {
                return false;
            }

            var securityService = @this.Strategy.Session.ServiceProvider.GetRequiredService<IPasswordService>();
            return securityService.VerifyHashedPassword(@this.UserName, @this.UserPasswordHash, clearTextPassword);
        }

        public static string SecurityHash(this User @this)
        {
            var accessControls = @this.AccessControlsWhereEffectiveUser;

            // TODO: Append a Salt 
            var idsWithVersion = string.Join(":", accessControls.OrderBy(v => v.Id).Select(v => v.Id + v.Strategy.ObjectVersion));

            var crypt = SHA256.Create();
            var hash = new StringBuilder();
            var crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(idsWithVersion), 0, Encoding.UTF8.GetByteCount(idsWithVersion));
            foreach (var theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}