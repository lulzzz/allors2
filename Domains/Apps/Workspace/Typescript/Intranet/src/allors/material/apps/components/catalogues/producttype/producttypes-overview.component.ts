import { Component, OnDestroy, OnInit, Self } from '@angular/core';
import { MatSnackBar } from '@angular/material';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';

import { BehaviorSubject, Subscription, combineLatest } from 'rxjs';

import { ErrorService, SessionService, Invoked } from '../../../../../angular';
import { ProductType } from '../../../../../domain';
import { And, Like, Predicate, PullRequest, Sort } from '../../../../../framework';
import { AllorsMaterialDialogService } from '../../../../base/services/dialog';
import { debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';
import { StateService } from '../../../services/state';

interface SearchData {
  name?: string;
}

@Component({
  templateUrl: './producttypes-overview.component.html',
  providers: [SessionService]
})
export class ProductTypesOverviewComponent implements OnInit, OnDestroy {

  public title = 'Product Types';
  public productTypes: ProductType[];
  public filtered: ProductType[];

  public search$: BehaviorSubject<SearchData>;
  private refresh$: BehaviorSubject<Date>;
  private subscription: Subscription;

  constructor(
    @Self() private allors: SessionService,
    private errorService: ErrorService,
    private titleService: Title,
    private snackBar: MatSnackBar,
    private router: Router,
    private dialogService: AllorsMaterialDialogService,
    private stateService: StateService) {

    this.titleService.setTitle(this.title);

    this.search$ = new BehaviorSubject<SearchData>({});
    this.refresh$ = new BehaviorSubject<Date>(undefined);
  }

  ngOnInit(): void {

    const { m, pull, x } = this.allors;

    const search$ = this.search$
      .pipe(
        debounceTime(400),
        distinctUntilChanged(),
      );

    this.subscription = combineLatest(search$, this.refresh$, this.stateService.internalOrganisationId$)
      .pipe(
        switchMap(([data, refresh, internalOrganisationId]) => {

          const predicate: And = new And();
          const predicates: Predicate[] = predicate.operands;

          if (data.name) {
            const like: string = data.name.replace('*', '%') + '%';
            predicates.push(new Like({ roleType: m.ProductType.Name, value: like }));
          }

          const pulls = [
            pull.ProductType(
              {
                predicate,
                include: {
                  SerialisedItemCharacteristicTypes: x,
                },
                sort: new Sort(m.ProductType.Name),
              }
            )
          ];

          return this.allors.load('Pull', new PullRequest({ pulls }));
        })
      )
      .subscribe((loaded) => {
        this.productTypes = loaded.collections.ProductTypes as ProductType[];
      }, this.errorService.handler);
  }

  public delete(productType: ProductType): void {

    this.dialogService
      .confirm({ message: 'Are you sure you want to delete this product type?' })
      .subscribe((confirm: boolean) => {
        if (confirm) {
          if (confirm) {
            this.allors.invoke(productType.Delete)
              .subscribe((invoked: Invoked) => {
                this.snackBar.open('Successfully deleted.', 'close', { duration: 5000 });
                this.refresh();
              },
                (error: Error) => {
                  this.errorService.handle(error);
                });
          }
        }
      });
  }

  public ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  public goBack(): void {
    window.history.back();
  }

  public refresh(): void {
    this.refresh$.next(new Date());
  }

  public onView(productType: ProductType): void {
    this.router.navigate(['/productType/' + productType.id]);
  }
}
