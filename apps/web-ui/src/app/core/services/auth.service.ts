import { Injectable, OnDestroy, Inject, OnInit } from '@angular/core';
import { OidcSecurityService, OpenIdConfiguration, AuthWellKnownEndpoints, AuthorizationResult, OidcConfigService } from 'angular-auth-oidc-client'
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { Subscription, Observable } from 'rxjs';
import { environment } from '@env' 



@Injectable({
    providedIn: "root"
})

export class AuthService {

    constructor(private http: HttpClient) {

    }

    login(credentials): Observable<any> {
        return this.http.post(environment.API_URL + "Auth/Login", credentials)
    }



}