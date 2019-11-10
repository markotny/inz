import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AlbumCardWideComponent } from './album-card-wide.component';

describe('AlbumCardWideComponent', () => {
  let component: AlbumCardWideComponent;
  let fixture: ComponentFixture<AlbumCardWideComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AlbumCardWideComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AlbumCardWideComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
