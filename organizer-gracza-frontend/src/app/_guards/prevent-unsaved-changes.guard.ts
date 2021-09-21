import { Injectable } from '@angular/core';
import {CanDeactivate } from '@angular/router';
import {MemberEditComponent} from "../member-page/member-edit/member-edit.component";

@Injectable({
  providedIn: 'root'
})
export class PreventUnsavedChangesGuard implements CanDeactivate<unknown> {
  canDeactivate(component: MemberEditComponent):  boolean {
    if(component.editForm.dirty){
      return confirm('Jesteś pewien, że chcesz kontynuować? Wszystkie niezapisane zmiany zostaną utracone!');
    }
    return true;
  }

}
