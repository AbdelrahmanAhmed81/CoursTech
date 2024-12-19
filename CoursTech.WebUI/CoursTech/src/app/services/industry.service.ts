import { environment } from "../../environments/environment"
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Industry } from '../models/Industry';
@Injectable({
  providedIn: 'root'
})
export class IndustryService {
  private static readonly url: string = environment.API_URL;
  static readonly path: string = IndustryService.url + 'api/Industry';
  constructor(private http: HttpClient) { }
  getAll(): Observable<Industry[]> {
    return this.http.get<Industry[]>(IndustryService.path);
  }

}
