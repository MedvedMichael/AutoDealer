import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import User from 'src/app/auth/interfaces/user.interface';
import { selectUser } from 'src/app/auth/store/selectors/user.selectors';
import { State } from 'src/app/reducers';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent {
  user$: Observable<User | null>;
  constructor(
    public activatedRoute: ActivatedRoute,
    private store: Store<State>
  ) {
    this.user$ = this.store.select(selectUser);
  }
}
