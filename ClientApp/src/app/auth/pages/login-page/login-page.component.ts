import {
  Component,
  ElementRef,
  OnInit,
  TemplateRef,
  ViewChild,
} from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Store, select } from '@ngrx/store';
import { NzNotificationService } from 'ng-zorro-antd/notification';

import { AuthService } from '../../services/auth.service';
import { NotificationComponent } from 'src/app/shared/components/notification/notification.component';
import { State } from 'src/app/reducers';
import {
  selectUser,
  selectUserLoading,
} from '../../store/selectors/user.selectors';
import { Observable, combineLatest } from 'rxjs';
import User from '../../interfaces/user.interface';
import { login } from '../../store/actions/user.actions';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss'],
})
export class LoginPageComponent implements OnInit {
  loginForm!: FormGroup;
  signUpForm!: FormGroup;

  loginError: string | null = null;
  registerError: string | null = null;

  user$!: Observable<User | null>;
  userLoading$!: Observable<boolean>;

  @ViewChild('successLoginMessage')
  successLoginMessage!: TemplateRef<NotificationComponent>;

  constructor(
    private authService: AuthService,
    private router: Router,
    private notification: NzNotificationService,
    private store: Store<State>
  ) {}

  public ngOnInit() {
    this.user$ = this.store.pipe(select(selectUser));
    this.userLoading$ = this.store.pipe(select(selectUserLoading));

    combineLatest([this.user$, this.userLoading$]).subscribe(
      ([user, loading]) => {
        if (!loading && user) {
          this.router.navigate(['/me']);
        }
      }
    );

    this.loginForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', Validators.required),
    });

    this.signUpForm = new FormGroup({
      name: new FormControl('', Validators.required),
      surname: new FormControl('', Validators.required),
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [
        Validators.required,
        Validators.minLength(6),
      ]),
      confirmPassword: new FormControl('', [
        Validators.required,
        () => this.validatePasswordInput(),
      ]),
    });
  }

  public onLogin() {
    if (this.loginForm.valid) {
      this.loginError = null;
      this.store.dispatch(login({ loginCredentials: this.loginForm.value }));
      combineLatest([this.user$, this.userLoading$]).subscribe(
        ([user, loading]) => {
          if (!loading && user) {
            if (user) {
              this.router.navigate(['/me']);
              this.notification.template(this.successLoginMessage, {
                nzDuration: 5,
              });
            }
          } else {
            this.loginForm.controls['password'].setErrors([
              'Incorrect email or password!',
            ]);
            this.loginForm.controls['password'].setValue('');
          }
        }
      );
    }
  }

  public onRegister() {
    if (this.signUpForm.valid) {
      this.registerError = null;
      this.authService.registerUser(this.signUpForm.value).subscribe({
        next: () => {
          this.router.navigate(['/']);
        },
        error: () => {
          this.registerError = 'Email has already used!';
        },
      });
    }
  }

  public validatePasswordInput(): {
    passwordsNotMatch: boolean;
  } | null {
    if (
      this.signUpForm?.controls['password'].value !==
      this.signUpForm?.controls['confirmPassword'].value
    ) {
      return {
        passwordsNotMatch: true,
      };
    }
    return null;
  }
}
