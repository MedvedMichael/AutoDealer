import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { interval, map, mergeMap, Observable, tap } from 'rxjs';
import User, {
  LoginCredentials,
  RegisterCredentials,
} from '../interfaces/user.interface';
import { API_BASE_URL } from 'src/app/app.module';

interface ApiUser {
  token: string;
  user: User;
}

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly baseUrl = `${this.apiBaseUrl}/auth`;

  constructor(
    private httpClient: HttpClient,
    @Inject(API_BASE_URL) private apiBaseUrl: string
  ) {}

  public registerUser({
    email,
    password,
    name,
    surname,
  }: RegisterCredentials): Observable<ApiUser> {
    return this.httpClient.post<ApiUser>(`${this.baseUrl}/register`, {
      email,
      password,
      name,
      surname,
    });
  }

  public loginUser({ email, password }: LoginCredentials): Observable<ApiUser> {
    return this.httpClient.post<ApiUser>(`${this.baseUrl}/login`, {
      email,
      password,
    });
  }

  public getProfile(): Observable<User> {
    return this.httpClient
      .get<User>(`${this.baseUrl}/me`)
      .pipe(mergeMap((user) => interval(1500).pipe(map(() => user))));
  }
}
