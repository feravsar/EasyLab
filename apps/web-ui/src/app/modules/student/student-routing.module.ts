import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProjectComponent } from './pages/project/project.component';
import { StudentHomeComponent } from './pages/student-home/student-home.component'

const routes: Routes = [
      { path: 'home',  component: StudentHomeComponent},
      { path: 'project',  component: ProjectComponent}
    
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class StudentRoutingModule { }