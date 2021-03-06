// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParametrizedTests.cs" company="Allors bvba">
//   Copyright 2002-2009 Allors bvba.
// 
// Dual Licensed under
//   a) the General Public Licence v3 (GPL)
//   b) the Allors License
// 
// The GPL License is included in the file gpl.txt.
// The Allors License is an addendum to your contract.
// 
// Allors Platform is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// For more information visit http://www.allors.com/legal
// </copyright>
// <summary>
//   Defines the ApplicationTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tests
{
    using System.Collections.Generic;

    using Allors.Data;
    using Allors.Domain;
    using Allors.Meta;

    using Xunit;

    public class ParametrizedTests : DomainTest
    {
        [Fact]
        public void EqualsWithArguments()
        {
            var filter = new Filter(M.Person.ObjectType)
            {
                Predicate = new Equals { PropertyType = M.Person.FirstName, Parameter = "firstName" }
            };

            var arguments = new Dictionary<string, object> { { "firstName", "John" } };
            var queryExtent = filter.Build(this.Session, arguments);

            var extent = this.Session.Extent(M.Person.ObjectType);
            extent.Filter.AddEquals(M.Person.FirstName, "John");

            Assert.Equal(extent.ToArray(), queryExtent.ToArray());
        }

        [Fact]
        public void EqualsWithoutArguments()
        {
            var filter = new Filter(M.Person.ObjectType)
            {
                Predicate = new Equals { PropertyType = M.Person.FirstName, Parameter = "firstName" }
            };

            var queryExtent = filter.Build(this.Session);

            var extent = this.Session.Extent(M.Person.ObjectType);

            Assert.Equal(extent.ToArray(), queryExtent.ToArray());
        }

        [Fact]
        public void AndWithArguments()
        {
            // select from Person where FirstName='John' and LastName='Doe'
            var filter = new Filter(M.Person.ObjectType)
            {
                Predicate = new And
                {
                    Operands = new IPredicate[]
                                {
                                    new Equals
                                        {
                                            PropertyType = M.Person.FirstName,
                                            Parameter = "firstName"
                                        },
                                    new Equals
                                        {
                                            PropertyType = M.Person.LastName,
                                            Parameter = "lastName"
                                        }
                                }
                }
            };

            var arguments = new Dictionary<string, object>
                                {
                                    { "firstName", "John" },
                                    { "lastName", "Doe" }
                                };
            var queryExtent = filter.Build(this.Session, arguments);

            var extent = this.Session.Extent(M.Person.ObjectType);
            var and = extent.Filter.AddAnd();
            and.AddEquals(M.Person.FirstName, "John");
            and.AddEquals(M.Person.LastName, "Doe");

            Assert.Equal(extent.ToArray(), queryExtent.ToArray());
        }

        [Fact]
        public void AndWithoutArguments()
        {
            // select from Person where FirstName='John' and LastName='Doe'
            var filter = new Filter(M.Person.ObjectType)
            {
                Predicate = new And
                {
                    Operands = new IPredicate[]
                        {
                            new Equals
                                {
                                    PropertyType = M.Person.FirstName,
                                    Parameter = "firstName"
                                },
                            new Equals
                                {
                                    PropertyType = M.Person.LastName,
                                    Parameter = "lastName"
                                }
                        }
                }
            };

            {
                var arguments = new Dictionary<string, object>
                                    {
                                        { "firstName", "John" },
                                    };
                var queryExtent = filter.Build(this.Session, arguments);

                var extent = this.Session.Extent(M.Person.ObjectType);
                extent.Filter.AddEquals(M.Person.FirstName, "John");

                Assert.Equal(extent.ToArray(), queryExtent.ToArray());

            }

            {
                var queryExtent = filter.Build(this.Session);

                var extent = this.Session.Extent(M.Person.ObjectType);

                Assert.Equal(extent.ToArray(), queryExtent.ToArray());
            }
        }


        [Fact]
        public void NestedWithArguments()
        {
            var filter = new Filter(M.Organisation.ObjectType)
            {
                Predicate = new ContainedIn
                {
                    PropertyType = M.Organisation.Employees,
                    Extent = new Filter(M.Person.ObjectType)
                    {
                        Predicate = new Equals
                        {
                            PropertyType = M.Person.Gender,
                            Parameter = "gender"
                        }
                    }
                }
            };

            var male = new Genders(this.Session).Male;

            var arguments = new Dictionary<string, object> { { "gender", male } };
            var queryExtent = filter.Build(this.Session, arguments);

            var employees = this.Session.Extent(M.Person.ObjectType);
            employees.Filter.AddEquals(M.Person.Gender, male);
            var extent = this.Session.Extent(M.Organisation.ObjectType);
            extent.Filter.AddContainedIn(M.Organisation.Employees, employees);

            Assert.Equal(extent.ToArray(), queryExtent.ToArray());
        }

        [Fact]
        public void NestedWithoutArguments()
        {
            var filter = new Filter(M.Organisation.ObjectType)
            {
                Predicate = new ContainedIn
                {
                    PropertyType = M.Organisation.Employees,
                    Extent = new Filter(M.Person.ObjectType)
                    {
                        Predicate = new Equals
                        {
                            PropertyType = M.Person.Gender,
                            Parameter = "gender"
                        }
                    }
                }
            };

            var arguments = new Dictionary<string, object>();
            var queryExtent = filter.Build(this.Session, arguments);

            var extent = this.Session.Extent(M.Organisation.ObjectType);

            Assert.Equal(extent.ToArray(), queryExtent.ToArray());
        }

        [Fact]
        public void AndNestedContainedInWithoutArguments()
        {
            var filter = new Filter(M.Organisation.ObjectType)
            {
                Predicate = new And
                {
                    Operands = new IPredicate[]
                    {
                        new ContainedIn
                        {
                            PropertyType = M.Organisation.Employees,
                            Extent = new Filter(M.Person.ObjectType)
                            {
                                Predicate = new ContainedIn
                                {
                                    PropertyType = M.Person.Gender,
                                    Parameter = "gender"
                                }
                            }
                        }
                    }
                }
            };

            var arguments = new Dictionary<string, object>();
            var queryExtent = filter.Build(this.Session, arguments);

            var extent = this.Session.Extent(M.Organisation.ObjectType);

            Assert.Equal(extent.ToArray(), queryExtent.ToArray());
        }

        [Fact]
        public void AndNestedContainsWithoutArguments()
        {
            var filter = new Filter(M.Organisation.ObjectType)
                             {
                                 Predicate = new And
                                                 {
                                                     Operands = new IPredicate[]
                                                                    {
                                                                        new ContainedIn
                                                                            {
                                                                                PropertyType = M.Organisation.Employees,
                                                                                Extent = new Filter(M.Person.ObjectType)
                                                                                             {
                                                                                                 Predicate = new Contains
                                                                                                                 {
                                                                                                                     PropertyType = M.Person.Gender,
                                                                                                                     Parameter = "gender"
                                                                                                                 }
                                                                                             }
                                                                            }
                                                                    }
                                                 }
                             };

            var arguments = new Dictionary<string, object>();
            var queryExtent = filter.Build(this.Session, arguments);

            var extent = this.Session.Extent(M.Organisation.ObjectType);

            Assert.Equal(extent.ToArray(), queryExtent.ToArray());
        }

    }
}
