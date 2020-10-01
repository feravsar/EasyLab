import { Component, OnInit } from '@angular/core';
import { Course } from '@data/schema/course';
import { TeacherService } from '@app/services/teacher.service';
import { Assignment } from '@data/schema/assingment';
import { Router, ActivatedRoute } from '@angular/router';
import { User } from '@data/schema/user';

@Component({
  selector: 'app-course-detail',
  templateUrl: './course-detail.component.html',
  styleUrls: ['./course-detail.component.css']
})
export class CourseDetailComponent implements OnInit {

  courseInfo: Course;
  courseId: string;

  newAssignment: Assignment = new Assignment();

  assignments: Assignment[];
  users : User[];

  due: Date;
  isInstructor: boolean;
  description: string;
  title: string;
  languageId: string;


  constructor(private teacherService: TeacherService,
    private router: Router,
    private activatedRoute: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.courseInfo = history.state;
    this.activatedRoute.params.subscribe(params => {
      this.courseId = params['id'];
    });
    this.getAssignments();
    this.getCourseUsers();
  }


  createNewAssignment() {
    this.newAssignment.languageId = 1;
    this.newAssignment.courseId = this.courseId;
    this.newAssignment.due = new Date(this.newAssignment.due);

    this.teacherService.createAssignmet(this.newAssignment).subscribe(
      data => {
        this.clearModal();
        this.getAssignments();
      },
      err => {
        console.log(err);
      }
    )
  }
  getAssignments() {
    this.teacherService.getAssignments(this.courseId)
      .subscribe(data => { this.assignments = data.assignments })
  }

  getCourseUsers(){
    this.teacherService.getMembers(this.courseId)
      .subscribe(data => {this.users = data.courseUsers})
  }

  clearModal() {
    this.newAssignment = new Assignment();
  }


  onUserSelect($event){
    ($event).forEach(t=>{
      this.teacherService.addMember({
        courseId : this.courseId,
        userId : t.id,
        isInstructor : false
      }).subscribe( data =>
        this.users.push(t)
      ),
      err => console.log(err)
    })
  }
}


