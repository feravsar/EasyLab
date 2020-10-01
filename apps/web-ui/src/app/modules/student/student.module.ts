import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import {StudentHomeComponent} from './pages/student-home/student-home.component'
import {StudentRoutingModule} from './student-routing.module';
import { ProjectComponent } from './pages/project/project.component';
import { AssignmentsComponent } from './pages/assignments/assignments.component'

@NgModule({
  declarations: [StudentHomeComponent, ProjectComponent, AssignmentsComponent],
  imports: [
    CommonModule, 
    StudentRoutingModule
  ]
})
export class StudentModule { }
