import { AfterViewInit, ChangeDetectorRef, OnDestroy } from "@angular/core";
import { FormBuilder, FormGroup } from "@angular/forms";
import { MatSnackBar } from "@angular/material";
import { Title } from "@angular/platform-browser";
import { Router } from "@angular/router";
import { TdDialogService, TdMediaService } from "@covalent/core";
import { Person } from "@allors/workspace";
import { WorkspaceService, ErrorService } from "@allors/base-angular";
export declare class PeopleOverviewComponent implements AfterViewInit, OnDestroy {
    private workspaceService;
    private errorService;
    private formBuilder;
    private titleService;
    private snackBar;
    private router;
    private dialogService;
    private snackBarService;
    media: TdMediaService;
    private changeDetectorRef;
    total: number;
    title: string;
    searchForm: FormGroup;
    data: Person[];
    private refresh$;
    private subscription;
    private scope;
    private page$;
    constructor(workspaceService: WorkspaceService, errorService: ErrorService, formBuilder: FormBuilder, titleService: Title, snackBar: MatSnackBar, router: Router, dialogService: TdDialogService, snackBarService: MatSnackBar, media: TdMediaService, changeDetectorRef: ChangeDetectorRef);
    more(): void;
    goBack(): void;
    ngAfterViewInit(): void;
    ngOnDestroy(): void;
    refresh(): void;
    delete(person: Person): void;
    onView(person: Person): void;
}
