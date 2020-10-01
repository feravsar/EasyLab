import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/core/services/auth.service';
import { TokenStorageService } from 'src/app/core/services/token-storage.service'
import { RegisterError } from 'src/app/shared/models/response/account/RegisterError';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  username: string = null;
  password: string = null;

  errors: RegisterError = new RegisterError();

  constructor(private authService: AuthService,
    private tokenStorageService: TokenStorageService,
    private router: Router) { }

  ngOnInit(): void {
    let user = this.tokenStorageService.getUser();
    if (user != null)
    {
      if (user.roles.includes("TEACHER")) {
        this.router.navigate(["teacher"])
      }
      else {
        this.router.navigate(["student"])
      }
    }
  }

  onSubmit() {
    this.authService.login({
      username: this.username,
      password: this.password
    }
    ).subscribe(
      data => {
        this.tokenStorageService.saveToken(data.accessToken.token);
        this.tokenStorageService.saveUser(data.userInfo);
        if (data.userInfo.roles.includes("TEACHER")) {
          this.router.navigate(["teacher"])
        }
        else {
          this.router.navigate(["student"])
        }
      },
      e => {
        if (e.error.errors instanceof Array) {
          this.errors.CustomErrors = e.error.errors;
        }
        else {
          this.errors = e.error.errors;
        }

      }
    );
  }
}
