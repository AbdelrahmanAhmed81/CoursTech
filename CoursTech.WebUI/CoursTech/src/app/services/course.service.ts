import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Course } from '../models/Course';
@Injectable({
  providedIn: 'root'
})
export class CourseService {
  private url: string = 'https://localhost:7017/api/Course';
  constructor(private http: HttpClient) { }
  getAll(params: HttpParams): Observable<Course[]> {
    return this.http.get<Course[]>(this.url, {
      params: params
    })
  }
}
