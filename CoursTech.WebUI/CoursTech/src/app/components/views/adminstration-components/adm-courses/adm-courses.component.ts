import { HttpParams } from '@angular/common/http';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

import { Course } from 'src/app/models/Course';
import { AlertLevel, AlertService } from 'src/app/services/alert.service';
import { CourseService } from 'src/app/services/course.service';

@Component({
  selector: 'app-adm-courses',
  templateUrl: './adm-courses.component.html',
  styleUrls: ['./adm-courses.component.css']
})
export class AdmCoursesComponent implements OnInit {
  // @ViewChild('alert') alert: ElementRef | undefined;
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

  constructor(private courseService: CourseService,
    private alertService: AlertService) {
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
      // 'date': new Date(this.selectedCourse.date).toISOString().split('T')[0],
      'date': this.selectedCourse.date,
      'duration': {
        'hours': duration[0],
        'minutes': duration[1],
        'seconds': duration[2],
      }
    })
  }

  onCancel() {
    this.courseEditFormGroup.reset();
    this.selectedCourse = undefined;
  }

  onSubmit() {
    if (!this.courseEditFormGroup.dirty || !this.courseEditFormGroup.valid) return;

    let formValue = this.courseEditFormGroup.value;
    if (this.selectedCourse) {
      let course: Course = {
        courseId: this.selectedCourse.courseId,
        title: formValue.title,
        date: formValue.date,
        description: formValue.description,
        duration: `${formValue.duration.hours}:${formValue.duration.minutes}:${formValue.duration.seconds}`,
        imageName: this.selectedCourse.imageName,
        industryId: this.selectedCourse.industryId,
        instructorId: this.selectedCourse.instructorId
      }
      this.courseService.update(course).subscribe(data => {
        this.alertService.showAlert.next({ message: 'Changes Saved Succesfully', level: AlertLevel.success });
        this.loadCourses();
        this.onCancel();
      })
    }
  }
}
