// Allors generated file.
// Do not edit this file, changes will be overwritten.
/* tslint:disable */
import { SessionObject, Method } from "@allors/framework";

import { GeographicBoundary } from './GeographicBoundary.g';
import { GeoLocatable } from './GeoLocatable.g';
import { UniquelyIdentifiable } from './UniquelyIdentifiable.g';
import { Currency } from './Currency.g';
import { LocalisedText } from './LocalisedText.g';
import { VatRate } from './VatRate.g';
import { VatForm } from './VatForm.g';
import { Locale } from './Locale.g';
import { InternalOrganisation } from './InternalOrganisation.g';
import { IncoTerm } from './IncoTerm.g';
import { PostalAddress } from './PostalAddress.g';
import { PostalBoundary } from './PostalBoundary.g';

export class Country extends SessionObject implements GeographicBoundary {
    get CanReadCurrency(): boolean {
        return this.canRead('Currency');
    }

    get CanWriteCurrency(): boolean {
        return this.canWrite('Currency');
    }

    get Currency(): Currency {
        return this.get('Currency');
    }

    set Currency(value: Currency) {
        this.set('Currency', value);
    }

    get CanReadIsoCode(): boolean {
        return this.canRead('IsoCode');
    }

    get CanWriteIsoCode(): boolean {
        return this.canWrite('IsoCode');
    }

    get IsoCode(): string {
        return this.get('IsoCode');
    }

    set IsoCode(value: string) {
        this.set('IsoCode', value);
    }

    get CanReadName(): boolean {
        return this.canRead('Name');
    }

    get CanWriteName(): boolean {
        return this.canWrite('Name');
    }

    get Name(): string {
        return this.get('Name');
    }

    set Name(value: string) {
        this.set('Name', value);
    }

    get CanReadLocalisedNames(): boolean {
        return this.canRead('LocalisedNames');
    }

    get CanWriteLocalisedNames(): boolean {
        return this.canWrite('LocalisedNames');
    }

    get LocalisedNames(): LocalisedText[] {
        return this.get('LocalisedNames');
    }

    AddLocalisedName(value: LocalisedText) {
        return this.add('LocalisedNames', value);
    }

    RemoveLocalisedName(value: LocalisedText) {
        return this.remove('LocalisedNames', value);
    }

    set LocalisedNames(value: LocalisedText[]) {
        this.set('LocalisedNames', value);
    }

    get CanReadVatRates(): boolean {
        return this.canRead('VatRates');
    }

    get CanWriteVatRates(): boolean {
        return this.canWrite('VatRates');
    }

    get VatRates(): VatRate[] {
        return this.get('VatRates');
    }

    AddVatRate(value: VatRate) {
        return this.add('VatRates', value);
    }

    RemoveVatRate(value: VatRate) {
        return this.remove('VatRates', value);
    }

    set VatRates(value: VatRate[]) {
        this.set('VatRates', value);
    }

    get CanReadIbanLength(): boolean {
        return this.canRead('IbanLength');
    }

    get CanWriteIbanLength(): boolean {
        return this.canWrite('IbanLength');
    }

    get IbanLength(): number {
        return this.get('IbanLength');
    }

    set IbanLength(value: number) {
        this.set('IbanLength', value);
    }

    get CanReadEuMemberState(): boolean {
        return this.canRead('EuMemberState');
    }

    get CanWriteEuMemberState(): boolean {
        return this.canWrite('EuMemberState');
    }

    get EuMemberState(): boolean {
        return this.get('EuMemberState');
    }

    set EuMemberState(value: boolean) {
        this.set('EuMemberState', value);
    }

    get CanReadTelephoneCode(): boolean {
        return this.canRead('TelephoneCode');
    }

    get CanWriteTelephoneCode(): boolean {
        return this.canWrite('TelephoneCode');
    }

    get TelephoneCode(): string {
        return this.get('TelephoneCode');
    }

    set TelephoneCode(value: string) {
        this.set('TelephoneCode', value);
    }

    get CanReadIbanRegex(): boolean {
        return this.canRead('IbanRegex');
    }

    get CanWriteIbanRegex(): boolean {
        return this.canWrite('IbanRegex');
    }

    get IbanRegex(): string {
        return this.get('IbanRegex');
    }

    set IbanRegex(value: string) {
        this.set('IbanRegex', value);
    }

    get CanReadVatForm(): boolean {
        return this.canRead('VatForm');
    }

    get CanWriteVatForm(): boolean {
        return this.canWrite('VatForm');
    }

    get VatForm(): VatForm {
        return this.get('VatForm');
    }

    set VatForm(value: VatForm) {
        this.set('VatForm', value);
    }

    get CanReadUriExtension(): boolean {
        return this.canRead('UriExtension');
    }

    get CanWriteUriExtension(): boolean {
        return this.canWrite('UriExtension');
    }

    get UriExtension(): string {
        return this.get('UriExtension');
    }

    set UriExtension(value: string) {
        this.set('UriExtension', value);
    }

    get CanReadLatitude(): boolean {
        return this.canRead('Latitude');
    }

    get Latitude(): number {
        return this.get('Latitude');
    }


    get CanReadLongitude(): boolean {
        return this.canRead('Longitude');
    }

    get Longitude(): number {
        return this.get('Longitude');
    }


    get CanReadUniqueId(): boolean {
        return this.canRead('UniqueId');
    }

    get CanWriteUniqueId(): boolean {
        return this.canWrite('UniqueId');
    }

    get UniqueId(): string {
        return this.get('UniqueId');
    }

    set UniqueId(value: string) {
        this.set('UniqueId', value);
    }


}