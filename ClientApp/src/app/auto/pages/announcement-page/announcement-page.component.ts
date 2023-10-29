import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import {
  BehaviorSubject,
  Observable,
  catchError,
  concatMap,
  map,
  of,
  startWith,
  switchMap,
  tap,
} from 'rxjs';
import { AutoService } from '../../services/auto.service';
import {
  FuelTypeLabel,
  GearboxTypeLabel,
  SaleAnnouncement,
} from '../../interfaces/Auto';
import { AutoState } from '../../store/reducers/auto.reducer';
import { Store } from '@ngrx/store';
import { fetchAnnouncement } from '../../store/actions/announcement.actions';
import { selectAnnouncement } from '../../store/selectors/announcement.selectors';

@Component({
  selector: 'app-announcement-page',
  templateUrl: './announcement-page.component.html',
  styleUrls: ['./announcement-page.component.scss'],
})
export class AnnouncementPageComponent implements OnInit {
  array = Array.from({ length: 5 }, (_, i) => i);
  images = [
    'assets/auto.jpg',
    'https://zos.alipayobjects.com/rmsportal/ODTLcjxAfvqbxHnVXCYX.png',
    'https://ireland.apollo.olxcdn.com/v1/files/cg4mdwawb553-UA/image;s=1000x750',
  ];
  announcement$: BehaviorSubject<SaleAnnouncement | null> =
    new BehaviorSubject<SaleAnnouncement | null>(null);
  private fuelTypeLabelEnum = FuelTypeLabel;
  private gearboxTypeLabelEnum = GearboxTypeLabel;

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private autoService: AutoService,
    private store: Store<AutoState>
  ) {}

  ngOnInit(): void {
    this.activatedRoute.params
      .pipe(
        map((params) => {
          this.announcement$.next(null);
          this.store.dispatch(fetchAnnouncement({ id: params.id }));
        })
      )
      .subscribe();

    this.store.select(selectAnnouncement).subscribe((announcement) => {
      this.announcement$.next(announcement);
    });
  }

  public get fuelTypeLabel(): Observable<string> {
    return this.announcement$.pipe(
      map((announcement) => {
        return announcement
          ? this.fuelTypeLabelEnum[announcement.car.engine.fuelType]
          : '';
      })
    );
  }

  public get gearboxTypeLabel(): Observable<string> {
    return this.announcement$.pipe(
      map((announcement) => {
        return announcement
          ? this.gearboxTypeLabelEnum[announcement.car.gearbox.type]
          : '';
      })
    );
  }

  public get winUrl(): Observable<string> {
    return this.announcement$.pipe(
      map((announcement) => {
        return announcement
          ? `https://google.com/search?q=${announcement.car.winNumber}`
          : '';
      })
    );
  }

  public get descriptionLines(): Observable<string[]> {
    return this.announcement$.pipe(
      map((announcement) => {
        return announcement
          ? announcement.description.split('\n').filter((x) => x)
          : [];
      })
    );
  }
}
