import { createAction, props } from '@ngrx/store';
import {
  BaseAutoDto,
  Engine,
  Generation,
  SaleAnnouncement,
  SearchRequest,
} from '../../interfaces/Auto';

export const fetchBrands = createAction('[Auto] Init Brands');

export const fetchBrandsSuccess = createAction(
  '[Auto] Set Brands',
  props<{ brands: BaseAutoDto[] }>()
);

export const fetchBrandsFailure = createAction(
  '[Auto] Set Brands Failure',
  props<{ error: string }>()
);

export const fetchModels = createAction(
  '[Auto] Fetch Models',
  props<{ brandId: number }>()
);

export const fetchModelsSuccess = createAction(
  '[Auto] Fetch Models Success',
  props<{ models: BaseAutoDto[] }>()
);

export const fetchModelsFailure = createAction(
  '[Auto] Fetch Models Failure',
  props<{ error: string }>()
);

export const fetchGenerations = createAction(
  '[Auto] Fetch Generations',
  props<{ modelId: number }>()
);

export const fetchGenerationsSuccess = createAction(
  '[Auto] Fetch Generations Success',
  props<{ generations: Generation[] }>()
);

export const fetchGenerationsFailure = createAction(
  '[Auto] Fetch Generations Failure',
  props<{ error: string }>()
);

export const fetchEngines = createAction(
  '[Auto] Fetch Engines',
  props<{ modelId: number }>()
);

export const fetchEnginesSuccess = createAction(
  '[Auto] Fetch Engines Success',
  props<{ engines: Engine[] }>()
);

export const fetchEnginesFailure = createAction(
  '[Auto] Fetch Engines Failure',
  props<{ error: string }>()
);

export const fetchEquipments = createAction(
  '[Auto] Fetch Equipments',
  props<{ modelId: number }>()
);

export const fetchEquipmentsSuccess = createAction(
  '[Auto] Fetch Equipments Success',
  props<{ equipments: BaseAutoDto[] }>()
);

export const fetchEquipmentsFailure = createAction(
  '[Auto] Fetch Equipments Failure',
  props<{ error: string }>()
);

export const fetchAnnouncements = createAction(
  '[Auto] Fetch Announcements',
  props<{ search: SearchRequest }>()
);

export const fetchAnnouncementsSuccess = createAction(
  '[Auto] Fetch Announcements Success',
  props<{ announcements: SaleAnnouncement[] }>()
);

export const fetchAnnouncementsFailure = createAction(
  '[Auto] Fetch Announcements Failure',
  props<{ error: string }>()
);

export const clearBrand = createAction('[Auto] Clear Brand');

export const clearModel = createAction('[Auto] Clear Model');

export const clearGeneration = createAction('[Auto] Clear Generation');
