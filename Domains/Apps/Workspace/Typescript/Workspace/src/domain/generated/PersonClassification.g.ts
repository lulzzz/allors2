// Allors generated file.
// Do not edit this file, changes will be overwritten.
/* tslint:disable */
import { SessionObject, Method } from "@allors/framework";

import { PartyClassification } from './PartyClassification.g';
import { Person } from './Person.g';
import { PersonVersion } from './PersonVersion.g';
import { PartyVersion } from './PartyVersion.g';
import { Party } from './Party.g';

export interface PersonClassification extends SessionObject , PartyClassification {

    CanExecuteDelete: boolean;
    Delete: Method;

}