import { HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { catchError, map, throwError } from 'rxjs';

import { Course } from 'src/app/models/Course';
import { Industry } from 'src/app/models/Industry';
import { Instructor } from 'src/app/models/Instructor';
import { AlertLevel, AlertService } from 'src/app/Modules/AdminstrationModule/services/alert.service';
import { CourseService } from 'src/app/Modules/CoursesModule/services/course.service';
import { IndustryService } from 'src/app/services/industry.service';
import { InstructorService } from 'src/app/services/instructor.service';

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
  industries: Industry[] = [];
  instructors: Instructor[] = [];

  totalCourses: number = 0;

  searchText: string = '';

  selectedCourse: Course | undefined;
  adding: boolean = false;

  toDeleteId: string = '';
  toDeleteTitle: string = '';

  constructor(private courseService: CourseService,
    private industryService: IndustryService,
    private instructorService: InstructorService,
    private alertService: AlertService) {
  }

  ngOnInit(): void {
    this.loadCourses();
    this.loadIndustries();
    this.loadInstructors();
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

  loadIndustries() {
    this.industryService.getAll().subscribe(data => {
      this.industries = data;
    })
  }

  loadInstructors() {
    this.instructorService.getAll().subscribe(data => {
      this.instructors = data;
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
    this.adding = false
    this.selectedCourse = course;
  }

  onClickAdd() {
    this.adding = true;
    this.selectedCourse = undefined;
  }

  onClickDelete(id: string, title: string) {
    this.Cancel();
    this.toDeleteTitle = title;
    this.toDeleteId = id;
  }

  Cancel() {
    this.adding = false;
    this.selectedCourse = undefined;
  }

  Delete(id: string) {
    this.courseService.delete(id).subscribe(data => {
      this.alertService.showAlert.next({ message: 'Course Deleted Succesfully', level: AlertLevel.error });
      this.loadCourses();
    });
  }

  Submit(courseData: FormData) {
    if (this.adding && !this.selectedCourse) {
      this.courseService.add(courseData).subscribe(data => {
        this.Cancel();
        this.alertService.showAlert.next({ message: 'Course Added Succesfully', level: AlertLevel.success });
        this.loadCourses();
      })
    }
    if (this.selectedCourse && !this.adding) {
      courseData.append('Id', this.selectedCourse.courseId);
      this.courseService.update(courseData).pipe(catchError((err, c) => {
        this.alertService.showAlert.next({ message: err.message, level: AlertLevel.error });
        return throwError(() => err);
      })).subscribe(data => {
        this.Cancel();
        this.alertService.showAlert.next({ message: 'Changes Saved Succesfully', level: AlertLevel.info });
        this.loadCourses();
      })
    }
  }

}