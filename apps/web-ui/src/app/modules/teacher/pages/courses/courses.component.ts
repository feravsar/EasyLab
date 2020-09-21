import { Component, OnInit } from '@angular/core';
import { CourseService } from './../../../../core/services/course.service'
import { Course } from '@data/schema/course';
import { Router } from '@angular/router';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.css'],
  
})
export class CoursesComponent implements OnInit {

  courses: Course[];

  name:string;
  description:string;

  constructor(private courseService: CourseService,
    private router:Router) { }

  ngOnInit(): void {
    this.courseService.getCourses()
      .subscribe(data => { this.courses = data.courses })
  }

  courseDetail(course){
    this.router.navigate(['teacher/course-detail',course.id],{state:course})
  }

  createNewCourse(){
    this.courseService.addCourse({
      name:this.name,
      description:this.description
    }).subscribe(
      data => {
        this.courses.push(new Course(data.id,this.name,this.description,null,0));
        this.clearModal();
      },
      err =>{
        console.log(err);
      }
    )
  }

  clearModal(){
    this.name = null;
    this.description = null;
  }

}
