import { inject } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import { Store } from '@ngrx/store';
import { combineLatest, map } from 'rxjs';
import { State } from 'src/app/reducers';
import {
  selectUser,
  selectUserLoading,
} from '../store/selectors/user.selectors';

export const AuthGuard: CanActivateFn = () => {
  const store = inject(Store<State>);

  const user$ = store.select(selectUser);
  const loading$ = store.select(selectUserLoading);

  return combineLatest([user$, loading$]).pipe(
    map(([user, loading]) => {
      return loading || !!user;
    })
  );
};
