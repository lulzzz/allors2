"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
// Allors generated file.
// Do not edit this file, changes will be overwritten.
/* tslint:disable */
const framework_1 = require("../../framework");
class AutomatedAgent extends framework_1.SessionObject {
    get CanReadUserName() {
        return this.canRead('UserName');
    }
    get CanWriteUserName() {
        return this.canWrite('UserName');
    }
    get UserName() {
        return this.get('UserName');
    }
    set UserName(value) {
        this.set('UserName', value);
    }
    get CanReadNormalizedUserName() {
        return this.canRead('NormalizedUserName');
    }
    get CanWriteNormalizedUserName() {
        return this.canWrite('NormalizedUserName');
    }
    get NormalizedUserName() {
        return this.get('NormalizedUserName');
    }
    set NormalizedUserName(value) {
        this.set('NormalizedUserName', value);
    }
    get CanReadUserEmail() {
        return this.canRead('UserEmail');
    }
    get CanWriteUserEmail() {
        return this.canWrite('UserEmail');
    }
    get UserEmail() {
        return this.get('UserEmail');
    }
    set UserEmail(value) {
        this.set('UserEmail', value);
    }
    get CanReadUserEmailConfirmed() {
        return this.canRead('UserEmailConfirmed');
    }
    get CanWriteUserEmailConfirmed() {
        return this.canWrite('UserEmailConfirmed');
    }
    get UserEmailConfirmed() {
        return this.get('UserEmailConfirmed');
    }
    set UserEmailConfirmed(value) {
        this.set('UserEmailConfirmed', value);
    }
    get CanReadTaskList() {
        return this.canRead('TaskList');
    }
    get TaskList() {
        return this.get('TaskList');
    }
    get CanReadNotificationList() {
        return this.canRead('NotificationList');
    }
    get CanWriteNotificationList() {
        return this.canWrite('NotificationList');
    }
    get NotificationList() {
        return this.get('NotificationList');
    }
    set NotificationList(value) {
        this.set('NotificationList', value);
    }
    get CanReadLocale() {
        return this.canRead('Locale');
    }
    get CanWriteLocale() {
        return this.canWrite('Locale');
    }
    get Locale() {
        return this.get('Locale');
    }
    set Locale(value) {
        this.set('Locale', value);
    }
}
exports.AutomatedAgent = AutomatedAgent;
//# sourceMappingURL=AutomatedAgent.g.js.map