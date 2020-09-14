import { Injectable } from '@angular/core';
import { Course } from './../../shared/models/Course'
import { HttpHeaders, HttpClient } from '@angular/common/http';
const AUTH_API = "http://localhost:5000/";

const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
@Injectable({
  providedIn: 'root'
})
export class CourseService {

  constructor(private http: HttpClient) { }


  getCourses(){
    //example change
      return this.http.get(AUTH_API + "T/Courses", httpOptions)
  
  }


}
