import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewsTeaserComponent } from './news-teaser.component';

describe('NewsTeaserComponent', () => {
  let component: NewsTeaserComponent;
  let fixture: ComponentFixture<NewsTeaserComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewsTeaserComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewsTeaserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
