import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewsShortComponent } from './news-short.component';

describe('NewsShortComponent', () => {
  let component: NewsShortComponent;
  let fixture: ComponentFixture<NewsShortComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewsShortComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewsShortComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
