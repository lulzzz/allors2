"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular/core");
const inline_module_1 = require("../../inline.module");
const shared_module_1 = require("../../shared.module");
const quoteitem_component_1 = require("./quoteitem.component");
var quoteitem_component_2 = require("./quoteitem.component");
exports.QuoteItemEditComponent = quoteitem_component_2.QuoteItemEditComponent;
let QuoteItemEditModule = class QuoteItemEditModule {
};
QuoteItemEditModule = __decorate([
    core_1.NgModule({
        declarations: [
            quoteitem_component_1.QuoteItemEditComponent,
        ],
        exports: [
            quoteitem_component_1.QuoteItemEditComponent,
            inline_module_1.InlineModule,
            shared_module_1.SharedModule,
        ],
        imports: [
            inline_module_1.InlineModule,
            shared_module_1.SharedModule,
        ],
    })
], QuoteItemEditModule);
exports.QuoteItemEditModule = QuoteItemEditModule;
