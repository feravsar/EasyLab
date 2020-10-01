import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AssignmentsComponent } from './pages/assignments/assignments.component';
import { ProjectComponent } from './pages/project/project.component';
import { StudentHomeComponent } from './pages/student-home/student-home.component'

const routes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full'},
    { path: 'home', component: StudentHomeComponent },
    { path: 'assignments/:id', component: AssignmentsComponent },
    { path: 'project', component: ProjectComponent }

];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class StudentRoutingModule { }