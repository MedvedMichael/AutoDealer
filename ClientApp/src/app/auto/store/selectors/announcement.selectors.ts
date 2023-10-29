import { createFeatureSelector, createSelector } from '@ngrx/store';
import {
  AnnouncementState,
  announcementFeatureKey,
} from '../reducers/announcement.reducer';

export const selectAnnouncementState = createFeatureSelector<AnnouncementState>(
  announcementFeatureKey
);

export const selectAnnouncement = createSelector(
  selectAnnouncementState,
  (state: AnnouncementState) => state.announcement
);

export const selectAnnouncementLoading = createSelector(
  selectAnnouncementState,
  (state: AnnouncementState) => state.loading
);
