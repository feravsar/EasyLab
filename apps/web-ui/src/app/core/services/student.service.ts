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

  startProject(data:object): Observable<any>{
    return this.http.post<any>(environment.API_URL + "Student/StartProject",data);
  }

  buildProject(data:object): Observable<any>{
    return this.http.post<any>(environment.API_URL + "Student/BuildProject",data);
  }

  getFileContent(projectId: string, fileName:string): Observable<any>{
    return this.http.get<any>(environment.API_URL + "Student/GetFileContent?projectId="+projectId+"&fileName="+fileName);
  }

  runProject(data:object): Observable<any>{
    return this.http.post<any>(environment.API_URL + "Student/RunProject",data);
  }

  updateDocument(data:object): Observable<any>{
    return this.http.post<any>(environment.API_URL + "Student/UpdateDocument",data);
  }

}
