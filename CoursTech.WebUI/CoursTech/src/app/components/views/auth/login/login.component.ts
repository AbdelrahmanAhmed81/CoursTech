import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
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
  errorMessage: string = '';
  isLoading: boolean = false;

  emailErrors: errors = {
    'required': 'email field is required',
    'email': 'email field should be in email address manner'
  }
  passwordErrors: errors = {
    'required': 'password field is required',
  }
  constructor(private authService: AuthService, private router: Router) {
    this.loginForm = new FormGroup({
      'email': new FormControl(null, [Validators.required, Validators.email]),
      'password': new FormControl(null, [Validators.required]),
    })
  }
  ngOnInit(): void {
  }
  onSubmit() {
    this.isLoading = true;
    let model: AuthModel = {
      email: this.loginForm.value.email,
      password: this.loginForm.value.password
    }
    this.authService.Login(model).subscribe({
      next: (response) => {
        //...
        this.isLoading = false;
        this.router.navigate(['Home'])
      },
      error: (message) => {
        this.isLoading = false;
        this.errorMessage = message;
      }
    })
  }
}
type errors = { [code: string]: string }