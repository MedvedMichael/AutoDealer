import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { State } from './reducers';
import { selectUserLoading } from './auth/store/selectors/user.selectors';
import { BehaviorSubject, combineLatest } from 'rxjs';
import { selectAutoLoading } from './auto/store/selectors/auto.selectors';
import { selectAnnouncementLoading } from './auto/store/selectors/announcement.selectors';

@Component({
  selector: 'app-root',
  styleUrls: ['./app.component.scss'],
  templateUrl: './app.component.html',
})
export class AppComponent {
  title = 'app';

  loading$: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

  constructor(private store: Store<State>) {
    const userLoading$ = this.store.select(selectUserLoading);
    const announcementLoading$ = this.store.select(selectAnnouncementLoading);

    combineLatest([userLoading$, announcementLoading$]).subscribe(
      ([userLoading, announcementLoading]) => {
        this.loading$.next(userLoading || announcementLoading);
      }
    );
  }
}
