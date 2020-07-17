import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ContentLayoutComponent } from './layout/content-layout/content-layout.component';

const routes: Routes = [
  {
    path:'',
    redirectTo:'teacher',
    pathMatch:'full'
  },
  {
    path: 'student',
    component:ContentLayoutComponent,
    loadChildren: () => import('./modules/student/student.module').then(m => m.StudentModule)
  },
  {
    path: 'teacher',
    component:ContentLayoutComponent,
    loadChildren: () => import('./modules/teacher/teacher.module').then(m => m.TeacherModule)
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
