import { createReducer, on } from '@ngrx/store';
import {
  BaseAutoDto,
  Engine,
  Generation,
  SaleAnnouncement,
} from '../../interfaces/Auto';
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

export const autoFeatureKey = 'auto';

export interface AutoState {
  brands: BaseAutoDto[];
  models: BaseAutoDto[];
  generations: Generation[];
  engines: Engine[];
  equipments: BaseAutoDto[];
  announcements: SaleAnnouncement[] | null;
  loading: boolean;
}

export const initialState: AutoState = {
  brands: [],
  models: [],
  generations: [],
  engines: [],
  equipments: [],
  announcements: null,
  loading: false,
};

export const autoReducer = createReducer(
  initialState,
  on(fetchBrands, (state) => ({ ...state, loading: true })),
  on(fetchBrandsSuccess, (state, { brands }) => {
    return {
      ...state,
      brands,
      loading: false,
    };
  }),
  on(fetchBrandsFailure, (state, { error }) => {
    return { ...state, error };
  }),

  on(fetchModels, (state) => ({ ...state, loading: true })),
  on(fetchModelsSuccess, (state, { models }) => {
    return {
      ...state,
      models,
      loading: false,
    };
  }),
  on(fetchModelsFailure, (state, { error }) => {
    return { ...state, error };
  }),

  on(fetchGenerations, (state) => ({ ...state, loading: true })),
  on(fetchGenerationsSuccess, (state, { generations }) => {
    return {
      ...state,
      generations,
      loading: false,
    };
  }),
  on(fetchGenerationsFailure, (state, { error }) => {
    return { ...state, error };
  }),

  on(fetchEngines, (state) => ({ ...state, loading: true })),
  on(fetchEnginesSuccess, (state, { engines }) => {
    return {
      ...state,
      engines,
      loading: false,
    };
  }),
  on(fetchEnginesFailure, (state, { error }) => {
    return { ...state, error };
  }),

  on(fetchEquipments, (state) => ({ ...state, loading: true })),
  on(fetchEquipmentsSuccess, (state, { equipments }) => {
    return {
      ...state,
      equipments,
      loading: false,
    };
  }),
  on(fetchEquipmentsFailure, (state, { error }) => {
    return { ...state, error };
  }),

  on(fetchAnnouncements, (state) => ({ ...state, loading: true })),
  on(fetchAnnouncementsSuccess, (state, { announcements }) => {
    return {
      ...state,
      announcements,
      loading: false,
    };
  }),
  on(fetchAnnouncementsFailure, (state, { error }) => {
    return { ...state, error };
  })
);
