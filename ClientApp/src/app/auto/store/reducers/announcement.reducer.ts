import { createReducer, on } from '@ngrx/store';
import { SaleAnnouncement } from '../../interfaces/Auto';
import {
  fetchAnnouncement,
  fetchAnnouncementSuccess,
  fetchAnnouncementFailure,
} from '../actions/announcement.actions';

export const announcementFeatureKey = 'announcement';

export interface AnnouncementState {
  loading: boolean;
  announcement: SaleAnnouncement | null;
}

export const initialState: AnnouncementState = {
  loading: false,
  announcement: null,
};

export const announcementReducer = createReducer(
  initialState,
  on(fetchAnnouncement, (state) => ({ ...state, loading: true })),
  on(fetchAnnouncementSuccess, (state, { announcement }) => {
    return {
      ...state,
      announcement: announcement,
      loading: false,
    };
  }),
  on(fetchAnnouncementFailure, (state, { error }) => {
    return { ...state, error };
  })
);
