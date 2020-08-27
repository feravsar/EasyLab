import { Injectable, OnDestroy, Inject, OnInit } from '@angular/core';
import { OidcSecurityService, OpenIdConfiguration, AuthWellKnownEndpoints, AuthorizationResult, OidcConfigService } from 'angular-auth-oidc-client'
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { Subscription, Observable } from 'rxjs';


const AUTH_API = "http://aybs.akdeniz.edu.tr/";

const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};


@Injectable({
    providedIn: "root"
})

export class AuthService {

    constructor(private http: HttpClient) {

    }

    login(credentials): Observable<any> {
        return this.http.post(AUTH_API + "Auth/Login", credentials, httpOptions)
    }

    register(user): Observable<any> {
        return this.http.post(AUTH_API, "Auth/Register", httpOptions);
    }

}