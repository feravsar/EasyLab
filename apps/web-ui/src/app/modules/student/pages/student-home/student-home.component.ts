import { Component, OnInit } from '@angular/core';
import { studentCourse } from './../../../../shared/models/studentCourse';
import { StudentService } from './../../../../core/services/student.service'
import { Course } from '@data/schema/course';
import { Router } from '@angular/router';


@Component({
  selector: 'app-student-home',
  templateUrl: './student-home.component.html',
  styleUrls: ['./student-home.component.css']
})
export class StudentHomeComponent implements OnInit {

  courses: Course[];

  constructor(private router: Router, private studentService: StudentService) { }

  ngOnInit(): void {
    this.studentService.getCourses()
      .subscribe(data => { this.courses = data.courses });
  }


  courseDetail(course) {
    this.router.navigate(['student/assignments', course.id], { state: course })
  }
}
