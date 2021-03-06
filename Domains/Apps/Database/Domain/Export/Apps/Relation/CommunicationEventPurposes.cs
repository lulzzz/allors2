// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommunicationEventPurposes.cs" company="Allors bvba">
//   Copyright 2002-2012 Allors bvba.
// Dual Licensed under
//   a) the General Public Licence v3 (GPL)
//   b) the Allors License
// The GPL License is included in the file gpl.txt.
// The Allors License is an addendum to your contract.
// Allors Applications is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// For more information visit http://www.allors.com/legal
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Allors.Domain
{
    using System;

    public partial class CommunicationEventPurposes
    {
        private static readonly Guid SupportCallId = new Guid("376805EE-5CBE-4cf0-95F4-F2649174FCBF");
        private static readonly Guid InquiryId = new Guid("C038D09A-5365-42ec-BAF9-A2D7D1E9E783");
        private static readonly Guid CustomerServiceCallId = new Guid("C31D91C7-1A96-47d5-8E85-76B89CED8E79");
        private static readonly Guid SalesFollowUpId = new Guid("8C95CE16-43ED-4450-B896-F6DBF66BC271");
        private static readonly Guid AppointmentId = new Guid("9C572283-BAEE-4F36-AD26-F0B22EDE0AD6");
        private static readonly Guid MeetingId = new Guid("4A953F5A-3E35-4ba7-9BA7-9E636908E00E");
        private static readonly Guid SeminarId = new Guid("25328926-7028-4e7d-A35F-DADDBD9EE926");
        private static readonly Guid ActivityRequestId = new Guid("D93A0B3C-0641-4b2a-B966-26964A505F68");
        private static readonly Guid ConferenceId = new Guid("475C801C-4965-49d8-B62A-5B3FDFEE2F72");
        private static readonly Guid SalesMeetingId = new Guid("344920EA-0903-4213-BC7C-837A74089706");
        private static readonly Guid InterviewId = new Guid("7143C121-1DF5-4a92-90BA-10800022BA12");

        private UniquelyIdentifiableSticky<CommunicationEventPurpose> cache;

        public CommunicationEventPurpose SupportCall => this.Cache[SupportCallId];

        public CommunicationEventPurpose Inquiry => this.Cache[InquiryId];

        public CommunicationEventPurpose CustomerServiceCall => this.Cache[CustomerServiceCallId];

        public CommunicationEventPurpose SalesFollowUp => this.Cache[SalesFollowUpId];

        public CommunicationEventPurpose Appointment => this.Cache[AppointmentId];

        public CommunicationEventPurpose Meeting => this.Cache[MeetingId];

        public CommunicationEventPurpose Seminar => this.Cache[SeminarId];

        public CommunicationEventPurpose ActivityRequest => this.Cache[ActivityRequestId];

        public CommunicationEventPurpose Conference => this.Cache[ConferenceId];

        public CommunicationEventPurpose SalesMeeting => this.Cache[SalesMeetingId];

        public CommunicationEventPurpose Interview => this.Cache[InterviewId];

        private UniquelyIdentifiableSticky<CommunicationEventPurpose> Cache => this.cache ?? (this.cache = new UniquelyIdentifiableSticky<CommunicationEventPurpose>(this.Session));

        protected override void AppsSetup(Setup setup)
        {
            base.AppsSetup(setup);

            var dutchLocale = new Locales(this.Session).DutchNetherlands;

            new CommunicationEventPurposeBuilder(this.Session)
                .WithName("Support Call")
                .WithLocalisedName(new LocalisedTextBuilder(this.Session).WithText("Support call").WithLocale(dutchLocale).Build())
                .WithUniqueId(SupportCallId)
                .WithIsActive(true)
                .Build();
            
            new CommunicationEventPurposeBuilder(this.Session)
                .WithName("Inquiry")
                .WithLocalisedName(new LocalisedTextBuilder(this.Session).WithText("Vraag").WithLocale(dutchLocale).Build())
                .WithUniqueId(InquiryId)
                .WithIsActive(true)
                .Build();
            
            new CommunicationEventPurposeBuilder(this.Session)
                .WithName("CustomerServiceCall")
                .WithLocalisedName(new LocalisedTextBuilder(this.Session).WithText("Klantendienst").WithLocale(dutchLocale).Build())
                .WithUniqueId(CustomerServiceCallId)
                .WithIsActive(true)
                .Build();
            
            new CommunicationEventPurposeBuilder(this.Session)
                .WithName("SalesFollowUp")
                .WithLocalisedName(new LocalisedTextBuilder(this.Session).WithText("Verkoop opvolging").WithLocale(dutchLocale).Build())
                .WithUniqueId(SalesFollowUpId)
                .WithIsActive(true)
                .Build();

            new CommunicationEventPurposeBuilder(this.Session)
                .WithName("Appointment")
                .WithLocalisedName(new LocalisedTextBuilder(this.Session).WithText("Afspraak").WithLocale(dutchLocale).Build())
                .WithUniqueId(AppointmentId)
                .WithIsActive(true)
                .Build();
            
            new CommunicationEventPurposeBuilder(this.Session)
                .WithName("Meeting")
                .WithLocalisedName(new LocalisedTextBuilder(this.Session).WithText("Vergadering").WithLocale(dutchLocale).Build())
                .WithUniqueId(MeetingId)
                .WithIsActive(true)
                .Build();
            
            new CommunicationEventPurposeBuilder(this.Session)
                .WithName("Seminar")
                .WithLocalisedName(new LocalisedTextBuilder(this.Session).WithText("Seminar").WithLocale(dutchLocale).Build())
                .WithUniqueId(SeminarId)
                .WithIsActive(true)
                .Build();
            
            new CommunicationEventPurposeBuilder(this.Session)
                .WithName("ActivityRequest")
                .WithLocalisedName(new LocalisedTextBuilder(this.Session).WithText("Aanvraag activiteit").WithLocale(dutchLocale).Build())
                .WithUniqueId(ActivityRequestId)
                .WithIsActive(true)
                .Build();
            
            new CommunicationEventPurposeBuilder(this.Session)
                .WithName("Conference")
                .WithLocalisedName(new LocalisedTextBuilder(this.Session).WithText("Conferencie").WithLocale(dutchLocale).Build())
                .WithUniqueId(ConferenceId)
                .WithIsActive(true)
                .Build();
            
            new CommunicationEventPurposeBuilder(this.Session)
                .WithName("SalesMeeting")
                .WithLocalisedName(new LocalisedTextBuilder(this.Session).WithText("Verkoops meeting").WithLocale(dutchLocale).Build())
                .WithUniqueId(SalesMeetingId)
                .WithIsActive(true)
                .Build();
            
            new CommunicationEventPurposeBuilder(this.Session)
                .WithName("Interview")
                .WithLocalisedName(new LocalisedTextBuilder(this.Session).WithText("Interview").WithLocale(dutchLocale).Build())
                .WithUniqueId(InterviewId)
                .WithIsActive(true)
                .Build();
        }
    }
}
