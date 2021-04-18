import { Component, OnInit } from '@angular/core';
import { RoomDetail, RoomType, RoomDetailServiceResponse } from '../Models/RoomDetail';
import { Validator, FormArray, FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms'
import { RoomserviceService } from '../roomservice.service'

@Component({
  selector: 'app-rooms',
  templateUrl: './rooms.component.html',
  styleUrls: ['./rooms.component.css']
})
export class RoomsComponent implements OnInit {
  private roomDetail: RoomDetail
  private roomDetailFormBuilder: FormGroup
  submitted: boolean
  roomType: string = 'select';
  public roomTypes: RoomType[];
  public _roomService: RoomserviceService;
  public roomsListResp: RoomDetailServiceResponse[];
  public createRoomResp: boolean;
  public isServiceResp: boolean = false;
  public errorMessage: string;
  public selectedDate: string;
  constructor(public formBuilder: FormBuilder, public roomService: RoomserviceService) {
    this._roomService = roomService;
  }

  ngOnInit() {
    this.initDataControls();
    this.AddRoomDetailForm()
    this.getAllRoomDetail()
  }
  initDataControls() {
    this.roomDetail = new RoomDetail()
    this.roomDetail.roomNo = '';
    this.roomDetail.roomType = '';
  }
  //loadDefaultData() {
  //  debugger;
  //  this.roomTypes = [];
  //  this.roomTypes.push(new RoomType{ roomTypeId: "0", roomTypeValue: "Select room type" });
  //  this.roomTypes.push(new RoomType{ roomTypeId: "single", roomTypeValue: "Single room" });
  //  this.roomTypes.push(new RoomType{ roomTypeId: "double", roomTypeValue: "Double room" });
    
  //}
  getAllRoomDetail() {
    debugger;
    if (this.selectedDate != null && this.selectedDate != '') {
      
      this._roomService.getAllRoomDetail(this.selectedDate)
        .subscribe(x => this.roomsListResp = x,
          error => this.errorMessage = error);
    }
    console.log(this.roomsListResp);
  }
  AddRoomDetailForm() {
    this.roomDetailFormBuilder = this.formBuilder.group(
      {
        'roomNo': [this.roomDetail.roomNo, Validators.required],
        'roomType': [this.roomDetail.roomType, Validators.required]
      }
    )
  }

  onAddFormSubmit(formSubmitDetail: FormGroup) {

    this.submitted = true;
    if (formSubmitDetail.invalid) { return false }

    this.roomDetail = new RoomDetail()
    this.roomDetail.roomNo = formSubmitDetail.controls['roomNo'].value
    this.roomDetail.roomType = formSubmitDetail.controls['roomType'].value
    debugger;
    //console.log(this.roomDetail)
    this.isServiceResp = true;
    this._roomService.CreateNewRoom(this.roomDetail)
      .subscribe(x => this.createRoomResp = x,
        error => this.errorMessage = error);
  }
}
