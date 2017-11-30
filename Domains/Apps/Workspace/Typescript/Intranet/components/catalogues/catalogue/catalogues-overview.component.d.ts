import { AfterViewInit, ChangeDetectorRef, OnDestroy } from "@angular/core";
import { FormBuilder, FormGroup } from "@angular/forms";
import { MatSnackBar } from "@angular/material";
import { Title } from "@angular/platform-browser";
import { Router } from "@angular/router";
import 'rxjs/add/observable/combineLatest';
import { TdDialogService, TdMediaService } from "@covalent/core";
import { Catalogue } from "@allors/workspace";
import { WorkspaceService, ErrorService } from "@allors/base-angular";
export declare class CataloguesOverviewComponent implements AfterViewInit, OnDestroy {
    private workspaceService;
    private errorService;
    private formBuilder;
    private titleService;
    private snackBar;
    private router;
    private dialogService;
    media: TdMediaService;
    private changeDetectorRef;
    title: string;
    total: number;
    searchForm: FormGroup;
    data: Catalogue[];
    filtered: Catalogue[];
    private refresh$;
    private page$;
    private subscription;
    private scope;
    constructor(workspaceService: WorkspaceService, errorService: ErrorService, formBuilder: FormBuilder, titleService: Title, snackBar: MatSnackBar, router: Router, dialogService: TdDialogService, media: TdMediaService, changeDetectorRef: ChangeDetectorRef);
    more(): void;
    goBack(): void;
    ngAfterViewInit(): void;
    ngOnDestroy(): void;
    delete(catalogue: Catalogue): void;
    onView(catalogue: Catalogue): void;
}