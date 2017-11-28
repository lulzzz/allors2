import { AfterViewInit, ChangeDetectorRef, OnDestroy, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { TdMediaService } from "@covalent/core";
import { MetaDomain, Locale, Organisation, CustomerRelationship, OrganisationRole, CustomOrganisationClassification, IndustryClassification } from "@allors/workspace";
import { WorkspaceService, ErrorService } from "@allors/base-angular";
export declare class OrganisationComponent implements OnInit, AfterViewInit, OnDestroy {
    private workspaceService;
    private errorService;
    private route;
    media: TdMediaService;
    private changeDetectorRef;
    title: string;
    subTitle: string;
    m: MetaDomain;
    organisation: Organisation;
    locales: Locale[];
    roles: OrganisationRole[];
    classifications: CustomOrganisationClassification[];
    industries: IndustryClassification[];
    customerRelationships: CustomerRelationship[];
    private refresh$;
    private subscription;
    private scope;
    private customerRole;
    constructor(workspaceService: WorkspaceService, errorService: ErrorService, route: ActivatedRoute, media: TdMediaService, changeDetectorRef: ChangeDetectorRef);
    ngOnInit(): void;
    ngAfterViewInit(): void;
    ngOnDestroy(): void;
    save(): void;
    goBack(): void;
}
