import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TeacherRoutingModule } from './teacher-routing.module';
import { CoursesComponent } from './pages/courses/courses.component';
import { CourseDetailComponent } from './pages/course-detail/course-detail.component';
import { SearchUserComponent } from './components/search-user/search-user.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [CoursesComponent, CourseDetailComponent, SearchUserComponent],
  imports: [
    CommonModule,
    TeacherRoutingModule,
    FormsModule
  ]
})
export class TeacherModule { }
