import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { State } from 'src/app/reducers';
import {
  selectAnnouncements,
  selectBrands,
  selectGenerations,
  selectModels,
} from '../../store/selectors/auto.selectors';
import {
  fetchAnnouncements,
  fetchGenerations,
  fetchModels,
} from '../../store/actions/auto.actions';
import { Observable, map, of, startWith, tap } from 'rxjs';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss'],
})
export class HomePageComponent implements OnInit {
  autoFilterForm!: FormGroup;
  years = Array.from(
    { length: new Date().getFullYear() - 1900 + 1 },
    (_, i) => new Date().getFullYear() - i
  );

  brands$ = this.store.select(selectBrands);
  models$ = this.store.select(selectModels);
  generations$ = this.store.select(selectGenerations);
  announcements$ = this.store.select(selectAnnouncements);

  constructor(
    private fb: FormBuilder,
    private store: Store<State>,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.autoFilterForm = this.fb.group({
      brand: [null, Validators.required],
      models: [[]],
      generations: [[]],
      price: this.fb.group({
        from: [null, Validators.min(0)],
        to: [null, Validators.min(0)],
      }),
      year: this.fb.group({
        from: [null],
        to: [null],
      }),
      mileage: this.fb.group({
        from: [null, Validators.min(0)],
        to: [null, Validators.min(0)],
      }),
    });

    this.autoFilterForm.controls.brand.valueChanges.subscribe((brandId) => {
      if (brandId) {
        this.store.dispatch(fetchModels({ brandId }));
      }
      this.autoFilterForm.controls.models.setValue([]);
    });

    this.autoFilterForm.controls.models.valueChanges.subscribe((models) => {
      if (models.length === 1) {
        this.store.dispatch(fetchGenerations({ modelId: models[0] }));
      }

      this.autoFilterForm.controls.generations.setValue([]);
    });
  }

  public get fromYears(): Observable<number[]> {
    return (
      this.autoFilterForm.controls.year.get('to')?.valueChanges.pipe(
        startWith(this.autoFilterForm.controls.year.get('to')?.value),
        map((to) => {
          if (!to) {
            return this.years;
          }

          return this.years.filter((year) => year <= to);
        })
      ) ?? of(this.years)
    );
  }

  public get toYears(): Observable<number[]> {
    return (
      this.autoFilterForm.controls.year.get('from')?.valueChanges.pipe(
        startWith(this.autoFilterForm.controls.year.get('from')?.value),
        map((from) => {
          if (!from) {
            return this.years;
          }

          return this.years.filter((year) => year >= from);
        })
      ) ?? of(this.years)
    );
  }

  public searchAnnouncements(): void {
    const { brand, models, generations, price, year, mileage } =
      this.autoFilterForm.value;
    this.store.dispatch(
      fetchAnnouncements({
        search: {
          brand,
          models,
          generations: generations.length ? generations : null,
          price: {
            from: price.from,
            to: price.to,
          },
          year: {
            from: year.from,
            to: year.to,
          },
          mileage: {
            from: mileage.from,
            to: mileage.to,
          },
        },
      })
    );
  }
}
