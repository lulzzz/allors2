// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Users.cs" company="Allors bvba">
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
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Serialization;

    using Allors;

    /// <summary>
    /// A user of this application.
    /// </summary>
    public partial class Users
    {
        public const string GuestUserName = "Guest";
        public const string AdministratorUserName = "Administrator";

        public User GetUser(string userId)
        {
            // TODO: cache
            var user = this.FindBy(this.Meta.UserName, userId);
            return user;
        }

        public void SavePasswords(XmlWriter writer)
        {
            var usersWithPassword = this.Extent();
            usersWithPassword.Filter.AddExists(this.Meta.UserPasswordHash);

            var records = new List<Credentials.Record>();
            foreach (User user in usersWithPassword)
            {
                records.Add(new Credentials.Record
                                 {
                                     UserName = user.UserName,
                                     PasswordHash = user.UserPasswordHash
                                 });
            }

            var credentials = new Credentials { Records = records.ToArray() };
            var xmlSerializer = new XmlSerializer(typeof(Credentials));
            xmlSerializer.Serialize(writer, credentials);
        }

        public void LoadPasswords(XmlReader reader)
        {
            var xmlSerializer = new XmlSerializer(typeof(Credentials));
            var credentials = (Credentials)xmlSerializer.Deserialize(reader);
            foreach (var credential in credentials.Records)
            {
                User user = this.FindBy(this.Meta.UserName, credential.UserName);
                if (user != null)
                {
                    user.UserPasswordHash = credential.PasswordHash;
                }
            }
        }

        [XmlRoot("Credentials")]
        public class Credentials
        {
            [XmlElement("Credential", typeof(Record))]
            public Record[] Records { get; set; }

            public class Record
            {
                public string UserName { get; set; }

                public string PasswordHash { get; set; }
            }
        }
        
        private class CachedUser
        {
            public readonly string UserId;
            private readonly string objectId;

            public CachedUser(User user)
            {
                this.UserId = user.UserName.ToLower();
                this.objectId = user.Id.ToString();
            }

            public User GetUser(ISession session)
            {
                return (User)session.Instantiate(this.objectId);
            }
        }
    }
}