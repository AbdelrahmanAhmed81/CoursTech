import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { CourseDataModel } from '../data-models/CourseDataModel';
import { Course } from '../models/Course';
@Injectable({
  providedIn: 'root'
})
export class CourseService {
  private static readonly url: string = 'https://localhost:7017/';
  static readonly path: string = CourseService.url + 'api/Course'
  static readonly images_path: string = CourseService.url + 'images/courses/';
  static readonly instructor_photos_path: string = CourseService.url + 'images/instructors/';

  constructor(private http: HttpClient) { }

  getAll(params?: HttpParams): Observable<CourseDataModel> {
    return this.http.get<CourseDataModel>(CourseService.path, {
      params: params
    })
      .pipe(map(data => {
        data.courses.map((value) => {
          value.date = value.date.split('T')[0];
          return value;
        })
        return data;
      }));
  }

  getById(id: string, params?: HttpParams): Observable<Course> {
    return this.http.get<Course>(CourseService.path + `/${id}`, {
      params: params
    })
      .pipe(map(data => {
        data.date = data.date.split('T')[0];
        return data;
      }));
  }

  update(course: Course): Observable<any> {
    return this.http.put(CourseService.path, course);
  }
}
