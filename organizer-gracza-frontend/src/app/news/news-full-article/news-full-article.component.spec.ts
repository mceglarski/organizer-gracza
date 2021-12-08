import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewsFullArticleComponent } from './news-full-article.component';

describe('NewsFullArticleComponent', () => {
  let component: NewsFullArticleComponent;
  let fixture: ComponentFixture<NewsFullArticleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewsFullArticleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewsFullArticleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
