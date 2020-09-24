import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { User } from '@data/schema/user';
import { Subject, Observable } from 'rxjs';
import { debounceTime, distinctUntilChanged, map, switchMap } from 'rxjs/operators';
import { UserService } from './../../../../core/services/user.service'


@Component({
  selector: 'app-search-user',
  templateUrl: './search-user.component.html',
  styleUrls: ['./search-user.component.css']
})
export class SearchUserComponent implements OnInit {

  private searchTermSubject = new Subject<string>();
  users: User[];


  @Input() courseId: string;
  @Output() onSelect = new EventEmitter();



  constructor(private userService: UserService) { }

  ngOnInit(): void {
  }


  users$ = this.searchTermSubject.pipe(
    debounceTime(250),
    distinctUntilChanged(),
    switchMap(searchTerm =>
      this.userService.searchUser(searchTerm)
    )).subscribe(
      data => this.users = data.users
    )

  search(searchTerm: string) {
    if (searchTerm.length > 2)
      this.searchTermSubject.next(searchTerm);
  }

  select() {
    let selectedUsers = this.users.filter(t => t.selected);
    this.onSelect.emit(selectedUsers);
  }

}
