import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthModel } from 'src/app/data-models/AuthModel';
import { AlertLevel, AlertService } from 'src/app/services/alert.service';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  emailErrors: errors = {
    'required': 'email field is required',
    'email': 'email field should be in email address manner'
  }
  passwordErrors: errors = {
    'required': 'password field is required',
  }
  constructor(private authService: AuthService, private alertService: AlertService) {
    this.loginForm = new FormGroup({
      'email': new FormControl(null, [Validators.required, Validators.email]),
      'password': new FormControl(null, [Validators.required]),
    })
  }
  ngOnInit(): void {
  }
  onSubmit() {
    let model: AuthModel = {
      email: this.loginForm.value.email,
      password: this.loginForm.value.password
    }
    this.authService.Login(model).subscribe({
      next: (response) => {
        this.alertService.showAlert.next({ message: response.token + ' | ' + response.expiration, level: AlertLevel.success });
        this.loginForm.reset()
      },
      error: (response) => {
        this.alertService.showAlert.next({ message: response.message, level: AlertLevel.error })
      }
    })
  }
}
type errors = { [code: string]: string }