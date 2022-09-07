import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Course } from 'src/app/models/Course';

@Component({
  selector: 'app-course-form',
  templateUrl: './course-form.component.html',
  styleUrls: ['./course-form.component.css']
})
export class CourseFormComponent implements OnInit, OnChanges {
  @Input() selectedCourse?: Course;
  @Output() onSubmitForm: EventEmitter<Course> = new EventEmitter<Course>();
  @Output() onCancelForm: EventEmitter<void> = new EventEmitter<void>();

  courseForm: FormGroup;
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

  constructor() {
    this.courseForm = new FormGroup({
      'title': new FormControl(null, [Validators.required, Validators.minLength(2), Validators.maxLength(50)]),
      'description': new FormControl(null, [Validators.required, Validators.minLength(20), Validators.maxLength(800)]),
      'date': new FormControl(null, [Validators.required]),
      'duration': new FormGroup({
        'hours': new FormControl(null, [Validators.required, Validators.min(0)]),
        'minutes': new FormControl(null, [Validators.required, Validators.min(0), Validators.max(59)]),
        'seconds': new FormControl(null, [Validators.required, Validators.min(0), Validators.max(59)]),
      }),
      'image': new FormControl(null)
    });
  }
  ngOnChanges(changes: SimpleChanges): void {
    if (this.selectedCourse) {
      this.courseForm.reset();
      let duration: number[] = this.selectedCourse.duration.split(':').map(v => { return +v });
      this.courseForm.setValue({
        'title': this.selectedCourse.title,
        'description': this.selectedCourse.description,
        'date': this.selectedCourse.date,
        'duration': {
          'hours': duration[0],
          'minutes': duration[1],
          'seconds': duration[2],
        },
        'image': ''
      })
    }
  }

  ngOnInit(): void {
  }

  onCancel() {
    this.onCancelForm.emit();
  }

  onSubmit() {
    let formValue = this.courseForm.value;
    let course: Course = {
      courseId: this.selectedCourse ? this.selectedCourse.courseId : '',
      title: formValue.title,
      date: formValue.date,
      description: formValue.description,
      duration: `${formValue.duration.hours}:${formValue.duration.minutes}:${formValue.duration.seconds}`,
      imageName: this.selectedCourse ? this.selectedCourse.imageName : '',
      industryId: this.selectedCourse ? this.selectedCourse.industryId : 0,
      instructorId: this.selectedCourse ? this.selectedCourse.instructorId : ' '
    }
    this.onSubmitForm.emit(course);
  }
}
type errors = { [code: string]: string }