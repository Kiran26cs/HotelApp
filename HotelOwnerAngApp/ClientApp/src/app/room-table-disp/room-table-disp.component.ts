import { Component, OnInit, Input } from '@angular/core';
import { RoomDetailServiceResponse } from '../Models/RoomDetail';

@Component({
  selector: 'app-room-table-disp',
  templateUrl: './room-table-disp.component.html',
  styleUrls: ['./room-table-disp.component.css']
})
export class RoomTableDispComponent implements OnInit {

  constructor() { }
  @Input() roomsListResp: RoomDetailServiceResponse[];
  ngOnInit() {
  }

}
