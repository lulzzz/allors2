import { AfterViewInit, ChangeDetectorRef, OnDestroy, OnInit } from "@angular/core";
import { MatSnackBar } from "@angular/material";
import { ActivatedRoute } from "@angular/router";
import { Router } from "@angular/router";
import { TdDialogService, TdMediaService } from "@covalent/core";
import 'rxjs/add/observable/combineLatest';
import { MetaDomain, ProductQuote, RequestForQuote, InventoryItem, SerialisedInventoryItem, NonSerialisedInventoryItem, RequestItem } from "@allors/workspace";
import { WorkspaceService, ErrorService } from "@allors/base-angular";
export declare class RequestOverviewComponent implements OnInit, AfterViewInit, OnDestroy {
    private workspaceService;
    private errorService;
    private route;
    private router;
    dialogService: TdDialogService;
    private snackBar;
    media: TdMediaService;
    private changeDetectorRef;
    m: MetaDomain;
    title: string;
    request: RequestForQuote;
    quote: ProductQuote;
    inventoryItems: InventoryItem[];
    serialisedInventoryItem: SerialisedInventoryItem;
    nonSerialisedInventoryItem: NonSerialisedInventoryItem;
    private subscription;
    private scope;
    private refresh$;
    constructor(workspaceService: WorkspaceService, errorService: ErrorService, route: ActivatedRoute, router: Router, dialogService: TdDialogService, snackBar: MatSnackBar, media: TdMediaService, changeDetectorRef: ChangeDetectorRef);
    refresh(): void;
    ngOnInit(): void;
    ngAfterViewInit(): void;
    ngOnDestroy(): void;
    goBack(): void;
    createQuote(): void;
    deleteRequestItem(requestItem: RequestItem): void;
    gotoQuote(): void;
}