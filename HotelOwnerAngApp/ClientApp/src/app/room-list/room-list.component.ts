import { Component, OnInit, Input } from '@angular/core';
import { RoomDetailServiceResponse } from '../Models/RoomDetail';

@Component({
  selector: 'app-room-list',
  templateUrl: './room-list.component.html',
  styleUrls: ['./room-list.component.css']
})
export class RoomListComponent implements OnInit {

  constructor() { }
  @Input() RoomDataResp: RoomDetailServiceResponse;
  ngOnInit() {
  }

}
