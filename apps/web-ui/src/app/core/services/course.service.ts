import { Injectable } from '@angular/core';
import { CourseList } from '@data/response/course-list';
import { AssignmentList } from "@data/response/assignment-list";
import { EntityAdded } from '@data/response/entity-added';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '@env'

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
@Injectable({
  providedIn: 'root'
})
export class CourseService {

  constructor(private http: HttpClient) { }


  getCourses(): Observable<CourseList> {
    return this.http.get<CourseList>(environment.API_URL + "T/Courses")
  }

  addCourse(object: any): Observable<EntityAdded> {
    return this.http.post<EntityAdded>(environment.API_URL + "Course/AddCourse", object)
  }

  getAssignment(): Observable<AssignmentList> {
    return this.http.get<AssignmentList>(environment.API_URL + "Course/Assignments")
  }

  CreateAssignmet(object: any): Observable<EntityAdded> {
    return this.http.post<EntityAdded>(environment.API_URL + "Course/CreateAssignment", object)
  }

}
