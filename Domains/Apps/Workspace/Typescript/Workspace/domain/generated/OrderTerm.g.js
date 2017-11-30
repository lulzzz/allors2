"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
// Allors generated file.
// Do not edit this file, changes will be overwritten.
/* tslint:disable */
const framework_1 = require("@allors/framework");
class OrderTerm extends framework_1.SessionObject {
    get CanReadTermValue() {
        return this.canRead('TermValue');
    }
    get CanWriteTermValue() {
        return this.canWrite('TermValue');
    }
    get TermValue() {
        return this.get('TermValue');
    }
    set TermValue(value) {
        this.set('TermValue', value);
    }
    get CanReadTermType() {
        return this.canRead('TermType');
    }
    get CanWriteTermType() {
        return this.canWrite('TermType');
    }
    get TermType() {
        return this.get('TermType');
    }
    set TermType(value) {
        this.set('TermType', value);
    }
}
exports.OrderTerm = OrderTerm;