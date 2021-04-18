import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RoomTableDispComponent } from './room-table-disp.component';

describe('RoomTableDispComponent', () => {
  let component: RoomTableDispComponent;
  let fixture: ComponentFixture<RoomTableDispComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RoomTableDispComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RoomTableDispComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
