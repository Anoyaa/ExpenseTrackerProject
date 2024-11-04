import { Component } from '@angular/core';
import { ViewProfileComponent } from '../view-profile/view-profile.component';
import { CategoryExpenseComponent } from '../category-expense/category-expense.component';
import { AddExpenseComponent } from '../add-expense/add-expense.component';
import { IExpenseInterface } from '../i-expense.interface';
import { FormGroup } from '@angular/forms';
import { ExpenseServiceService } from '../expense-service.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-track-expense',
  standalone: true,
  imports: [ViewProfileComponent,TrackExpenseComponent,CategoryExpenseComponent,AddExpenseComponent,CommonModule],
  templateUrl: './track-expense.component.html',
  styleUrl: './track-expense.component.scss'
})
export class TrackExpenseComponent {

expenseList:any[]=[];
userId:number=1;
expense:any;
constructor(private expenseService: ExpenseServiceService) { }

// ngOnInit():void
// {
//   const expenseUserId =
//   {
    // Amount: this.expenseList.Amount,
    // Description: this.expenseList.Description,
    // CategoryName:this.expenseList.Category,
//     UserId:1
//   }
//  this.expenseList= this.expenseService.getNewExpense(expenseUserId);
//}
//}



// this.expenseService.getNewExpense(this.userId).subscribe({
//   next:(data) =>
//  {
//   this.expense = data;
// }, 
// error:(error) => {
//   console.error('Error fetching user details:', error);
// }
// })

ngOnInit(): void {
  this.expenseService.getNewExpense(this.userId).subscribe({
    next: (data) => {
      console.log('Fetched expenses:', data); // Log the fetched data
      this.expenseList = data; // Assuming data is an array of expenses
    },
    error: (error) => {
      console.error('Error fetching expenses:', error);
    }
  });
}
}

