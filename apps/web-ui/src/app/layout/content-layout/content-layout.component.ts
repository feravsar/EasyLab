import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-content-layout',
  templateUrl: './content-layout.component.html',
  styleUrls: ['./content-layout.component.css']
})
export class ContentLayoutComponent implements OnInit {
  isAuthorized=false;
  constructor(private authService: AuthService) {
    
  }

  ngOnInit(): void {
  }

  public login() {
    this.authService.login();
  }
 
  public logout() {
    this.authService.logout();
  }
}
