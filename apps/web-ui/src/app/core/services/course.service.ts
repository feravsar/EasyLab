import { Injectable } from '@angular/core';
import { Course } from './../../shared/models/Course'

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  constructor() { }


  getCourses(){
    return [new Course(101,"Computer Programming 1"), new Course(103, "Istatistics")];
  }


}
