import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/core/services/account.service';
import { Router } from '@angular/router';
import { RegisterError } from 'src/app/shared/models/response/account/RegisterError'

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  mail: string = null;
  password: string = null;
  confirmPassword: string = null;
  name: string = null;
  surname: string = null;
  errors: RegisterError = new RegisterError();

  constructor(
    private accountService: AccountService,
    private router: Router) {

  }

  ngOnInit(): void {
  }

  onSubmit() {
    this.accountService.register({
      name: this.name,
      surname: this.surname,
      email: this.mail,
      password: this.password,
      confirmPassword: this.password
    }).subscribe(
      data => {
        if (data.success) {
          this.router.navigate(['/auth/login'])
        }
      },
      e => {
        if (e.error.errors instanceof Array) {
          this.errors.CustomErrors = e.error.errors;
        }
        else {
          this.errors = e.error.errors;
        }
      });
  }
}
