import { Component, OnInit } from '@angular/core';
import { CourseService } from './../../../../core/services/course.service'
import { Course } from './../../../../shared/models/Course'
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.css'],
  
})
export class CoursesComponent implements OnInit {

  courses: Course[] = [];

  coursename: string = null;
  description: string = null;

  constructor(private courseService: CourseService,private authService: AuthService) {

   }

  ngOnInit(): void {
    let a  = this.courseService.getCourses().subscribe(data=>{this.courses = data.courses;
    console.log(data)})
  
  }
  
  onSubmit() {
    this.courseService.addCourses()
      coursename: this.coursename,
      description: this.description
  }

}
