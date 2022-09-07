import { HttpParams } from '@angular/common/http';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { map } from 'rxjs';

import { Course } from 'src/app/models/Course';
import { AlertLevel, AlertService } from 'src/app/services/alert.service';
import { CourseService } from 'src/app/services/course.service';

@Component({
  selector: 'app-adm-courses',
  templateUrl: './adm-courses.component.html',
  styleUrls: ['./adm-courses.component.css']
})
export class AdmCoursesComponent implements OnInit {
  pageNumber: number = 1;
  pageCapacity: number = 10;
  queryParams: HttpParams = new HttpParams()
    .append('pageNumber', this.pageNumber)
    .append('pageCapacity', this.pageCapacity);

  isLoading: boolean = false;
  courses: Course[] = [];
  totalCourses: number = 0;

  searchText: string = '';

  selectedCourse: Course | undefined;


  constructor(private courseService: CourseService,
    private alertService: AlertService) {
  }

  ngOnInit(): void {
    this.loadCourses();
  }

  loadCourses() {
    this.isLoading = true;
    this.courseService.getAll(this.queryParams)
      .pipe(map(data => {
        data.courses.map((value) => {
          if (value.imageName)
            value.imageName = CourseService.images_path + value.imageName;
          return value;
        })
        return data;
      }))
      .subscribe(data => {
        this.courses = data.courses;
        this.totalCourses = data.coursesCount
        this.isLoading = false;
      })
  }

  searchTextInput(e: Event) {
    let value: string = (<HTMLInputElement>e.target).value;
    this.queryParams = this.queryParams.set('searchText', value)
    this.loadCourses()
  }

  onChangePagination(data: { pageNumber: number, pageCapacity: number }) {
    this.queryParams = this.queryParams.set('pageNumber', data.pageNumber);
    this.queryParams = this.queryParams.set('pageCapacity', data.pageCapacity);
    this.loadCourses();
  }

  onClickEdit(course: Course) {
    this.selectedCourse = course;
  }

  onCancel() {
    this.selectedCourse = undefined;
  }

  onSubmit(course: Course) {
    this.courseService.update(course).subscribe(data => {
      this.alertService.showAlert.next({ message: 'Changes Saved Succesfully', level: AlertLevel.success });
      this.loadCourses();
    })
  }
}
