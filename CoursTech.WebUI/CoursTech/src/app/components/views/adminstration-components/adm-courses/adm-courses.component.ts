import { HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

import { Course } from 'src/app/models/Course';
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

  courseEditFormGroup: FormGroup;
  selectedCourse: Course | undefined;

  constructor(private courseService: CourseService) {
    this.courseEditFormGroup = new FormGroup({
      'title': new FormControl(null),
      'description': new FormControl(null),
      'date': new FormControl(null),
      'duration': new FormGroup({
        'hours': new FormControl(null),
        'minutes': new FormControl(null),
        'seconds': new FormControl(null),
      }),
    });
  }

  ngOnInit(): void {
    this.loadCourses();
  }

  loadCourses() {
    this.isLoading = true;
    this.courseService.getAll(this.queryParams).subscribe(data => {
      this.courses = data.courses;
      console.log(this.courses)
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
    let duration: number[] = this.selectedCourse.duration.split(':').map(v => { return +v });
    this.courseEditFormGroup.setValue({
      'title': this.selectedCourse.title,
      'description': this.selectedCourse.description,
      'date': new Date(this.selectedCourse.date).toISOString().split('T')[0],
      'duration': {
        'hours': duration[0],
        'minutes': duration[1],
        'seconds': duration[2],
      }
    })
  }
}
