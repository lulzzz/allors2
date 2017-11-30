import { SessionObject } from "@allors/framework";
import { User } from './User.g';
import { Party } from './Party.g';
import { AutomatedAgentVersion } from './AutomatedAgentVersion.g';
import { TaskList } from './TaskList.g';
import { NotificationList } from './NotificationList.g';
import { Locale } from './Locale.g';
import { PostalAddress } from './PostalAddress.g';
import { TelecommunicationsNumber } from './TelecommunicationsNumber.g';
import { Qualification } from './Qualification.g';
import { ContactMechanism } from './ContactMechanism.g';
import { OrganisationContactRelationship } from './OrganisationContactRelationship.g';
import { Person } from './Person.g';
import { PartyContactMechanism } from './PartyContactMechanism.g';
import { BillingAccount } from './BillingAccount.g';
import { PartySkill } from './PartySkill.g';
import { PartyClassification } from './PartyClassification.g';
import { BankAccount } from './BankAccount.g';
import { EmailAddress } from './EmailAddress.g';
import { ShipmentMethod } from './ShipmentMethod.g';
import { Resume } from './Resume.g';
import { ElectronicAddress } from './ElectronicAddress.g';
import { Media } from './Media.g';
import { CreditCard } from './CreditCard.g';
import { PaymentMethod } from './PaymentMethod.g';
import { Currency } from './Currency.g';
import { VatRegime } from './VatRegime.g';
import { DunningType } from './DunningType.g';
export declare class AutomatedAgent extends SessionObject implements User, Party {
    readonly CanReadCurrentVersion: boolean;
    readonly CanWriteCurrentVersion: boolean;
    CurrentVersion: AutomatedAgentVersion;
    readonly CanReadAllVersions: boolean;
    readonly CanWriteAllVersions: boolean;
    AllVersions: AutomatedAgentVersion[];
    AddAllVersion(value: AutomatedAgentVersion): void;
    RemoveAllVersion(value: AutomatedAgentVersion): void;
    readonly CanReadUserName: boolean;
    readonly CanWriteUserName: boolean;
    UserName: string;
    readonly CanReadNormalizedUserName: boolean;
    readonly CanWriteNormalizedUserName: boolean;
    NormalizedUserName: string;
    readonly CanReadUserEmail: boolean;
    readonly CanWriteUserEmail: boolean;
    UserEmail: string;
    readonly CanReadUserEmailConfirmed: boolean;
    readonly CanWriteUserEmailConfirmed: boolean;
    UserEmailConfirmed: boolean;
    readonly CanReadTaskList: boolean;
    readonly TaskList: TaskList;
    readonly CanReadNotificationList: boolean;
    readonly CanWriteNotificationList: boolean;
    NotificationList: NotificationList;
    readonly CanReadLocale: boolean;
    readonly CanWriteLocale: boolean;
    Locale: Locale;
    readonly CanReadPartyName: boolean;
    readonly CanWritePartyName: boolean;
    PartyName: string;
    readonly CanReadGeneralCorrespondence: boolean;
    readonly GeneralCorrespondence: PostalAddress;
    readonly CanReadYTDRevenue: boolean;
    readonly YTDRevenue: number;
    readonly CanReadLastYearsRevenue: boolean;
    readonly LastYearsRevenue: number;
    readonly CanReadBillingInquiriesFax: boolean;
    readonly BillingInquiriesFax: TelecommunicationsNumber;
    readonly CanReadQualifications: boolean;
    readonly CanWriteQualifications: boolean;
    Qualifications: Qualification[];
    AddQualification(value: Qualification): void;
    RemoveQualification(value: Qualification): void;
    readonly CanReadHomeAddress: boolean;
    readonly HomeAddress: ContactMechanism;
    readonly CanReadInactiveOrganisationContactRelationships: boolean;
    readonly InactiveOrganisationContactRelationships: OrganisationContactRelationship[];
    readonly CanReadSalesOffice: boolean;
    readonly SalesOffice: ContactMechanism;
    readonly CanReadInactiveContacts: boolean;
    readonly InactiveContacts: Person[];
    readonly CanReadInactivePartyContactMechanisms: boolean;
    readonly InactivePartyContactMechanisms: PartyContactMechanism[];
    readonly CanReadOrderInquiriesFax: boolean;
    readonly OrderInquiriesFax: TelecommunicationsNumber;
    readonly CanReadCurrentSalesReps: boolean;
    readonly CurrentSalesReps: Person[];
    readonly CanReadPartyContactMechanisms: boolean;
    readonly CanWritePartyContactMechanisms: boolean;
    PartyContactMechanisms: PartyContactMechanism[];
    AddPartyContactMechanism(value: PartyContactMechanism): void;
    RemovePartyContactMechanism(value: PartyContactMechanism): void;
    readonly CanReadShippingInquiriesFax: boolean;
    readonly ShippingInquiriesFax: TelecommunicationsNumber;
    readonly CanReadShippingInquiriesPhone: boolean;
    readonly ShippingInquiriesPhone: TelecommunicationsNumber;
    readonly CanReadBillingAccounts: boolean;
    readonly CanWriteBillingAccounts: boolean;
    BillingAccounts: BillingAccount[];
    AddBillingAccount(value: BillingAccount): void;
    RemoveBillingAccount(value: BillingAccount): void;
    readonly CanReadOrderInquiriesPhone: boolean;
    readonly OrderInquiriesPhone: TelecommunicationsNumber;
    readonly CanReadPartySkills: boolean;
    readonly CanWritePartySkills: boolean;
    PartySkills: PartySkill[];
    AddPartySkill(value: PartySkill): void;
    RemovePartySkill(value: PartySkill): void;
    readonly CanReadPartyClassifications: boolean;
    readonly PartyClassifications: PartyClassification[];
    readonly CanReadExcludeFromDunning: boolean;
    readonly CanWriteExcludeFromDunning: boolean;
    ExcludeFromDunning: boolean;
    readonly CanReadBankAccounts: boolean;
    readonly CanWriteBankAccounts: boolean;
    BankAccounts: BankAccount[];
    AddBankAccount(value: BankAccount): void;
    RemoveBankAccount(value: BankAccount): void;
    readonly CanReadCurrentContacts: boolean;
    readonly CurrentContacts: Person[];
    readonly CanReadBillingAddress: boolean;
    readonly BillingAddress: ContactMechanism;
    readonly CanReadGeneralEmail: boolean;
    readonly GeneralEmail: EmailAddress;
    readonly CanReadDefaultShipmentMethod: boolean;
    readonly CanWriteDefaultShipmentMethod: boolean;
    DefaultShipmentMethod: ShipmentMethod;
    readonly CanReadResumes: boolean;
    readonly CanWriteResumes: boolean;
    Resumes: Resume[];
    AddResume(value: Resume): void;
    RemoveResume(value: Resume): void;
    readonly CanReadHeadQuarter: boolean;
    readonly HeadQuarter: ContactMechanism;
    readonly CanReadPersonalEmailAddress: boolean;
    readonly PersonalEmailAddress: EmailAddress;
    readonly CanReadCellPhoneNumber: boolean;
    readonly CellPhoneNumber: TelecommunicationsNumber;
    readonly CanReadBillingInquiriesPhone: boolean;
    readonly BillingInquiriesPhone: TelecommunicationsNumber;
    readonly CanReadOrderAddress: boolean;
    readonly OrderAddress: ContactMechanism;
    readonly CanReadInternetAddress: boolean;
    readonly InternetAddress: ElectronicAddress;
    readonly CanReadContents: boolean;
    readonly CanWriteContents: boolean;
    Contents: Media[];
    AddContent(value: Media): void;
    RemoveContent(value: Media): void;
    readonly CanReadCreditCards: boolean;
    readonly CanWriteCreditCards: boolean;
    CreditCards: CreditCard[];
    AddCreditCard(value: CreditCard): void;
    RemoveCreditCard(value: CreditCard): void;
    readonly CanReadShippingAddress: boolean;
    readonly ShippingAddress: PostalAddress;
    readonly CanReadCurrentOrganisationContactRelationships: boolean;
    readonly CurrentOrganisationContactRelationships: OrganisationContactRelationship[];
    readonly CanReadOpenOrderAmount: boolean;
    readonly OpenOrderAmount: number;
    readonly CanReadGeneralFaxNumber: boolean;
    readonly GeneralFaxNumber: TelecommunicationsNumber;
    readonly CanReadDefaultPaymentMethod: boolean;
    readonly CanWriteDefaultPaymentMethod: boolean;
    DefaultPaymentMethod: PaymentMethod;
    readonly CanReadCurrentPartyContactMechanisms: boolean;
    readonly CurrentPartyContactMechanisms: PartyContactMechanism[];
    readonly CanReadGeneralPhoneNumber: boolean;
    readonly GeneralPhoneNumber: TelecommunicationsNumber;
    readonly CanReadPreferredCurrency: boolean;
    readonly CanWritePreferredCurrency: boolean;
    PreferredCurrency: Currency;
    readonly CanReadVatRegime: boolean;
    readonly CanWriteVatRegime: boolean;
    VatRegime: VatRegime;
    readonly CanReadAmountOverDue: boolean;
    readonly CanWriteAmountOverDue: boolean;
    AmountOverDue: number;
    readonly CanReadDunningType: boolean;
    readonly CanWriteDunningType: boolean;
    DunningType: DunningType;
    readonly CanReadAmountDue: boolean;
    readonly AmountDue: number;
    readonly CanReadLastReminderDate: boolean;
    readonly CanWriteLastReminderDate: boolean;
    LastReminderDate: Date;
    readonly CanReadCreditLimit: boolean;
    readonly CanWriteCreditLimit: boolean;
    CreditLimit: number;
    readonly CanReadSubAccountNumber: boolean;
    readonly CanWriteSubAccountNumber: boolean;
    SubAccountNumber: number;
    readonly CanReadBlockedForDunning: boolean;
    readonly CanWriteBlockedForDunning: boolean;
    BlockedForDunning: Date;
    readonly CanReadCreatedBy: boolean;
    readonly CanWriteCreatedBy: boolean;
    CreatedBy: User;
    readonly CanReadLastModifiedBy: boolean;
    readonly CanWriteLastModifiedBy: boolean;
    LastModifiedBy: User;
    readonly CanReadCreationDate: boolean;
    readonly CanWriteCreationDate: boolean;
    CreationDate: Date;
    readonly CanReadLastModifiedDate: boolean;
    readonly CanWriteLastModifiedDate: boolean;
    LastModifiedDate: Date;
    readonly CanReadUniqueId: boolean;
    readonly CanWriteUniqueId: boolean;
    UniqueId: string;
    readonly CanReadComment: boolean;
    readonly CanWriteComment: boolean;
    Comment: string;
}