import { Injectable, OnDestroy, Inject } from '@angular/core';
import { OidcSecurityService, OpenIdConfiguration, AuthWellKnownEndpoints, AuthorizationResult, OidcConfigService } from 'angular-auth-oidc-client'
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Subscription, Observable } from 'rxjs';

@Injectable()
export class AuthService implements OnDestroy {

  isAuthorized = false;
  private isAuthorizedSubscription: Subscription = new Subscription;

  constructor(
      private oidcSecurityService: OidcSecurityService,
      private oidcConfigService: OidcConfigService,
      private http: HttpClient,
      private router: Router,
      @Inject('BASE_URL') private originUrl: string,
      @Inject('AUTH_URL') private authUrl: string,
  ) {
  }


  ngOnDestroy(): void {
      if (this.isAuthorizedSubscription) {
          this.isAuthorizedSubscription.unsubscribe();
      }
  }

  public initAuth() {
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

      this.oidcConfigService.withConfig(openIdConfiguration, authWellKnownEndpoints);

  }

  login() {
      this.oidcSecurityService.authorize();
  }

  logout() {
      this.oidcSecurityService.logoff();
  }

}