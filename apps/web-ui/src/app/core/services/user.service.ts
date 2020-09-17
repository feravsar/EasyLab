import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '@env' 



@Injectable({
  providedIn: 'root'
})


export class UserService {

  constructor(private http: HttpClient) { }


  searchUser(searchTerm: string):Observable<any> {

    return this.http.get(environment.API_URL + "Accounts/SearchUser?searchTerm=" + searchTerm)

  }
}
