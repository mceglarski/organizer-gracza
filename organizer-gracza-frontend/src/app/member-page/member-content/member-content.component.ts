import {ChangeDetectorRef, Component, OnInit} from '@angular/core';
import {Member} from "../../model/model";
import {MembersService} from "../../_services/members.service";
import {ActivatedRoute} from "@angular/router";

@Component({
  selector: 'app-member-content',
  templateUrl: './member-content.component.html',
  styleUrls: ['./member-content.component.css']
})
export class MemberContentComponent implements OnInit {

  public member: Member;

  constructor(private memberService: MembersService,
              private route: ActivatedRoute,
              private cd: ChangeDetectorRef) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      const name = params['username'];
      this.memberService.getMember(name).subscribe(m => {
        this.member = m;
        this.cd.detectChanges();
        return;
      });
      return;
    })
    this.cd.detectChanges();
  }

}
