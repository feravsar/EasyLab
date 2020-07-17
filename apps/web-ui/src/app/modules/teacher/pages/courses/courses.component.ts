import { Component, OnInit } from '@angular/core';
import { CourseService } from './../../../../core/services/course.service'
import { Course } from './../../../../shared/models/Course'

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.css']
})
export class CoursesComponent implements OnInit {

  courses: Course[] = [];

  constructor(private courseService: CourseService) { }

  ngOnInit(): void {
    this.courses = this.courseService.getCourses()
  }

}
