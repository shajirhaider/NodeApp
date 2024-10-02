import { Injectable } from '@angular/core';
import * as XLSX from 'xlsx';




const EXCEL_TYPE =
  'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';


@Injectable({
  providedIn: 'root'
})
export class ExcelExportService {

  constructor() { }

  exportTableToExcel(tableId: string, filename: string = 'export.xlsx', hide_last_row = false): void {
    // Get the table element
    const tableElement = document.getElementById(tableId);
    if (!tableElement) return;

    // Create a new workbook and add the worksheet
    const ws: XLSX.WorkSheet = XLSX.utils.table_to_sheet(tableElement);

    // if (hide_last_row) {
    //   ws['!cols']![ws['!cols']!.length - 1] = { hidden: true }; //hide last column
    // }
    if(hide_last_row){
      const range = XLSX.utils.decode_range(ws['!ref'] || '');
      const lastColumnIndex = range.e.c; // `e.c` gives the index of the last column
    
      // Remove all cells in the last column
      for (let row = range.s.r; row <= range.e.r; row++) {
        const cellRef = XLSX.utils.encode_cell({ r: row, c: lastColumnIndex }); // Encode cell reference
        delete ws[cellRef]; // Delete the cell from the ws
      }
    
      // Update the ws range to exclude the last column
      range.e.c -= 1; // Decrement the column index to exclude the last column
      ws['!ref'] = XLSX.utils.encode_range(range); // Update the worksheet reference

    }

    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');

    // Write the workbook and save it
    const excelBuffer: any = XLSX.write(wb, {
      bookType: 'xlsx',
      type: 'array',
    });
    const data: Blob = new Blob([excelBuffer], { type: EXCEL_TYPE });
    this.downloadClientBlob(data, filename)
  }
  private downloadClientBlob(blob: Blob, filename?: string) {
    const url = window.URL.createObjectURL(blob);
    const link = document.createElement('a');
    link.href = url;
    link.download = filename || 'export.xlsx';
    document.body.appendChild(link);
    link.click();
    window.URL.revokeObjectURL(url);
    document.body.removeChild(link);
  }
}
