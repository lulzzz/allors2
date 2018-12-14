import { AfterViewInit, Component, OnDestroy, OnInit, Self } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { switchMap } from 'rxjs/operators';

import { ErrorService, Loaded, ContextService, MetaService } from '../../../../../angular';
import { Locale, Person } from '../../../../../domain';
import { PullRequest } from '../../../../../framework';
import { Meta } from '../../../../../meta';

@Component({
  templateUrl: './person-overview.component.html',
  providers: [ContextService]
})
export class PersonOverviewComponent implements OnInit, AfterViewInit, OnDestroy {

  public m: Meta;
  public person: Person;
  public locales: Locale[];

  public title: string;

  private subscription: Subscription;

  constructor(
    @Self() private allors: ContextService,
    private metaService: MetaService,
    private errorService: ErrorService,
    private titleService: Title,
    private route: ActivatedRoute) {

    this.title = 'Person Overview';
    this.titleService.setTitle(this.title);
    this.m = this.metaService.m;
  }

  public ngOnInit(): void {

    const { x, pull } = this.metaService;

    this.subscription = this.route.url
      .pipe(
        switchMap((url: any) => {

          const id: string = this.route.snapshot.paramMap.get('id');

          const pulls = [
            pull.Person({
              object: id,
              include: {
                Photo: x,
              }
            })
          ];

          this.allors.context.reset();

          return this.allors.context
            .load('Pull', new PullRequest({ pulls }));
        })
      )
      .subscribe((loaded: Loaded) => {
        this.person = loaded.objects.Person as Person;
      },
        (error: any) => {
          this.errorService.handle(error);
          this.goBack();
        },
      );
  }

  public ngAfterViewInit(): void {
  }

  public ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  public goBack(): void {
    window.history.back();
  }

  public checkType(obj: any): string {
    return obj.objectType.name;
  }
}
