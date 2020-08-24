import { Injectable, OnDestroy, Inject, OnInit } from '@angular/core';
import { OidcSecurityService, OpenIdConfiguration, AuthWellKnownEndpoints, AuthorizationResult, OidcConfigService } from 'angular-auth-oidc-client'
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Subscription, Observable } from 'rxjs';

@Injectable({
    providedIn: "root"
})
export class AuthService {
    isAuthorized = false;
    private isAuthorizedSubscription: Subscription = new Subscription;
    private authUrl = "https://localhost:5001";
    private originUrl = "http://localhost:4200"
    constructor(
        private oidcSecurityService: OidcSecurityService,
        private oidcConfigService: OidcConfigService,
        private http: HttpClient,
        private router: Router
    ) { }


    ngOnDestroy(): void {
        if (this.isAuthorizedSubscription) {
            this.isAuthorizedSubscription.unsubscribe();
        }
    }
      ngOnInit(): void {
          const openIdConfiguration: OpenIdConfiguration = {
              stsServer: this.authUrl,
              redirectUrl: this.originUrl + 'callback',
              clientId: 'easy-lab-angular-client',
              responseType: 'code',
              scope: 'openid profile easy-lab-webapi',
              postLogoutRedirectUri: this.originUrl,
              forbiddenRoute: '/forbidden',
              unauthorizedRoute: '/unauthorized',
              silentRenew: true,
              silentRenewUrl: this.originUrl + '/silent-renew.html',
              historyCleanupOff: true,
              autoUserinfo: true,
              maxIdTokenIatOffsetAllowedInSeconds:10
          };
    
          const authWellKnownEndpoints: AuthWellKnownEndpoints = {
              issuer: this.authUrl,
              jwksUri: this.authUrl + '/.well-known/openid-configuration/jwks',
              authorizationEndpoint: this.authUrl + '/connect/authorize',
              tokenEndpoint: this.authUrl + '/connect/token',
              userinfoEndpoint: this.authUrl + '/connect/userinfo',
              endSessionEndpoint: this.authUrl + '/connect/endsession',
              checkSessionIframe: this.authUrl + '/connect/checksession',
              revocationEndpoint: this.authUrl + '/connect/revocation',
              introspectionEndpoint: this.authUrl + '/connect/introspect',
          };
    
          console.log("config");
          this.oidcConfigService.withConfig(openIdConfiguration, authWellKnownEndpoints);
    
      }
    
      login() {
          this.oidcSecurityService.authorize();
      }
    
      logout() {
          this.oidcSecurityService.logoff();
      }
}