import { SessionObject } from "@allors/framework";
import { CommunicationEventVersion } from './CommunicationEventVersion.g';
import { EmailAddress } from './EmailAddress.g';
import { EmailTemplate } from './EmailTemplate.g';
import { CommunicationEventState } from './CommunicationEventState.g';
import { User } from './User.g';
import { Party } from './Party.g';
import { ContactMechanism } from './ContactMechanism.g';
import { CommunicationEventPurpose } from './CommunicationEventPurpose.g';
import { WorkEffort } from './WorkEffort.g';
import { Media } from './Media.g';
import { Case } from './Case.g';
import { Priority } from './Priority.g';
import { Person } from './Person.g';
export declare class EmailCommunicationVersion extends SessionObject implements CommunicationEventVersion {
    readonly CanReadOriginator: boolean;
    readonly CanWriteOriginator: boolean;
    Originator: EmailAddress;
    readonly CanReadAddressees: boolean;
    readonly CanWriteAddressees: boolean;
    Addressees: EmailAddress[];
    AddAddressee(value: EmailAddress): void;
    RemoveAddressee(value: EmailAddress): void;
    readonly CanReadCarbonCopies: boolean;
    readonly CanWriteCarbonCopies: boolean;
    CarbonCopies: EmailAddress[];
    AddCarbonCopy(value: EmailAddress): void;
    RemoveCarbonCopy(value: EmailAddress): void;
    readonly CanReadBlindCopies: boolean;
    readonly CanWriteBlindCopies: boolean;
    BlindCopies: EmailAddress[];
    AddBlindCopy(value: EmailAddress): void;
    RemoveBlindCopy(value: EmailAddress): void;
    readonly CanReadEmailTemplate: boolean;
    readonly CanWriteEmailTemplate: boolean;
    EmailTemplate: EmailTemplate;
    readonly CanReadIncomingMail: boolean;
    readonly CanWriteIncomingMail: boolean;
    IncomingMail: boolean;
    readonly CanReadCommunicationEventState: boolean;
    readonly CommunicationEventState: CommunicationEventState;
    readonly CanReadComment: boolean;
    readonly CanWriteComment: boolean;
    Comment: string;
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
    readonly CanReadScheduledStart: boolean;
    readonly CanWriteScheduledStart: boolean;
    ScheduledStart: Date;
    readonly CanReadToParties: boolean;
    readonly ToParties: Party[];
    readonly CanReadContactMechanisms: boolean;
    readonly CanWriteContactMechanisms: boolean;
    ContactMechanisms: ContactMechanism[];
    AddContactMechanism(value: ContactMechanism): void;
    RemoveContactMechanism(value: ContactMechanism): void;
    readonly CanReadInvolvedParties: boolean;
    readonly InvolvedParties: Party[];
    readonly CanReadInitialScheduledStart: boolean;
    readonly CanWriteInitialScheduledStart: boolean;
    InitialScheduledStart: Date;
    readonly CanReadEventPurposes: boolean;
    readonly CanWriteEventPurposes: boolean;
    EventPurposes: CommunicationEventPurpose[];
    AddEventPurpose(value: CommunicationEventPurpose): void;
    RemoveEventPurpose(value: CommunicationEventPurpose): void;
    readonly CanReadScheduledEnd: boolean;
    readonly CanWriteScheduledEnd: boolean;
    ScheduledEnd: Date;
    readonly CanReadActualEnd: boolean;
    readonly CanWriteActualEnd: boolean;
    ActualEnd: Date;
    readonly CanReadWorkEfforts: boolean;
    readonly CanWriteWorkEfforts: boolean;
    WorkEfforts: WorkEffort[];
    AddWorkEffort(value: WorkEffort): void;
    RemoveWorkEffort(value: WorkEffort): void;
    readonly CanReadDescription: boolean;
    readonly CanWriteDescription: boolean;
    Description: string;
    readonly CanReadInitialScheduledEnd: boolean;
    readonly CanWriteInitialScheduledEnd: boolean;
    InitialScheduledEnd: Date;
    readonly CanReadFromParties: boolean;
    readonly FromParties: Party[];
    readonly CanReadSubject: boolean;
    readonly CanWriteSubject: boolean;
    Subject: string;
    readonly CanReadDocuments: boolean;
    readonly CanWriteDocuments: boolean;
    Documents: Media[];
    AddDocument(value: Media): void;
    RemoveDocument(value: Media): void;
    readonly CanReadCase: boolean;
    readonly CanWriteCase: boolean;
    Case: Case;
    readonly CanReadPriority: boolean;
    readonly CanWritePriority: boolean;
    Priority: Priority;
    readonly CanReadOwner: boolean;
    readonly CanWriteOwner: boolean;
    Owner: Person;
    readonly CanReadNote: boolean;
    readonly CanWriteNote: boolean;
    Note: string;
    readonly CanReadActualStart: boolean;
    readonly CanWriteActualStart: boolean;
    ActualStart: Date;
    readonly CanReadSendNotification: boolean;
    readonly CanWriteSendNotification: boolean;
    SendNotification: boolean;
    readonly CanReadSendReminder: boolean;
    readonly CanWriteSendReminder: boolean;
    SendReminder: boolean;
    readonly CanReadRemindAt: boolean;
    readonly CanWriteRemindAt: boolean;
    RemindAt: Date;
    readonly CanReadDerivationTimeStamp: boolean;
    readonly CanWriteDerivationTimeStamp: boolean;
    DerivationTimeStamp: Date;
}