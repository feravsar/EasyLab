import { Component, OnInit } from '@angular/core';
import { Subject, Observable } from 'rxjs';
import { debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';
import { UserService } from './../../../../core/services/user.service'


@Component({
  selector: 'app-search-user',
  templateUrl: './search-user.component.html',
  styleUrls: ['./search-user.component.css']
})
export class SearchUserComponent implements OnInit {

  private searchTermSubject = new Subject<string>();

  constructor(private userService: UserService) { }

  ngOnInit(): void {
  }


   users$ = this.searchTermSubject.pipe(
    debounceTime(250),
    distinctUntilChanged(),
    switchMap(searchTerm =>
      this.userService.searchUser(searchTerm)
  ))

  search(searchTerm: string) {
    if (searchTerm.length > 2)
      this.searchTermSubject.next(searchTerm);
  }

}
