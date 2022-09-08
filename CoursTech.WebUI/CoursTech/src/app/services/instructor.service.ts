import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Instructor } from '../models/Instructor';

@Injectable({
  providedIn: 'root'
})
export class InstructorService {

  private static readonly url: string = 'https://localhost:7017/';
  static readonly path: string = InstructorService.url + 'api/Instructor';
  constructor(private http: HttpClient) { }
  getAll(): Observable<Instructor[]> {
    return this.http.get<Instructor[]>(InstructorService.path);
  }
}
