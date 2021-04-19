import { Component, OnInit } from '@angular/core';
import { UserLogin, UserLoginResponse } from '../Models/UserComponentViewModel';
import { Validator, FormArray, FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms'
import { AuthenticationService } from '../authentication.service'
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  private loginFormBuilder: FormGroup;
  public userLoginDetail: UserLogin;
  public userLoginResp: UserLoginResponse;
  public isServiceResp: boolean = false;
  public errorMessage: string;
  public selectedDate: string;
  public _authService: AuthenticationService;
  public submitted: boolean;
  public loginSuccess: boolean = false;
  constructor(public formBuilder: FormBuilder, public authService: AuthenticationService, private router: Router) {
    this._authService = authService;
  }

  ngOnInit() {
    this.initDataControls();
    this.AddRoomDetailForm();
  }
  initDataControls() {
    this.userLoginDetail = new UserLogin()
    this.userLoginDetail.UserName = '';
    this.userLoginDetail.Password = '';
  }
 
  AddRoomDetailForm() {
    this.loginFormBuilder = this.formBuilder.group(
      {
        'UserName': [this.userLoginDetail.UserName, Validators.required],
        'Password': [this.userLoginDetail.Password, Validators.required]
      }
    )
  }

  onLoginFormSubmit(formSubmitDetail: FormGroup) {

    this.submitted = true;
    if (formSubmitDetail.invalid) { return false }

    this.userLoginDetail = new UserLogin()
    this.userLoginDetail.UserName = formSubmitDetail.controls['UserName'].value
    this.userLoginDetail.Password = formSubmitDetail.controls['Password'].value
    debugger;
    //console.log(this.roomDetail)
    this.isServiceResp = true;
    this._authService.login(this.userLoginDetail)
      .subscribe(x => {
        if (x != null && (x.token != null || x.token != undefined)) {
          this.loginSuccess = true;
          localStorage.setItem('letohppa_vrsetacitnehtua', JSON.stringify(x));
          this.router.navigate(['/']);
        }
      });
    
  }

  onLogoutClick() {
    this._authService.logout();
    location.reload(true);
  }
}
