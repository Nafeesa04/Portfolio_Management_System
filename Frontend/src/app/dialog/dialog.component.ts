import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup,FormBuilder,Validators } from '@angular/forms';
import { ApiService } from '../maintain/api.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog'
import { SafeValue } from '@angular/platform-browser';

@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.css']
})
export class DialogComponent implements OnInit {
  portfolioForm !: FormGroup
  actionBtn : string ="Save"
  constructor(private formBuilder:FormBuilder,
    private api:ApiService,
    @Inject(MAT_DIALOG_DATA) public editData:any,
    private dialogRef:MatDialogRef<DialogComponent>) { }

  ngOnInit(): void {
    this.portfolioForm=this.formBuilder.group(
      {
        portfolioId :['',Validators.required],
        stockName :['',Validators.required],
        tradetype:[''],
        quantity:['',Validators.required],
        date:['',Validators.required],
        amount:['',Validators.required]
      })
      if(this.editData){
        this.actionBtn="Update";
        this.portfolioForm.controls['portfolioId'].setValue(this.editData.portfolioId);
        this.portfolioForm.controls['stockName'].setValue(this.editData.stockName);
        this.portfolioForm.controls['tradetype'].setValue(this.editData.tradetype);
        this.portfolioForm.controls['quantity'].setValue(this.editData.quantity);
        this.portfolioForm.controls['date'].setValue(this.editData.date);
        this.portfolioForm.controls['amount'].setValue(this.editData.amount)
      }
  }
  addDetails(){
   if(!this.editData){
    if(this.portfolioForm.valid){
      this.api.postPortfolio(this.portfolioForm.value).subscribe({
        next:(res)=>{
          alert("Details added Successfully!!");
          this.portfolioForm.reset();
          this.dialogRef.close('save');
        },error:()=>{
          alert("Error while adding details!!")
        }
      })
    }
   }else{
    this.updateDetails()
   }
  }
  updateDetails()
  {
    this.api.putPortfolio(this.portfolioForm.value,this.editData.id).subscribe({
      next:(res)=>{
        alert("Portfolio Updated Successfully!!");
        this.portfolioForm.reset();
        this.dialogRef.close('update');
      },error:()=>{
        alert("Error while updating details!!")
      }
    })
  }
  
}
