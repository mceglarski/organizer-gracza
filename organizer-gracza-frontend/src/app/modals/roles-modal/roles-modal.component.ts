import {Component, EventEmitter, Input} from '@angular/core';
import {BsModalRef} from "ngx-bootstrap/modal";
import {User} from "../../model/model";

@Component({
  selector: 'app-roles-modal',
  templateUrl: './roles-modal.component.html',
  styleUrls: ['./roles-modal.component.css']
})
export class RolesModalComponent {
  @Input() updateSelectedRoles = new EventEmitter();
  // @ts-ignore
  user: User;
  // @ts-ignore
  roles: any[];

  constructor(public bsModalRef: BsModalRef) {
  }

  updateRoles() {
    this.updateSelectedRoles.emit(this.roles);
    this.bsModalRef.hide();
  }

}
