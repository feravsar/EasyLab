import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthModule, OidcSecurityService } from 'angular-auth-oidc-client';
import { AuthService } from './services/auth.service'




@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    AuthModule.forRoot()
  ],
  providers:[
    AuthService,
    OidcSecurityService
  ]
})
export class CoreModule { }
