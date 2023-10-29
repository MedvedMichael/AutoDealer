import { createFeatureSelector, createSelector } from '@ngrx/store';
import { AutoState, autoFeatureKey } from '../reducers/auto.reducer';

export const selectUserState = createFeatureSelector<AutoState>(autoFeatureKey);

export const selectBrands = createSelector(
  selectUserState,
  (state: AutoState) => state.brands
);

export const selectModels = createSelector(
  selectUserState,
  (state: AutoState) => state.models
);

export const selectGenerations = createSelector(
  selectUserState,
  (state: AutoState) => state.generations
);

export const selectEngines = createSelector(
  selectUserState,
  (state: AutoState) => state.engines
);

export const selectEquipments = createSelector(
  selectUserState,
  (state: AutoState) => state.equipments
);

export const selectAnnouncements = createSelector(
  selectUserState,
  (state: AutoState) => state.announcements
);

export const selectAutoLoading = createSelector(
  selectUserState,
  (state: AutoState) => state.loading
);
