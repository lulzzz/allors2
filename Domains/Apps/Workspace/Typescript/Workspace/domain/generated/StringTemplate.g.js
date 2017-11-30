"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
// Allors generated file.
// Do not edit this file, changes will be overwritten.
/* tslint:disable */
const framework_1 = require("@allors/framework");
class StringTemplate extends framework_1.SessionObject {
    get CanReadUniqueId() {
        return this.canRead('UniqueId');
    }
    get CanWriteUniqueId() {
        return this.canWrite('UniqueId');
    }
    get UniqueId() {
        return this.get('UniqueId');
    }
    set UniqueId(value) {
        this.set('UniqueId', value);
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
exports.StringTemplate = StringTemplate;