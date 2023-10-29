import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { State } from './reducers';
import { selectUserLoading } from './auth/store/selectors/user.selectors';
import { BehaviorSubject, combineLatest } from 'rxjs';

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
    combineLatest([userLoading$]).subscribe(([userLoading]) => {
      this.loading$.next(userLoading);
    });
  }
}
