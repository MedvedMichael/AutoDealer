import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, catchError, map, of, switchMap } from 'rxjs';
import { AutoService } from '../../services/auto.service';
import {
  FuelTypeLabel,
  GearboxTypeLabel,
  SaleAnnouncement,
} from '../../interfaces/Auto';

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
  announcement$!: Observable<SaleAnnouncement | null>;
  private fuelTypeLabelEnum = FuelTypeLabel;
  private gearboxTypeLabelEnum = GearboxTypeLabel;

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private autoService: AutoService
  ) {}

  ngOnInit(): void {
    this.announcement$ = this.activatedRoute.params.pipe(
      map((params) => params.id),
      switchMap((id) => this.autoService.getSaleAnnouncement(id)),
      catchError(() => {
        this.router.navigate(['/auto']);
        return of(null);
      })
    );
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
