import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ContentLayoutComponent } from './layout/content-layout/content-layout.component';
import { AuthLayoutComponent } from './layout/auth-layout/auth-layout.component';
import { AuthGuard } from '@app/helpers/auth-guard.guard';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'auth/login',
    pathMatch: 'full'
  },
  {
    path: 'student',
    component: ContentLayoutComponent,
    loadChildren: () => import('./modules/student/student.module').then(m => m.StudentModule),
    canActivate:[AuthGuard], 
    data:{role:'STUDENT'},
  },
  {
    path: 'teacher',
    component: ContentLayoutComponent,
    canActivate:[AuthGuard], 
    data:{role:'TEACHER'},
    loadChildren: () => import('./modules/teacher/teacher.module').then(m => m.TeacherModule)
  },
  {
    path: 'auth',
    component: AuthLayoutComponent,
    loadChildren: () => import('./modules/auth/auth.module').then(m => m.AuthModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
