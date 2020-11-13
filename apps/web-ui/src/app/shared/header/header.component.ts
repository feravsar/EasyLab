import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TokenStorageService } from '@app/services/token-storage.service';
import { AuthService } from '../../core/services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  isAuthorized=false;
  isTeachervisible=false;
  isStudentVisible=false;
  
  
  constructor(private authService: AuthService, private tokenStorageService : TokenStorageService, private router: Router) {
    
  }




  ngOnInit(): void {
    var roles = this.tokenStorageService.getRoles();
    this.isTeachervisible = roles.includes("TEACHER");
    this.isStudentVisible = roles.includes("STUDENT");
  }

  logout()
  {
    this.tokenStorageService.signOut();
    this.router.navigate(["auth/login"]);
  }

}
