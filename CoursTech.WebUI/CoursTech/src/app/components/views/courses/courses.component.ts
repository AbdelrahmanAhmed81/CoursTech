import { HttpErrorResponse, HttpParams } from '@angular/common/http';
import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { catchError, map, Observable, ObservableInput } from 'rxjs';
import { Course } from 'src/app/models/Course';
import { CourseService } from 'src/app/services/course.service';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.css']
})
export class CoursesComponent implements OnInit, OnChanges {
  @Output() onLoadCourses: EventEmitter<number> = new EventEmitter<number>();
  @Input() queryParams: HttpParams = new HttpParams();
  isLoading: boolean = false;
  courses: Course[] = [];

  constructor(private courseService: CourseService) { }
  ngOnChanges(): void {
    if (this.courses.length != 0)
      this.loadCourses();
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
        this.onLoadCourses.emit(data.coursesCount);
        this.isLoading = false;
      })
  }
}
