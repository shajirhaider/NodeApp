import { AfterViewInit, Component, computed, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { NgFor, NgIf } from '@angular/common';
import { ToastrService } from 'ngx-toastr';
import { UserService } from '../../../services/user.service';
import { MaterialImportsModule } from '../../../material-imports/material-imports.module';
import { ContactModel, EmailTemplateModel, NodeModel, SlaModel } from '../../../app.models';


@Component({
  standalone: true,
  selector: 'app-node-edit-dialog',
  imports: [MaterialImportsModule, ReactiveFormsModule, NgIf, NgFor],
  templateUrl: './edit-dialog.component.html',
  styleUrls: ['./edit-dialog.component.css']
})
export class EditDialogComponent implements AfterViewInit {


  errorMessage = ''

  form = new FormGroup({
    name: new FormControl({value : '', disabled: true}, [Validators.required]),
    alias: new FormControl({value : '', disabled: true}, [Validators.required]),
    aggregate: new FormControl({value : '', disabled: true}, [Validators.required]),
    player: new FormControl({value : '', disabled: true}, [Validators.required]),
    type: new FormControl({value : '', disabled: true}, [Validators.required]),
    subtype: new FormControl({value : '', disabled: true}, [Validators.required]),
    taskType: new FormControl('', [Validators.required]),
    emailTemplateId: new FormControl(0, [Validators.required]),
    slaId: new FormControl(0, [Validators.required]),
    shifting: new FormControl('', [Validators.required]),
    processDuration: new FormControl(0, [Validators.required]),
    contactId: new FormControl(0, [Validators.required]),
    contactCCId: new FormControl(0, [Validators.required]),
  });


  isLoading = false;
  taskType = ['Automatic', 'Email', 'e-banking']
  emailTemplates: EmailTemplateModel[] = []
  slas: SlaModel[] = []

  filteredContacts: ContactModel[] = []
  filteredContactsCC: ContactModel[] = []
  preview = ''
  prevSla : any
  prevEmail : any
  prevContact : any
  prevContactCC : any

  constructor(
    public dialogRef: MatDialogRef<EditDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { node?: NodeModel },
    private userService: UserService,
    private toastrService: ToastrService
  ) {

  }

  ngOnInit(): void {
    this.userService.loadSlaList().subscribe({
      next: (r) => this.slas = r.data!
    })
    this.userService.loadEmailTemplateList().subscribe({
      next: (r) => this.emailTemplates = r.data!
    })
  }

  ngAfterViewInit(): void {
    this.form.patchValue({
      name: this.data.node?.nodeName,
      alias: this.data.node?.alias,
      aggregate: this.data.node?.aggregate,
      player: this.data.node?.player,
      type: this.data.node?.nodeType,
      subtype: this.data.node?.nodeSubType,
      taskType: this.data.node?.taskType,
      emailTemplateId: this.data.node?.emailTemplateId,
      slaId: this.data.node?.slaId,
      shifting: this.data.node?.shifting,
      processDuration: this.data.node?.processDuration,
      contactId: this.data.node?.contactId,
      contactCCId: this.data.node?.contactCCId,
    });
    
    this.filterContacts()

  }

  getPreview(){
    if(this.preview === 'sla' && this.form.value?.slaId){
      this.prevSla = this.slas.filter((x)=> x.slaId == this.form.value?.slaId)[0]
    }
    else if(this.preview === 'email' && this.form.value.emailTemplateId){
      this.prevEmail = this.emailTemplates.filter((x)=> x.emailTemplateId == this.form.value?.emailTemplateId)[0]
    }
    else if(this.preview === 'contact' && this.form.value?.contactId){
      this.prevContact = this.filteredContacts.filter((x)=> x.contactId == this.form.value?.contactId)[0]
    }
    else if(this.preview === 'contactCC' && this.form.value?.contactCCId){
      this.prevContactCC = this.filteredContactsCC.filter((x)=> x.contactId == this.form.value?.contactCCId)[0]
    }
  }

  onSave(): void {
    this.isLoading = true
    this.userService.createUpdateNode({
      nodeId: this.data.node?.nodeId || 0,
      nodeName: this.data.node?.nodeName,
      alias: this.data.node?.alias,
      aggregate: this.data.node?.aggregate,
      nodeType: this.data.node?.nodeType || '',
      nodeSubType: this.data.node?.nodeSubType || '',
      slaId: this.form.value?.slaId,
      taskType: this.form.value?.taskType,
      emailTemplateId: this.form.value?.emailTemplateId,
      shifting: this.form.value?.shifting,
      processDuration: this.form.value?.processDuration,
      contactId: this.form.value?.contactId,
      contactCCId: this.form.value?.contactCCId,
      player: this.data.node?.player,

    })
      .subscribe({
        next: (response) => {
          this.dialogRef.close({ status: true, node: response.data });
          this.toastrService.success(response.message)
          this.isLoading = false
        },
        error: (error) => {
          this.errorMessage = error
          this.isLoading = false
        },
      })
  }

  onCancel(): void {
    this.dialogRef.close();
  }


  filterContacts() {
    // const player = this.form.value?.player;
    const player = this.data.node?.player;
    if (!player) {
      return
    }
    this.userService.loadFilteredContactList(player).subscribe({
      next: (response) => {
        this.filteredContacts = response.data!
        this.filteredContactsCC = response.data!

      }
    })

  }
}
