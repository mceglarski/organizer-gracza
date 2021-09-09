import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewsExtendedComponent } from './news-extended.component';

describe('NewsExtendedComponent', () => {
  let component: NewsExtendedComponent;
  let fixture: ComponentFixture<NewsExtendedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewsExtendedComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewsExtendedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
