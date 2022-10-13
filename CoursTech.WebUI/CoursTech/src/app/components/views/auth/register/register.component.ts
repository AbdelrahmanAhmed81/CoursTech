import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { AuthModel } from 'src/app/data-models/AuthModel';
// import { User } from 'src/app/data-models/User';
import { PassowrdValidator } from 'src/app/models/PasswordValidator';
// import { AlertLevel, AlertService } from 'src/app/services/alert.service';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  tooltipVisible: boolean = false;
  errorMessage: string = '';
  isLoading: boolean = false;

  emailErrors: errors = {
    'required': 'email field is required',
    'email': 'email field should be in email address manner'
  }
  passwordsErrors: errors = {
    'not-match': 'confirm password field should match password field'
  }
  passwordErrors: errors = {}
  confirmPasswordErrors: errors = {
    'required': 'confirm password field is required',
  }
  constructor(private authService: AuthService, private router: Router) {
    this.registerForm = new FormGroup({
      'email': new FormControl(null, [Validators.required, Validators.email]),
      'passwords': new FormGroup({
        'password': new FormControl(null, [Validators.required]),
        'confirmPassword': new FormControl(null, [Validators.required])
      }, [this.compare])
    })
    this.authService.GetPasswordValidator().subscribe(validator => {
      this.setPasswordFieldValidators(validator);
      this.setPasswordErrors(validator);
    })
  }

  ngOnInit(): void {

  }

  onSubmit() {
    this.isLoading = true;
    let model: AuthModel = {
      email: this.registerForm.value.email,
      password: this.registerForm.value.passwords.password
    }
    this.authService.Register(model).subscribe({
      next: (response) => {
        this.isLoading = false;
        this.router.navigate(['Home'])

      },
      error: (message) => {
        this.isLoading = false;
        this.errorMessage = message;
      }
    })
  }
  addPasswordValidation(func: ValidatorFn) {
    this.registerForm.get('passwords.password')?.addValidators([func]);
  }
  setPasswordErrors(validator: PassowrdValidator) {
    this.passwordErrors = {
      'required': 'password field is required',
      'minlength': validator.requiredLength > 0 ? `password length should be more than ${validator.requiredLength} character` : '',
      'uniqueChars': validator.requiredUniqueChars > 0 ? `password should include at least ${validator.requiredUniqueChars} unique character` : '',
      'nonAlphanumeric': validator.requireNonAlphanumeric ? 'password should include non alphanumeric characters' : '',
      'lowercase': validator.requireLowercase ? 'password should include lowercase characters' : '',
      'uppercase': validator.requireUppercase ? 'password should include uppercase characters' : '',
      'digits': validator.requireDigit ? 'password should include digits' : ''
    }
  }
  setPasswordFieldValidators(validator: PassowrdValidator) {
    if (validator.requiredLength > 0) {
      this.addPasswordValidation(Validators.minLength(validator.requiredLength));
    }
    if (validator.requiredUniqueChars > 0) {
      this.addPasswordValidation(this.passwordUniqueChars(validator.requiredUniqueChars));
    }
    if (validator.requireNonAlphanumeric) {
      this.addPasswordValidation(this.passwordHasNonAlphaNumeric);
    }
    if (validator.requireDigit) {
      this.addPasswordValidation(this.passwordHasDigits);
    }
    if (validator.requireUppercase) {
      this.addPasswordValidation(this.passwordHasUpperCaseChar);
    }
    if (validator.requireLowercase) {
      this.addPasswordValidation(this.passwordHasLowerCaseChar);
    }
  }
  //#region custom validators
  compare(control: AbstractControl): { 'not-match': boolean } | null {
    if (control.get('password')?.value != control.get('confirmPassword')?.value) {
      return { 'not-match': true }
    }
    return null;
  }
  passwordUniqueChars(uniqueCharsMinCount: number): any {
    return (control: AbstractControl | null): { 'uniqueChars': boolean } | null => {
      if (control?.value) {
        let uniqueChars = (<string>control.value).split('').filter((value, index, self) => {
          return self.indexOf(value) === index;
        })
        if (uniqueChars.length < uniqueCharsMinCount) return { 'uniqueChars': true };
      }
      return null;
    }
  }
  passwordHasNonAlphaNumeric(control: AbstractControl): { 'nonAlphanumeric': boolean } | null {
    if (!(<string>control.value).match('[^a-zA-Z0-9\s]')) return { 'nonAlphanumeric': true }
    return null;
  }
  passwordHasDigits(control: AbstractControl): { 'digits': boolean } | null {
    if (!(<string>control.value).match('[0-9]')) return { 'digits': true }
    return null;
  }
  passwordHasUpperCaseChar(control: AbstractControl): { 'uppercase': boolean } | null {
    if (!(<string>control.value).match('[A-Z]')) return { 'uppercase': true }
    return null;
  }
  passwordHasLowerCaseChar(control: AbstractControl): { 'lowercase': boolean } | null {
    if (!(<string>control.value).match('[a-z]')) return { 'lowercase': true }
    return null;
  }
  // #endregion
}
type errors = { [code: string]: string }