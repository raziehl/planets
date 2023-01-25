import { Component } from '@angular/core';
import { NbDialogRef } from '@nebular/theme';

@Component({
  selector: 'app-edit-expedition',
  templateUrl: './edit-expedition.component.html',
  styleUrls: ['./edit-expedition.component.scss']
})
export class EditExpeditionComponent {

  constructor(
    private dialogRef: NbDialogRef<EditExpeditionComponent>
  ) {}

}
