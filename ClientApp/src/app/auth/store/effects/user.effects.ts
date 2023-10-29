import { Injectable } from '@angular/core';
import { Actions, OnInitEffects, createEffect, ofType } from '@ngrx/effects';
import {
  initUser,
  login,
  loginFailure,
  loginSuccess,
  register,
  registerFailure,
  registerSuccess,
  setUser,
} from '../actions/user.actions';
import { Action } from '@ngrx/store';
import { AuthService } from '../../services/auth.service';
import { TokenStorageService } from '../../services/token-storage.service';
import { catchError, map, mergeMap, of } from 'rxjs';

@Injectable()
export class UserEffects implements OnInitEffects {
  constructor(
    private actions$: Actions,
    private authService: AuthService,
    private tokenStorageService: TokenStorageService
  ) {}

  ngrxOnInitEffects(): Action {
    return initUser();
  }

  init$ = createEffect(() =>
    this.actions$.pipe(
      ofType(initUser),
      mergeMap(() => {
        const token = this.tokenStorageService.getAccessToken();
        if (token) {
          return this.authService.getProfile().pipe(
            map((user) =>
              setUser({
                user,
                token: this.tokenStorageService.getAccessToken(),
              })
            ),
            catchError(() => of(setUser({ user: null, token: null })))
          );
        }
        return of(setUser({ user: null, token: null }));
      })
    )
  );

  login$ = createEffect(() =>
    this.actions$.pipe(
      ofType(login),
      mergeMap(({ loginCredentials }) =>
        this.authService.loginUser(loginCredentials).pipe(
          map(({ user, token }) => {
            this.tokenStorageService.setAccessToken(token);
            return loginSuccess({ user, token });
          }),
          catchError(({ error }) => of(loginFailure({ error })))
        )
      )
    )
  );

  register$ = createEffect(() =>
    this.actions$.pipe(
      ofType(register),
      mergeMap(({ registerCredentials }) =>
        this.authService.registerUser(registerCredentials).pipe(
          map(({ user, token }) => {
            this.tokenStorageService.setAccessToken(token);
            return registerSuccess({ user, token });
          }),
          catchError(({ error }) => of(registerFailure({ error })))
        )
      )
    )
  );
}
