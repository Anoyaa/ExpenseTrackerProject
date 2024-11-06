import { Component } from '@angular/core';
import { ViewProfileComponent } from '../view-profile/view-profile.component';
import { CategoryExpenseComponent } from '../category-expense/category-expense.component';
import { AddExpenseComponent } from '../add-expense/add-expense.component';
import { ExpenseServiceService } from '../expense-service.service';
import { CommonModule } from '@angular/common';
import { UserIdService } from '../user-id.service';
import { TotalExpenseList } from './total-expense-list';
import { RetrievedExpense } from '../retrieved-expense';
import { Router, RouterModule } from '@angular/router';

export interface UserProfile {
  monthlyExpense: number;
  yearlyExpense: number;

}

@Component({
  selector: 'app-track-expense',
  standalone: true,
  imports: [CommonModule,RouterModule],
  templateUrl: './track-expense.component.html',
  styleUrl: './track-expense.component.scss'
})

export class TrackExpenseComponent {

expenseList:RetrievedExpense[]=[];
expenseFilterList:any[]=[];
userId = 0;
today = new Date();
startDate : Date=new Date();
endDate :Date=new Date();
isLoading = true;
  filter: boolean=false;
  totalExpenseList?: TotalExpenseList;
  yearlyExpense = 0;
constructor(private expenseService: ExpenseServiceService, private useridService: UserIdService) { }

ngOnInit(): void {
 this.userId = this.useridService.userId;
 this.filter=false;
  this.expenseService.getNewExpense(this.userId).subscribe({
    next: (data) => {
      // console.log('initially Fetched expenses:', data); 
      this.expenseList = data; 
    },
    error: (error) => {
      console.error(error);
    }
  })

  this.expenseService.getTotalExpense(this.userId).subscribe({
    next: (data) => {
      // console.log('initially Fetched total(yearly,weekly) expenses:', data); 
     this.totalExpenseList = data;
     this.yearlyExpense = data.yearlyExpense;
     this.isLoading = false;
    },
    error: (error) => {
      console.error(error);
    }
  })
  
}

onSelectStart(event:Event)
{
  const inputStartDate = event.target as HTMLInputElement;
    const selectedStartDate = inputStartDate.value;
    const selectedStartDateObj = new Date(selectedStartDate);

    if (selectedStartDateObj > this.today) {
      alert("Select current date or a past date !!");
    }
this.startDate=selectedStartDateObj;

}

onSelectEnd(event:Event)
{ 
  const inputEndDate = event.target as HTMLInputElement;
  const selectedEndDate = inputEndDate.value;
  const selectedEndDateObj = new Date(selectedEndDate);

  if(selectedEndDateObj>this.today)
  {
    alert("Select a current or past date !");
  }
  this.endDate=selectedEndDateObj;

}

onFilter()
{
  this.filter=true;
  this.expenseService.getFilterExpense(this.userId,this.startDate,this.endDate).subscribe({
  next: (data) => {
    console.log('Fetched expenses:', data); 
    this.expenseFilterList = data; 
  },
  error: (error) => {
    console.error(error);
  }
})
}

applyFilter()
{
this.onFilter();
}

}

