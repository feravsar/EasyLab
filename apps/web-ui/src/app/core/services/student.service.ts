import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AssignmentList } from '@data/response/assignment-list';
import { CourseList } from '@data/response/course-list';
import { environment } from '@env';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  constructor(private http: HttpClient) { }


  getCourses(): Observable<CourseList> {
    return this.http.get<CourseList>(environment.API_URL + "Student/Courses")
  }

  getAssignments(courseId: string): Observable<AssignmentList> {
    return this.http.get<AssignmentList>(environment.API_URL + "Student/GetProjects?courseId=" + courseId)
  }

}
