import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { Course } from '../models/Course';
import { CourseDataModel } from '../data-models/CourseDataModel';
@Injectable({
  providedIn: 'root'
})
export class CourseService {
  private url: string = 'https://localhost:7017/api/Course';

  constructor(private http: HttpClient) { }

  getAll(params: HttpParams): Observable<CourseDataModel> {

    return this.http.get<CourseDataModel>(this.url, {
      params: params
    })
      .pipe(map(data => {
        data.courses.map((value) => {
          value.date = new Date(value.date).toDateString();
          return value;
        })
        return data;
      }));
  }
}
