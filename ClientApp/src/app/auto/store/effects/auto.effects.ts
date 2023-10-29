import { Injectable } from '@angular/core';
import { Actions, OnInitEffects, createEffect, ofType } from '@ngrx/effects';
import { Action } from '@ngrx/store';
import { catchError, map, mergeMap, of } from 'rxjs';
import { AutoService } from '../../services/auto.service';
import {
  fetchAnnouncements,
  fetchAnnouncementsFailure,
  fetchAnnouncementsSuccess,
  fetchBrands,
  fetchBrandsFailure,
  fetchBrandsSuccess,
  fetchEngines,
  fetchEnginesFailure,
  fetchEnginesSuccess,
  fetchEquipments,
  fetchEquipmentsFailure,
  fetchEquipmentsSuccess,
  fetchGenerations,
  fetchGenerationsFailure,
  fetchGenerationsSuccess,
  fetchModels,
  fetchModelsFailure,
  fetchModelsSuccess,
} from '../actions/auto.actions';

@Injectable()
export class AutoEffects implements OnInitEffects {
  constructor(private actions$: Actions, private autoService: AutoService) {}

  ngrxOnInitEffects(): Action {
    return fetchBrands();
  }

  init$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fetchBrands),
      mergeMap(() => {
        return this.autoService.getBrands().pipe(
          map((brands) =>
            fetchBrandsSuccess({
              brands,
            })
          ),
          catchError(({ error }) => of(fetchBrandsFailure({ error })))
        );
      })
    )
  );

  fetchModels$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fetchModels),
      mergeMap(({ brandId }) => {
        return this.autoService.getModels(brandId).pipe(
          map((models) =>
            fetchModelsSuccess({
              models,
            })
          ),
          catchError(({ error }) => of(fetchModelsFailure({ error })))
        );
      })
    )
  );

  fetchGenerations$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fetchGenerations),
      mergeMap(({ modelId }) => {
        return this.autoService.getGenerations(modelId).pipe(
          map((generations) => fetchGenerationsSuccess({ generations })),
          catchError(({ error }) => of(fetchGenerationsFailure({ error })))
        );
      })
    )
  );

  fetchEngines$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fetchEngines),
      mergeMap(({ modelId }) => {
        return this.autoService.getEngines(modelId).pipe(
          map((engines) => fetchEnginesSuccess({ engines })),
          catchError(({ error }) => of(fetchEnginesFailure({ error })))
        );
      })
    )
  );

  fetchEquipments$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fetchEquipments),
      mergeMap(({ modelId }) => {
        return this.autoService.getEquipments(modelId).pipe(
          map((equipments) => fetchEquipmentsSuccess({ equipments })),
          catchError(({ error }) => of(fetchEquipmentsFailure({ error })))
        );
      })
    )
  );

  fetchAnnouncements$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fetchAnnouncements),
      mergeMap(({ search }) => {
        return this.autoService.getSaleAnnouncements(search).pipe(
          map((announcements) => fetchAnnouncementsSuccess({ announcements })),
          catchError(({ error }) => of(fetchAnnouncementsFailure({ error })))
        );
      })
    )
  );
}
