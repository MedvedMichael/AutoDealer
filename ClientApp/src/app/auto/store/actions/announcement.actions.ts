import { createAction, props } from '@ngrx/store';
import { SaleAnnouncement } from '../../interfaces/Auto';

export const fetchAnnouncement = createAction(
  '[Auto] Fetch Announcement',
  props<{ id: number }>()
);

export const fetchAnnouncementSuccess = createAction(
  '[Auto] Fetch Announcement Success',
  props<{ announcement: SaleAnnouncement }>()
);

export const fetchAnnouncementFailure = createAction(
  '[Auto] Fetch Announcement Failure',
  props<{ error: string }>()
);
