import { Component, OnInit } from '@angular/core';
import { CourseService } from './../../../../core/services/course.service'
import { Course } from '@data/schema/course';
import { Assignment } from '@data/schema/assingment';
import { Router } from '@angular/router';

@Component({
  selector: 'app-course-detail',
  templateUrl: './course-detail.component.html',
  styleUrls: ['./course-detail.component.css']
})
export class CourseDetailComponent implements OnInit {

  assignments: Assignment[];
  
    courseId: string;
    due: Date;
    isInstructor: boolean;
    description: string;
    title: string;
    languageId: string;


  constructor(private courseService: CourseService,
    private router:Router) { }

  ngOnInit(): void {
    this.courseService.getAssignment()
      .subscribe(data => { this.assignments = data.assignments })
  }
  courseDetail(id){
    this.router.navigate(['teacher/course-detail',id])
  }

  createNewAssignment(){
    this.courseService.CreateAssignmet({
      due:this.due,
      description:this.description,
      languageId:this.languageId
    }).subscribe(
      data => {
        this.assignments.push(new Assignment(data.id,this.due,"true",null,this.description,this.languageId));
        this.clearModal();
      },
      err =>{
        console.log(err);
      }
    )
  }

  clearModal(){
    this.languageId = null;
    this.description = null;
  }

}


