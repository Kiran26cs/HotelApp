import { Component } from '@angular/core';
import { AuthenticationService } from '../authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  public _authService: AuthenticationService;
  constructor(public authService: AuthenticationService, public router: Router) {
    this._authService = authService;
  }
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  isLoggedIn() {
    return this._authService.isAthorized();
  }

  logout() {
    this._authService.logout();
    this.router.navigate(['/']);
  }
}
