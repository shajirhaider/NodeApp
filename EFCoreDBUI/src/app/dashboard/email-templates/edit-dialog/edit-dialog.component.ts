import { AfterViewInit, ChangeDetectionStrategy, Component, Inject, OnDestroy, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { NgFor, NgIf } from '@angular/common';
import { ToastrService } from 'ngx-toastr';
import { NgxEditorModule, Editor } from 'ngx-editor';
import { UserService } from '../../../services/user.service';
import { MaterialImportsModule } from '../../../material-imports/material-imports.module';
import { EmailTemplateModel } from '../../../app.models';


@Component({
  standalone: true,
  selector: 'app-edit-dialog',
  imports: [MaterialImportsModule, ReactiveFormsModule, NgIf, NgFor, NgxEditorModule],
  templateUrl: './edit-dialog.component.html',
  styleUrls: ['./edit-dialog.component.css'],
  // changeDetection: ChangeDetectionStrategy.OnPush,

})
export class EditDialogComponent implements AfterViewInit, OnInit, OnDestroy  {

  errorMessage = ''
  editor: Editor = new Editor ();
  html = '';
  form = new FormGroup({
    templateName: new FormControl('', [Validators.required]),
    subject: new FormControl('', [Validators.required]),
    body: new FormControl('', [Validators.required]),

  })

  isLoading = false;
  placeholderList = ["[FullName]","[FirstName]","[LastName]","[Dossier]","[CC]","[Today]","[EOH-1]","[EOH-2]","[EOM-n]","[EOY-n]","[Signature]"]

  constructor(
    public dialogRef: MatDialogRef<EditDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { template?: EmailTemplateModel },
    private userService: UserService,
    private toastrService: ToastrService
  ) {

  }




  ngOnInit(): void {}
  
  ngOnDestroy(): void {
    this.editor.destroy();
  }

  ngAfterViewInit(): void {
    this.form.patchValue({
      templateName: this.data.template?.emailTemplateName,
      subject: this.data.template?.emailTemplateSubject,
      body: this.data.template?.emailTemplateBody,
    })
  }
  onSave(): void {
    this.isLoading = true
    this.userService.createUpdateEmailTemplate({
      emailTemplateName: this.form.value?.templateName,
      emailTemplateSubject: this.form.value?.subject,
      emailTemplateBody: this.form.value?.body,
      emailTemplateId: this.data.template?.emailTemplateId
    }).subscribe({
      next: (response) => {
        this.dialogRef.close({ status: true, template: response.data });
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
}
