import { environment } from "../../environments/environment"
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Instructor } from '../models/Instructor';

@Injectable({
  providedIn: 'root'
})
export class InstructorService {

  private static readonly url: string = environment.API_URL;
  static readonly path: string = InstructorService.url + 'api/Instructor';
  constructor(private http: HttpClient) { }
  getAll(): Observable<Instructor[]> {
    return this.http.get<Instructor[]>(InstructorService.path);
  }
}
