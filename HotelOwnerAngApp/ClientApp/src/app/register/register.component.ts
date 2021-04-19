import { Component, OnInit } from '@angular/core';
import { RegisterUser, RegisterUserResponse } from '../Models/UserComponentViewModel';
import { Validator, FormArray, FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms'
import { AuthenticationService } from '../authentication.service'
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  private registerFormBuilder: FormGroup;
  public userRegisterDetail: RegisterUser;
  public userRegisterResp: any;
  public isServiceResp: boolean = false;
  public errorMessage: string;
  public selectedDate: string;
  public _authService: AuthenticationService;
  public submitted: boolean;
  constructor(public formBuilder: FormBuilder, public authService: AuthenticationService) {
    this._authService = authService;
  }

  ngOnInit() {
    this.initDataControls();
    this.AddRoomDetailForm();
  }
  initDataControls() {
    this.userRegisterDetail = new RegisterUser()
    this.userRegisterDetail.UserName = '';
    this.userRegisterDetail.Password = '';
    this.userRegisterDetail.Email = '';
  }

  AddRoomDetailForm() {
    this.registerFormBuilder = this.formBuilder.group(
      {
        'UserName': [this.userRegisterDetail.UserName, Validators.required],
        'Password': [this.userRegisterDetail.Password, Validators.required],
        'Email': [this.userRegisterDetail.Email, Validators.required]
      }
    )
  }

  onRegisterFormSubmit(formSubmitDetail: FormGroup) {

    this.submitted = true;
    if (formSubmitDetail.invalid) { return false }

    this.userRegisterDetail = new RegisterUser()
    this.userRegisterDetail.UserName = formSubmitDetail.controls['UserName'].value
    this.userRegisterDetail.Password = formSubmitDetail.controls['Password'].value
    this.userRegisterDetail.Email = formSubmitDetail.controls['Email'].value
    debugger;
    //console.log(this.roomDetail)
    this.isServiceResp = true;
    this._authService.createUser(this.userRegisterDetail)
      .subscribe(x => this.userRegisterResp = x,
        error => this.errorMessage = error);
  }
  
}
