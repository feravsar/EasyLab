import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { StudentService } from '@app/services/student.service';
import { Assignment } from '@data/schema/assingment';
import { Course } from '@data/schema/course';

@Component({
  selector: 'app-assignments',
  templateUrl: './assignments.component.html',
  styleUrls: ['./assignments.component.css']
})
export class AssignmentsComponent implements OnInit {
  courseInfo: Course;
  courseId: string;

  assignments: Assignment[];

  constructor(private studentService: StudentService,
    private router: Router,
    private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.courseInfo = history.state;
    this.activatedRoute.params.subscribe(params => {
      this.courseId = params['id'];
    });

    this.studentService.getAssignments(this.courseId)
      .subscribe(t => {
        this.assignments = t.assignments
        },
        err => {
          console.log(err)
        })
  }

}
