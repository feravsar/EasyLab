import { Injectable } from '@angular/core';
import {studentCourse } from './../../../shared/models/studentCourse';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  constructor() { }

  getstudentCourse()
    {
      return [new studentCourse(1030522,"Furkan ERAVŞAR",101,"Computer Programming 1"),new studentCourse(1030507,"Temmuz Yavuzer",103,"Istatics")];
    }
}
