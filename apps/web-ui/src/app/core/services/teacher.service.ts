import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AssignmentList } from '@data/response/assignment-list';
import { CourseList } from '@data/response/course-list';
import { EntityAdded } from '@data/response/entity-added';
import { SearchUser } from '@data/response/search-user';
import { UserList } from '@data/response/user-list';
import { Assignment } from '@data/schema/assingment';
import { environment } from '@env';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TeacherService {

  constructor(private http: HttpClient) { }

  searchUser(searchTerm: string): Observable<SearchUser> {
    return this.http.get<SearchUser>(environment.API_URL + "Teacher/SearchUser?searchTerm=" + searchTerm)
  }

  
  getCourses(): Observable<CourseList> {
    return this.http.get<CourseList>(environment.API_URL + "Teacher/Courses")
  }

  addCourse(object: any): Observable<EntityAdded> {
    return this.http.post<EntityAdded>(environment.API_URL + "Teacher/AddCourse", object)
  }

  getAssignments(courseId: string): Observable<AssignmentList> {
    return this.http.get<AssignmentList>(environment.API_URL + "Teacher/Assignments?courseId=" + courseId)
  }

  createAssignmet(object: Assignment): Observable<EntityAdded> {
    return this.http.post<EntityAdded>(environment.API_URL + "Teacher/CreateAssignment", object)
  }

  getMembers(courseId: string): Observable<UserList> {
    return this.http.get<UserList>(environment.API_URL + "Teacher/GetMembers?courseId=" + courseId)
  }

  addMember(object: any) {
    return this.http.post(environment.API_URL + "Teacher/AddMember" , object)
  }

}
