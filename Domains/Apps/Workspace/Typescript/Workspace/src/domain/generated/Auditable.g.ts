// Allors generated file.
// Do not edit this file, changes will be overwritten.
/* tslint:disable */
import { SessionObject, Method } from "@allors/framework";

import { User } from './User.g';

export interface Auditable extends SessionObject  {
        CreatedBy : User;


        LastModifiedBy : User;


        CreationDate : Date;


        LastModifiedDate : Date;


}