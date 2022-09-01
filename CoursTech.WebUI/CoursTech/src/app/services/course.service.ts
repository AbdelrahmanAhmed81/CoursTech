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
  private instructor_photos_path: string = this.url + 'images/instructors/';

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
        let dateTime = new Date('1 ' + data.duration);
        data.duration = `${dateTime.getHours()}h ${dateTime.getMinutes()}m`
        data.date = new Date(data.date).toLocaleDateString();
        if (data.imageName)
          data.imageName = this.images_path + data.imageName;
        if (data.instructor.photoName)
          data.instructor.photoName = this.instructor_photos_path + data.instructor.photoName;
        if (data.industry.courses) {
          data.industry.courses.map(c => {
            c.imageName = this.images_path + c.imageName;
          })
        }
        if (data.instructor.courses) {
          data.instructor.courses.map(c => {
            c.imageName = this.images_path + c.imageName;
          })
        }

        return data;
      }));
  }
}
