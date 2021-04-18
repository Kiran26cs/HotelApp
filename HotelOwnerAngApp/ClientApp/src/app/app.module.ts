import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { RoomsComponent } from './rooms/rooms.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RoomListComponent } from './room-list/room-list.component';
import { BsDatepickerModule, BsDatepickerConfig  } from 'ngx-bootstrap/datepicker'
import { RoomserviceService } from '../app/roomservice.service'
import { DatePipe } from '@angular/common';
import { RoomTableDispComponent } from './room-table-disp/room-table-disp.component'

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    RoomsComponent,
    RoomListComponent,
    RoomTableDispComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'rooms', component: RoomsComponent },
    ]),
    BsDatepickerModule.forRoot()
  ],
  providers: [RoomserviceService, BsDatepickerConfig, DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
