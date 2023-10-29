import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { State } from 'src/app/reducers';
import {
  selectUser,
  selectUserLoading,
} from '../../store/selectors/user.selectors';
import { Observable, map } from 'rxjs';

@Component({
  selector: 'app-profile-page',
  templateUrl: './profile-page.component.html',
  styleUrls: ['./profile-page.component.scss'],
})
export class ProfilePageComponent {
  user$ = this.store.select(selectUser);
  loading$ = this.store.select(selectUserLoading);
  constructor(private store: Store<State>) {}

  public get fullName(): Observable<string> {
    return this.user$.pipe(
      map((user) => (user ? `${user.surname} ${user.name}` : ''))
    );
  }
}
