import { Component, OnInit } from '@angular/core';
import { studentCourse } from './../../../../shared/models/studentCourse';
import { StudentService } from './../../../../core/services/student-services/student.service'


@Component({
  selector: 'app-student-home',
  templateUrl: './student-home.component.html',
  styleUrls: ['./student-home.component.css']
})
export class StudentHomeComponent implements OnInit {

  StudentCourses : studentCourse [] ;

  constructor(private studentService : StudentService) {}

  ngOnInit(): void
  {
    this.StudentCourses = this.studentService.getstudentCourse();
  }

}
