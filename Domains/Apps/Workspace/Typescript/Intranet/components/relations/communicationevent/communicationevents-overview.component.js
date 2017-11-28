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
const material_1 = require("@angular/material");
const platform_browser_1 = require("@angular/platform-browser");
const router_1 = require("@angular/router");
const Rx_1 = require("rxjs/Rx");
const core_2 = require("@covalent/core");
const base_angular_1 = require("@allors/base-angular");
const framework_1 = require("@allors/framework");
let CommunicationEventsOverviewComponent = class CommunicationEventsOverviewComponent {
    constructor(workspaceService, errorService, formBuilder, titleService, snackBar, router, dialogService, snackBarService, media, changeDetectorRef) {
        this.workspaceService = workspaceService;
        this.errorService = errorService;
        this.formBuilder = formBuilder;
        this.titleService = titleService;
        this.snackBar = snackBar;
        this.router = router;
        this.dialogService = dialogService;
        this.snackBarService = snackBarService;
        this.media = media;
        this.changeDetectorRef = changeDetectorRef;
        this.title = "Communications";
        titleService.setTitle(this.title);
        this.scope = this.workspaceService.createScope();
        this.refresh$ = new Rx_1.BehaviorSubject(undefined);
        this.searchForm = this.formBuilder.group({
            involved: [""],
            purpose: [""],
            state: [""],
            subject: [""],
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
            const objectStatesQuery = [
                new framework_1.Query({
                    name: "communicationEventStates",
                    objectType: m.CommunicationEventState,
                }),
                new framework_1.Query({
                    name: "purposes",
                    objectType: m.CommunicationEventPurpose,
                }),
                new framework_1.Query({
                    name: "persons",
                    objectType: m.Person,
                }),
            ];
            return this.scope
                .load("Pull", new framework_1.PullRequest({ query: objectStatesQuery }))
                .switchMap((loaded) => {
                this.communicationEventStates = loaded.collections.communicationEventStates;
                this.communicationEventState = this.communicationEventStates.find((v) => v.Name === data.state);
                this.purposes = loaded.collections.purposes;
                this.purpose = this.purposes.find((v) => v.Name === data.purpose);
                this.people = loaded.collections.persons;
                this.involved = this.people.find((v) => v.displayName === data.involved);
                const predicate = new framework_1.And();
                const predicates = predicate.predicates;
                if (data.subject) {
                    const like = "%" + data.subject + "%";
                    predicates.push(new framework_1.Like({ roleType: m.CommunicationEvent.Subject, value: like }));
                }
                if (data.state) {
                    predicates.push(new framework_1.Equals({ roleType: m.CommunicationEvent.CommunicationEventState, value: this.communicationEventState }));
                }
                if (data.purpose) {
                    predicates.push(new framework_1.Contains({ roleType: m.CommunicationEvent.EventPurposes, object: this.purpose }));
                }
                if (data.involved) {
                    predicates.push(new framework_1.Contains({ roleType: m.CommunicationEvent.InvolvedParties, object: this.involved }));
                }
                const communicationsQuery = [
                    new framework_1.Query({
                        include: [
                            new framework_1.TreeNode({ roleType: m.CommunicationEvent.CommunicationEventState }),
                            new framework_1.TreeNode({ roleType: m.CommunicationEvent.FromParties }),
                            new framework_1.TreeNode({ roleType: m.CommunicationEvent.ToParties }),
                            new framework_1.TreeNode({ roleType: m.CommunicationEvent.InvolvedParties }),
                        ],
                        name: "communicationEvents",
                        objectType: m.CommunicationEvent,
                        predicate,
                        page: new framework_1.Page({ skip: 0, take }),
                    }),
                ];
                return this.scope
                    .load("Pull", new framework_1.PullRequest({ query: communicationsQuery }));
            });
        })
            .subscribe((loaded) => {
            this.scope.session.reset();
            this.data = loaded.collections.communicationEvents;
            this.total = loaded.values.communicationEvents_total;
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
        this.media.broadcast();
        this.changeDetectorRef.detectChanges();
    }
    ngOnDestroy() {
        if (this.subscription) {
            this.subscription.unsubscribe();
        }
    }
    refresh() {
        this.refresh$.next(new Date());
    }
    cancel(communicationEvent) {
        this.dialogService
            .openConfirm({ message: "Are you sure you want to cancel this?" })
            .afterClosed().subscribe((confirm) => {
            if (confirm) {
                this.scope.invoke(communicationEvent.Cancel)
                    .subscribe((invoked) => {
                    this.snackBar.open("Successfully cancelled.", "close", { duration: 5000 });
                    this.refresh();
                }, (error) => {
                    this.errorService.dialog(error);
                });
            }
        });
    }
    close(communicationEvent) {
        this.dialogService
            .openConfirm({ message: "Are you sure you want to close this?" })
            .afterClosed().subscribe((confirm) => {
            if (confirm) {
                this.scope.invoke(communicationEvent.Close)
                    .subscribe((invoked) => {
                    this.snackBar.open("Successfully closed.", "close", { duration: 5000 });
                    this.refresh();
                }, (error) => {
                    this.errorService.dialog(error);
                });
            }
        });
    }
    reopen(communicationEvent) {
        this.dialogService
            .openConfirm({ message: "Are you sure you want to reopen this?" })
            .afterClosed().subscribe((confirm) => {
            if (confirm) {
                this.scope.invoke(communicationEvent.Reopen)
                    .subscribe((invoked) => {
                    this.snackBar.open("Successfully reopened.", "close", { duration: 5000 });
                    this.refresh();
                }, (error) => {
                    this.errorService.dialog(error);
                });
            }
        });
    }
    delete(communicationEvent) {
        this.dialogService
            .openConfirm({ message: "Are you sure you want to delete this communication event?" })
            .afterClosed()
            .subscribe((confirm) => {
            if (confirm) {
                this.scope.invoke(communicationEvent.Delete)
                    .subscribe((invoked) => {
                    this.snackBar.open("Successfully deleted.", "close", { duration: 5000 });
                    this.refresh();
                }, (error) => {
                    this.errorService.dialog(error);
                });
            }
        });
    }
    checkType(obj) {
        return obj.objectType.name;
    }
    onView(person) {
        this.router.navigate(["/relations/person/" + person.id]);
    }
};
CommunicationEventsOverviewComponent = __decorate([
    core_1.Component({
        templateUrl: "./communicationevents-overview.component.html",
    }),
    __metadata("design:paramtypes", [base_angular_1.WorkspaceService,
        base_angular_1.ErrorService,
        forms_1.FormBuilder,
        platform_browser_1.Title,
        material_1.MatSnackBar,
        router_1.Router,
        core_2.TdDialogService,
        material_1.MatSnackBar,
        core_2.TdMediaService,
        core_1.ChangeDetectorRef])
], CommunicationEventsOverviewComponent);
exports.CommunicationEventsOverviewComponent = CommunicationEventsOverviewComponent;
