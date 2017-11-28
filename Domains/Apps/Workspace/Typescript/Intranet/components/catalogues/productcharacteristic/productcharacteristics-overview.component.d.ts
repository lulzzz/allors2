import { AfterViewInit, ChangeDetectorRef, OnDestroy } from "@angular/core";
import { FormBuilder, FormGroup } from "@angular/forms";
import { MatSnackBar } from "@angular/material";
import { Title } from "@angular/platform-browser";
import { Router } from "@angular/router";
import { TdDialogService, TdMediaService } from "@covalent/core";
import { ProductCharacteristic } from "@allors/workspace";
import { WorkspaceService, ErrorService } from "@allors/base-angular";
export declare class ProductCharacteristicsOverviewComponent implements AfterViewInit, OnDestroy {
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
    data: ProductCharacteristic[];
    filtered: ProductCharacteristic[];
    private refresh$;
    private page$;
    private subscription;
    private scope;
    constructor(workspaceService: WorkspaceService, errorService: ErrorService, formBuilder: FormBuilder, titleService: Title, snackBar: MatSnackBar, router: Router, dialogService: TdDialogService, media: TdMediaService, changeDetectorRef: ChangeDetectorRef);
    more(): void;
    goBack(): void;
    ngAfterViewInit(): void;
    ngOnDestroy(): void;
    delete(productCharacteristic: ProductCharacteristic): void;
    onView(productCharacteristic: ProductCharacteristic): void;
}
