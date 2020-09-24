import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import {StudentHomeComponent} from './pages/student-home/student-home.component'
import {StudentRoutingModule} from './student-routing.module';
import { ProjectComponent } from './pages/project/project.component'

@NgModule({
  declarations: [StudentHomeComponent, ProjectComponent],
  imports: [
    CommonModule, 
    StudentRoutingModule
  ]
})
export class StudentModule { }
