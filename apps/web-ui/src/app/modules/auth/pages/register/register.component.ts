import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  mail:string = null;
  password:string = null;
  confirmPassword:string = null;
  name:string = null;
  surname:string = null;
  constructor() { }

  ngOnInit(): void {
  }

}
