import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AlbumGridComponent } from './album-grid.component';

describe('AlbumGridComponent', () => {
  let component: AlbumGridComponent;
  let fixture: ComponentFixture<AlbumGridComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AlbumGridComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AlbumGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
