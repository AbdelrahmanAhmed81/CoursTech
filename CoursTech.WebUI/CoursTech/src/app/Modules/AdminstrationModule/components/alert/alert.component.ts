import { Component, ElementRef, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { Subscription } from 'rxjs';
import { AlertLevel, AlertService } from 'src/app/Modules/AdminstrationModule/services/alert.service';

@Component({
  selector: 'app-alert',
  templateUrl: './alert.component.html',
  styleUrls: ['./alert.component.css']
})
export class AlertComponent implements OnInit, OnDestroy {

  @ViewChild('alert') alert: ElementRef | undefined;
  alertBgStyle: string = '';
  alertIcon: string = '';
  showAlertSubscription: Subscription | undefined;

  constructor(private alertService: AlertService) { }

  ngOnDestroy(): void {
    this.showAlertSubscription?.unsubscribe();
  }

  ngOnInit(): void {
    this.showAlertSubscription = this.alertService.showAlert.subscribe(({ message, level }) => {
      this.showAlert(message, this.setAlertStyle(level));
    })
  }

  showAlert(message: string, alertStyle: { bg: string, icon: string }) {
    this.alertBgStyle = alertStyle.bg;
    this.alertIcon = alertStyle.icon;

    let element = (<HTMLElement>this.alert?.nativeElement);
    (<HTMLParagraphElement>element.children.namedItem('message')).innerText = message;
    element.classList.replace('alert-hidden', 'alert-visible');

    setTimeout(() => {
      this.closeAlert()
    }, 3000)
  }

  closeAlert() {
    (<HTMLElement>this.alert?.nativeElement).classList.replace('alert-visible', 'alert-hidden');
  }

  setAlertStyle(level: AlertLevel): { bg: string, icon: string } {
    switch (level) {
      case AlertLevel.success: {
        return { bg: 'alert-success', icon: 'fa-check' };
      }
      case AlertLevel.info: {
        return { bg: 'alert-primary', icon: 'fa-circle-info' };
      }
      case AlertLevel.warning: {
        return { bg: 'alert-warning', icon: 'fa-circle-exclamation' };
      }
      case AlertLevel.error: {
        return { bg: 'alert-danger', icon: 'fa-triangle-exclamation' };
      }
      default: {
        return { bg: '', icon: '' }
      }
    }
  }

}
