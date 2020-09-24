import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '@env' 
import { SearchUser } from '@data/response/search-user';



@Injectable({
  providedIn: 'root'
})


export class UserService {

  constructor(private http: HttpClient) { }


  searchUser(searchTerm: string):Observable<SearchUser> {

    return this.http.get<SearchUser>(environment.API_URL + "Accounts/SearchUser?searchTerm=" + searchTerm)

  }
}
