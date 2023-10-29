import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { AutoService } from '../../services/auto.service';
import {
  fetchAnnouncement,
  fetchAnnouncementSuccess,
} from '../actions/announcement.actions';
import { catchError, map, mergeMap, of } from 'rxjs';
import { fetchAnnouncementsFailure } from '../actions/auto.actions';

@Injectable()
export class AnnouncementEffects {
  constructor(private actions$: Actions, private autoService: AutoService) {}

  fetchAnnouncement$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fetchAnnouncement),
      mergeMap(({ id }) => {
        return this.autoService.getSaleAnnouncement(id).pipe(
          map((announcement) => fetchAnnouncementSuccess({ announcement })),
          catchError(({ error }) => of(fetchAnnouncementsFailure({ error })))
        );
      })
    )
  );
}
