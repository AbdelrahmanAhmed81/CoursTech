import { HttpParams } from '@angular/common/http';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

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

  courseForm: FormGroup;
  selectedCourse: Course | undefined;
  titleErrors: errors = {
    required: 'title field is required',
    minlength: 'title length should be more than 2 characters',
    maxlength: 'title length should be less than 50 characters'
  }
  descriptionErrors: errors = {
    required: 'description field is required',
    minlength: 'description length should be more than 20 characters',
    maxlength: 'description length should be less than 800 characters'
  }
  dateErrors: errors = {
    required: 'date field is required'
  }
  hoursErrors: errors = {
    required: 'hours field is required',
    min: 'minimum hours is 0',
  }
  minutesErrors: errors = {
    required: 'minutes field is required',
    min: 'minimum minutes is 0',
    max: 'maximum minutes is 59'
  }
  secondsErrors: errors = {
    required: 'seconds field is required',
    min: 'minimum seconds is 0',
    max: 'maximum seconds is 59'
  }

  constructor(private courseService: CourseService,
    private alertService: AlertService) {
    this.courseForm = new FormGroup({
      'title': new FormControl(null, [Validators.required, Validators.minLength(2), Validators.maxLength(50)]),
      'description': new FormControl(null, [Validators.required, Validators.minLength(20), Validators.maxLength(800)]),
      'date': new FormControl(null, [Validators.required]),
      'duration': new FormGroup({
        'hours': new FormControl(null, [Validators.required, Validators.min(0)]),
        'minutes': new FormControl(null, [Validators.required, Validators.min(0), Validators.max(59)]),
        'seconds': new FormControl(null, [Validators.required, Validators.min(0), Validators.max(59)]),
      })
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
    this.courseForm.reset();
    this.selectedCourse = course;
    let duration: number[] = this.selectedCourse.duration.split(':').map(v => { return +v });
    this.courseForm.setValue({
      'title': this.selectedCourse.title,
      'description': this.selectedCourse.description,
      'date': this.selectedCourse.date,
      'duration': {
        'hours': duration[0],
        'minutes': duration[1],
        'seconds': duration[2],
      }
    })
  }

  onCancel() {
    this.courseForm.reset();
    this.selectedCourse = undefined;
  }

  onSubmit() {
    if (!this.courseForm.dirty || !this.courseForm.valid) return;

    let formValue = this.courseForm.value;
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
type errors = { [code: string]: string }