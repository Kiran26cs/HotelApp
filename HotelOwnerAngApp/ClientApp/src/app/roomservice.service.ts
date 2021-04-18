import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { RoomDetailServiceResponse, RoomDetailServiceResponseWrapper, RoomDetail } from '../app/Models/RoomDetail';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { strictEqual } from 'assert';
import { DatePipe } from '@angular/common'

@Injectable()
export class RoomserviceService {
  public roomGetServiceApiURL: string;
  public rommServiceApiURL = 'https://localhost:44349/api/Hotel';
  constructor(private _http: HttpClient, private datePipe: DatePipe) { }

  getAllRoomDetail(dateSelected: string): Observable<RoomDetailServiceResponse[]> {
    dateSelected = this.datePipe.transform(dateSelected, "yyyy-MM-dd")
    this.roomGetServiceApiURL = `${this.rommServiceApiURL}/${dateSelected}`;
    return this._http.get<RoomDetailServiceResponseWrapper>(this.roomGetServiceApiURL)
      .map(x => x.roomsData)
      .catch(this.handleCatchErrors);
  }

  CreateNewRoom(newRoom: RoomDetail): Observable<any> {
    const headers = { 'content-type': 'application/json' }
    const roomJson = JSON.stringify(newRoom);
    return this._http.post(this.rommServiceApiURL, roomJson, {headers: headers});
  }

  handleCatchErrors(error: HttpErrorResponse) {
    return Observable.throw(error.message);
  }
}
