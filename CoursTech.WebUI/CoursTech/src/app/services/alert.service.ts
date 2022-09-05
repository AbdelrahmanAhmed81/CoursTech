import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AlertService {
  showAlert: Subject<{ message: string, level: AlertLevel }>
    = new Subject<{ message: string, level: AlertLevel }>();

  constructor() { }

}
export enum AlertLevel {
  success,
  info,
  warning,
  error
}