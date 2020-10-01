import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { TokenStorageService } from '@app/services/token-storage.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private tokenStorageService: TokenStorageService, private router: Router) {

  }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
  
    return this.checkUserLogin(next);
  }



  checkUserLogin(route: ActivatedRouteSnapshot): boolean {
    if (this.tokenStorageService.isLoggedIn()) {
      const userRoles = this.tokenStorageService.getRoles();
      if (route.data.role && !userRoles.includes(route.data.role)) {
        this.router.navigate(['/auth/login']);
        return false;
      }
      return true;
    }

    this.router.navigate(['/auth/login']);
    return false;
  }
}
