import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthModel } from 'src/app/data-models/AuthModel';
import { AlertLevel, AlertService } from 'src/app/services/alert.service';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  emailErrors: errors = {
    'required': 'email field is required',
    'email': 'email field should be in email address manner'
  }
  passwordErrors: errors = {
    'required': 'password field is required',
  }
  confirmPasswordErrors: errors = {
    'required': 'confirm password field is required',
  }
  constructor(private authService: AuthService, private alertService: AlertService) {
    this.registerForm = new FormGroup({
      'email': new FormControl(null, [Validators.required, Validators.email]),
      'password': new FormControl(null, [Validators.required]),
      'confirmPassword': new FormControl(null, [Validators.required])
    })
  }

  ngOnInit(): void {
  }

  onSubmit() {
    let model: AuthModel = {
      email: this.registerForm.value.email,
      password: this.registerForm.value.password
    }
    this.authService.Register(model).subscribe({
      next: (response) => {
        this.alertService.showAlert.next({ message: response.message, level: AlertLevel.success })
      },
      error: (response) => {
        this.alertService.showAlert.next({ message: response.error.message, level: AlertLevel.error })
      }
    })
  }
}
type errors = { [code: string]: string }