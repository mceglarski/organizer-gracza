import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MessagesMembersChatComponent } from './messages-members-chat.component';

describe('MessagesMembersChatComponent', () => {
  let component: MessagesMembersChatComponent;
  let fixture: ComponentFixture<MessagesMembersChatComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MessagesMembersChatComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MessagesMembersChatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
