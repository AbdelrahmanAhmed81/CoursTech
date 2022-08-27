import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { CourseDataModel } from '../data-models/CourseDataModel';
import { Course } from '../models/Course';
@Injectable({
  providedIn: 'root'
})
export class CourseService {
  private url: string = 'https://localhost:7017/';
  private get_path: string = this.url + 'api/Course'
  private images_path: string = this.url + 'images/courses/';

  constructor(private http: HttpClient) { }

  getAll(params?: HttpParams): Observable<CourseDataModel> {
    return this.http.get<CourseDataModel>(this.get_path, {
      params: params
    })
      .pipe(map(data => {
        data.courses.map((value) => {
          value.date = new Date(value.date).toDateString();
          if (value.imageName)
            value.imageName = this.images_path + value.imageName;
          return value;
        })
        return data;
      }));
  }

  getById(id: string, params?: HttpParams): Observable<Course> {
    return this.http.get<Course>(this.get_path + `/${id}`, {
      params: params
    })
      .pipe(map(data => {
        data.date = new Date(data.date).toDateString();
        if (data.imageName)
          data.imageName = this.images_path + data.imageName;
        return data;
      }));
  }
}
