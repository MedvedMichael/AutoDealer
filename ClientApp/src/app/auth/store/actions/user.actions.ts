import { createAction, props } from '@ngrx/store';
import User, {
  LoginCredentials,
  RegisterCredentials,
} from '../../interfaces/user.interface';

export const initUser = createAction('[User] Init User');

export const setUser = createAction(
  '[User] Set User',
  props<{ user: User | null; token: string | null }>()
);

export const cleanError = createAction('[User] Clean Error');

export const login = createAction(
  '[User] Login',
  props<{ loginCredentials: LoginCredentials }>()
);

export const loginSuccess = createAction(
  '[User] Login Success',
  props<{ user: User; token: string }>()
);

export const loginFailure = createAction(
  '[User] Login Failure',
  props<{ error: string }>()
);

export const register = createAction(
  '[User] Register',
  props<{ registerCredentials: RegisterCredentials }>()
);

export const registerSuccess = createAction(
  '[User] Register Success',
  props<{ user: User; token: string }>()
);

export const registerFailure = createAction(
  '[User] Register Failure',
  props<{ error: string }>()
);

export const logout = createAction('[User] Logout');
