import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

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
  constructor() {
    this.loginForm = new FormGroup({
      'email': new FormControl(null, [Validators.required, Validators.email]),
      'password': new FormControl(null, [Validators.required]),
    })
  }
  ngOnInit(): void {
  }
  onSubmit() {

  }
}
type errors = { [code: string]: string }