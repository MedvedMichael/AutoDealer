import { createReducer, on } from '@ngrx/store';
import User from '../../interfaces/user.interface';
import {
  cleanError,
  login,
  loginFailure,
  loginSuccess,
  logout,
  register,
  registerFailure,
  registerSuccess,
  setUser,
} from '../actions/user.actions';

export const userFeatureKey = 'user';

export interface UserState {
  user: User | null;
  token: string | null;
  loading: boolean;
  error: string | null;
}

export const initialState: UserState = {
  user: null,
  token: null,
  loading: true,
  error: null,
};

export const userReducer = createReducer(
  initialState,
  on(setUser, (state, { user, token }) => {
    return { ...state, user, token, loading: false };
  }),
  on(cleanError, (state) => ({ ...state, error: null })),
  on(login, (state) => ({ ...state, loading: true })),
  on(loginSuccess, (state, { user, token }) => {
    return {
      ...state,
      user,
      token,
      loading: false,
    };
  }),
  on(loginFailure, (state, { error }) => {
    return { ...state, error };
  }),
  on(register, (state) => ({ ...state, loading: true })),
  on(registerSuccess, (state, { user, token }) => {
    return {
      ...state,
      user,
      token,
      loading: false,
    };
  }),
  on(registerFailure, (state, { error }) => {
    return { ...state, error };
  }),
  on(logout, (state) => {
    return { ...state, user: null, token: null };
  })
);
