import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, map, switchMap, catchError, of, startWith } from 'rxjs';
import {
  SaleAnnouncement,
  FuelTypeLabel,
  GearboxTypeLabel,
} from '../../interfaces/Auto';
import { AutoService } from '../../services/auto.service';
import { Store } from '@ngrx/store';
import { AutoState } from '../../store/reducers/auto.reducer';
import {
  selectBrands,
  selectModels,
  selectGenerations,
  selectEngines,
  selectEquipments,
} from '../../store/selectors/auto.selectors';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {
  fetchEngines,
  fetchEquipments,
  fetchGenerations,
  fetchModels,
} from '../../store/actions/auto.actions';

@Component({
  selector: 'app-edit-announcement-page',
  templateUrl: './edit-announcement-page.component.html',
  styleUrls: ['./edit-announcement-page.component.scss'],
})
export class EditAnnouncementPageComponent {
  array = Array.from({ length: 5 }, (_, i) => i);
  years = Array.from(
    { length: new Date().getFullYear() - 1900 + 1 },
    (_, i) => new Date().getFullYear() - i
  );
  images = [
    'assets/auto.jpg',
    'https://zos.alipayobjects.com/rmsportal/ODTLcjxAfvqbxHnVXCYX.png',
    'https://ireland.apollo.olxcdn.com/v1/files/cg4mdwawb553-UA/image;s=1000x750',
  ];
  announcement$!: Observable<SaleAnnouncement | null>;
  private fuelTypeLabelEnum = FuelTypeLabel;
  private gearboxTypeLabelEnum = GearboxTypeLabel;

  brands$ = this.store.select(selectBrands);
  models$ = this.store.select(selectModels);
  generations$ = this.store.select(selectGenerations);
  engines$ = this.store.select(selectEngines);
  equipments$ = this.store.select(selectEquipments);

  autoFilterForm!: FormGroup;

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private autoService: AutoService,
    private store: Store<AutoState>,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.autoFilterForm = this.fb.group({
      brand: [null, Validators.required],
      model: [null, Validators.required],
      generation: [null, Validators.required],
      engine: [null, Validators.required],
      equipment: [null, Validators.required],
      price: [null, Validators.required],
      year: [null, Validators.required],
      mileage: [null, Validators.required],
    });

    this.autoFilterForm.controls.brand.valueChanges.subscribe((brandId) => {
      if (brandId) {
        this.store.dispatch(fetchModels({ brandId }));
      }
      this.autoFilterForm.controls.model.setValue(null);
    });

    this.autoFilterForm.controls.model.valueChanges.subscribe((modelId) => {
      if (modelId) {
        this.store.dispatch(fetchGenerations({ modelId }));
        this.store.dispatch(fetchEngines({ modelId }));
        this.store.dispatch(fetchEquipments({ modelId }));
      }

      this.autoFilterForm.controls.generation.setValue(null);
      this.autoFilterForm.controls.engine.setValue(null);
      this.autoFilterForm.controls.equipment.setValue(null);
    });

    this.announcement$ = this.activatedRoute.params.pipe(
      map((params) => params.id),
      switchMap((id) => this.autoService.getSaleAnnouncement(id)),
      catchError(() => {
        this.router.navigate(['/']);
        return of(null);
      })
    );
  }
}
