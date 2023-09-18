import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable, tap } from 'rxjs';
import User, {
  LoginCredentials,
  RegisterCredentials,
} from '../interfaces/user.interface';
import { TokenStorageService } from './token-storage.service';

interface ApiUser {
  token: string;
  user: User;
}

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly baseUrl = 'http://localhost:5046/auth';
  private user: User | null = null;

  constructor(
    private httpClient: HttpClient,
    private tokenStorageService: TokenStorageService
  ) {
    if (this.tokenStorageService.getAccessToken()) {
      this.getCurrentUser().subscribe((user) => {
        this.user = user;
      });
    }
  }

  private updateCurrentUserData(apiUser: ApiUser) {
    console.log(apiUser);
    this.tokenStorageService.setAccessToken(apiUser.token);
    this.user = apiUser.user;
  }

  public registerUser({
    email,
    password,
    name,
    surname,
  }: RegisterCredentials): Observable<User> {
    return this.httpClient
      .post<ApiUser>(`${this.baseUrl}/register`, {
        email,
        password,
        name,
        surname,
      })
      .pipe(
        tap((user) => this.updateCurrentUserData(user)),
        map((res) => res.user)
      );
  }

  public loginUser({ email, password }: LoginCredentials): Observable<User> {
    return this.httpClient
      .post<ApiUser>(`${this.baseUrl}/login`, {
        email,
        password,
      })
      .pipe(
        tap((user) => this.updateCurrentUserData(user)),
        map((res) => res.user)
      );
  }

  private getCurrentUser(): Observable<User> {
    return this.httpClient.get<User>(`${this.baseUrl}/me`);
  }

  public logout() {
    this.tokenStorageService.removeToken();
  }
}
