import { NgModule } from '@angular/core';
import { CommonModule, NgFor } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { MatOptionModule } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';
import { MatRadioModule } from '@angular/material/radio';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule, MatHint } from '@angular/material/form-field';
import { MatChipsModule } from '@angular/material/chips';
import { MatGridListModule } from '@angular/material/grid-list';



@NgModule({
  declarations: [

  ],
  imports: [
    CommonModule,
    MatTableModule, MatChipsModule, MatHint,  MatGridListModule, MatInputModule, MatProgressSpinnerModule, MatPaginatorModule, MatIconModule, MatProgressBarModule, MatButtonModule, MatButtonToggleModule, MatSortModule, MatTableModule, MatOptionModule, MatSelectModule, MatRadioModule, MatCardModule, MatFormFieldModule
  ],
  exports: [MatTableModule, MatChipsModule, MatHint, MatGridListModule, MatInputModule, MatProgressSpinnerModule, MatPaginatorModule, MatIconModule, MatProgressBarModule, MatButtonModule, MatButtonToggleModule, MatSortModule, MatTableModule, MatOptionModule, MatSelectModule, MatRadioModule, MatCardModule, MatFormFieldModule]
})
export class MaterialImportsModule { }
