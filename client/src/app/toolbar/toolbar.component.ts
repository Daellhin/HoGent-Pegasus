import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '../user/authentication.service';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.css']
})
export class ToolbarComponent implements OnInit {

  constructor(public authService: AuthenticationService, private router: Router) { }

  ngOnInit(): void {
  }

  aboutLink() {
    window.location.href = 'https://www.lorinspeybrouck.be/';
  }

  logout() {
    this.authService.logout();
    this.router.navigate(['']);
  }

  isRegistration():boolean {
    return window.location.href.includes("inschrijven");
  }


}
