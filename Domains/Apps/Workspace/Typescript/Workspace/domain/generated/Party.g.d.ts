import { SessionObject } from "@allors/framework";
import { Localised } from './Localised.g';
import { Auditable } from './Auditable.g';
import { UniquelyIdentifiable } from './UniquelyIdentifiable.g';
import { Commentable } from './Commentable.g';
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
export interface Party extends SessionObject, Localised, Auditable, UniquelyIdentifiable, Commentable {
    PartyName: string;
    GeneralCorrespondence: PostalAddress;
    YTDRevenue: number;
    LastYearsRevenue: number;
    BillingInquiriesFax: TelecommunicationsNumber;
    Qualifications: Qualification[];
    AddQualification(value: Qualification): any;
    RemoveQualification(value: Qualification): any;
    HomeAddress: ContactMechanism;
    InactiveOrganisationContactRelationships: OrganisationContactRelationship[];
    SalesOffice: ContactMechanism;
    InactiveContacts: Person[];
    InactivePartyContactMechanisms: PartyContactMechanism[];
    OrderInquiriesFax: TelecommunicationsNumber;
    CurrentSalesReps: Person[];
    PartyContactMechanisms: PartyContactMechanism[];
    AddPartyContactMechanism(value: PartyContactMechanism): any;
    RemovePartyContactMechanism(value: PartyContactMechanism): any;
    ShippingInquiriesFax: TelecommunicationsNumber;
    ShippingInquiriesPhone: TelecommunicationsNumber;
    BillingAccounts: BillingAccount[];
    AddBillingAccount(value: BillingAccount): any;
    RemoveBillingAccount(value: BillingAccount): any;
    OrderInquiriesPhone: TelecommunicationsNumber;
    PartySkills: PartySkill[];
    AddPartySkill(value: PartySkill): any;
    RemovePartySkill(value: PartySkill): any;
    PartyClassifications: PartyClassification[];
    ExcludeFromDunning: boolean;
    BankAccounts: BankAccount[];
    AddBankAccount(value: BankAccount): any;
    RemoveBankAccount(value: BankAccount): any;
    CurrentContacts: Person[];
    BillingAddress: ContactMechanism;
    GeneralEmail: EmailAddress;
    DefaultShipmentMethod: ShipmentMethod;
    Resumes: Resume[];
    AddResume(value: Resume): any;
    RemoveResume(value: Resume): any;
    HeadQuarter: ContactMechanism;
    PersonalEmailAddress: EmailAddress;
    CellPhoneNumber: TelecommunicationsNumber;
    BillingInquiriesPhone: TelecommunicationsNumber;
    OrderAddress: ContactMechanism;
    InternetAddress: ElectronicAddress;
    Contents: Media[];
    AddContent(value: Media): any;
    RemoveContent(value: Media): any;
    CreditCards: CreditCard[];
    AddCreditCard(value: CreditCard): any;
    RemoveCreditCard(value: CreditCard): any;
    ShippingAddress: PostalAddress;
    CurrentOrganisationContactRelationships: OrganisationContactRelationship[];
    OpenOrderAmount: number;
    GeneralFaxNumber: TelecommunicationsNumber;
    DefaultPaymentMethod: PaymentMethod;
    CurrentPartyContactMechanisms: PartyContactMechanism[];
    GeneralPhoneNumber: TelecommunicationsNumber;
    PreferredCurrency: Currency;
    VatRegime: VatRegime;
    AmountOverDue: number;
    DunningType: DunningType;
    AmountDue: number;
    LastReminderDate: Date;
    CreditLimit: number;
    SubAccountNumber: number;
    BlockedForDunning: Date;
}