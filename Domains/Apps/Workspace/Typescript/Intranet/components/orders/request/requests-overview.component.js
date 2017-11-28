"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular/core");
const forms_1 = require("@angular/forms");
const platform_browser_1 = require("@angular/platform-browser");
const router_1 = require("@angular/router");
const Rx_1 = require("rxjs/Rx");
const core_2 = require("@covalent/core");
const base_angular_1 = require("@allors/base-angular");
const framework_1 = require("@allors/framework");
let RequestsOverviewComponent = class RequestsOverviewComponent {
    constructor(workspaceService, errorService, formBuilder, titleService, router, dialogService, media, changeDetectorRef) {
        this.workspaceService = workspaceService;
        this.errorService = errorService;
        this.formBuilder = formBuilder;
        this.titleService = titleService;
        this.router = router;
        this.dialogService = dialogService;
        this.media = media;
        this.changeDetectorRef = changeDetectorRef;
        this.title = "Requests";
        this.scope = this.workspaceService.createScope();
        this.refresh$ = new Rx_1.BehaviorSubject(undefined);
        this.searchForm = this.formBuilder.group({
            company: [""],
            description: [""],
            requestNumber: [""],
        });
        this.page$ = new Rx_1.BehaviorSubject(50);
        const search$ = this.searchForm.valueChanges
            .debounceTime(400)
            .distinctUntilChanged()
            .startWith({});
        const combined$ = Rx_1.Observable
            .combineLatest(search$, this.page$, this.refresh$)
            .scan(([previousData, previousTake, previousDate], [data, take, date]) => {
            return [
                data,
                data !== previousData ? 50 : take,
                date,
            ];
        }, []);
        this.subscription = combined$
            .switchMap(([data, take]) => {
            const m = this.workspaceService.metaPopulation.metaDomain;
            const predicate = new framework_1.And();
            const predicates = predicate.predicates;
            if (data.requestNumber) {
                const like = "%" + data.requestNumber + "%";
                predicates.push(new framework_1.Like({ roleType: m.Request.RequestNumber, value: like }));
            }
            if (data.company) {
                const partyQuery = new framework_1.Query({
                    objectType: m.Party, predicate: new framework_1.Like({
                        roleType: m.Party.PartyName, value: data.company.replace("*", "%") + "%",
                    }),
                });
                const containedIn = new framework_1.ContainedIn({ roleType: m.Request.Originator, query: partyQuery });
                predicates.push(containedIn);
            }
            if (data.description) {
                const like = data.description.replace("*", "%") + "%";
                predicates.push(new framework_1.Like({ roleType: m.Request.Description, value: like }));
            }
            const query = [new framework_1.Query({
                    include: [
                        new framework_1.TreeNode({ roleType: m.Request.Originator }),
                        new framework_1.TreeNode({ roleType: m.Request.RequestState }),
                    ],
                    name: "requests",
                    objectType: m.Request,
                    page: new framework_1.Page({ skip: 0, take }),
                    predicate,
                    sort: [new framework_1.Sort({ roleType: m.Request.RequestNumber, direction: "Desc" })],
                })];
            return this.scope.load("Pull", new framework_1.PullRequest({ query }));
        })
            .subscribe((loaded) => {
            this.data = loaded.collections.requests;
            this.total = loaded.values.requests_total;
        }, (error) => {
            this.errorService.message(error);
            this.goBack();
        });
    }
    more() {
        this.page$.next(this.data.length + 50);
    }
    goBack() {
        window.history.back();
    }
    ngAfterViewInit() {
        this.titleService.setTitle("Requests");
        this.media.broadcast();
        this.changeDetectorRef.detectChanges();
    }
    ngOnDestroy() {
        if (this.subscription) {
            this.subscription.unsubscribe();
        }
    }
    onView(request) {
        this.router.navigate(["/orders/requests/" + request.id + "/edit"]);
    }
};
RequestsOverviewComponent = __decorate([
    core_1.Component({
        templateUrl: "./requests-overview.component.html",
    }),
    __metadata("design:paramtypes", [base_angular_1.WorkspaceService,
        base_angular_1.ErrorService,
        forms_1.FormBuilder,
        platform_browser_1.Title,
        router_1.Router,
        core_2.TdDialogService,
        core_2.TdMediaService,
        core_1.ChangeDetectorRef])
], RequestsOverviewComponent);
exports.RequestsOverviewComponent = RequestsOverviewComponent;
