import { Component } from '@angular/core';
import { ExpenseServiceService } from '../expense-service.service';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { IExpenseInterface } from '../i-expense.interface';
import { CategoryServiceService } from '../category-service.service';
import { UserIdService } from '../user-id.service';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-add-expense',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, FormsModule,RouterModule],
  templateUrl: './add-expense.component.html',
  styleUrl: './add-expense.component.scss'
})
export class AddExpenseComponent {

  expenseSubmitted: boolean = false;
  addExpenseDetails!: FormGroup<IExpenseInterface>;
  //categoryList: string[] = [];
  addCategoryFlag = false;
  categoryName!:string;
  categoryList: { name: string }[] = [];
  userId: number = 0;
  Today: Date = new Date();
  form: any;

  constructor(private expenseService: ExpenseServiceService, private categoryService: CategoryServiceService, private userIdService: UserIdService) { }

  onChange(event: Event) {

    const input = event.target as HTMLInputElement;
    const selectedDate = input.value;
    const selectedDateObj = new Date(selectedDate);
    const today = new Date();

    if (selectedDateObj > today) {
      alert("Select current date or a past date !!");
    }
  }

  ngOnInit(): void {
    this.userId=this.userIdService.userId;
    this.addExpenseDetails = new FormGroup<IExpenseInterface>
      ({
        Date: new FormControl(null, Validators.required),
        Amount: new FormControl(0, [Validators.required]),
        Description: new FormControl(''),
        Category: new FormControl('', Validators.required),
        Id: new FormControl(this.userId),
      });

    this.categoryService.getCategoryList(this.userId).subscribe({
      next: (data) => {
        this.categoryList = data;
        console.log("Fetched categories: ",this.categoryList);
      },
      error: (error) => {
        console.log(error)
      }
    })
  }

  addExpense() {
    this.expenseSubmitted = true;

    if (this.addExpenseDetails.valid) {
      console.log("id isssssssss",this.userId)
      const newExpense =
      {
        Amount: this.addExpenseDetails.value.Amount,
        Description: this.addExpenseDetails.value.Description,
        CategoryName: this.addExpenseDetails.value.Category,
        Date:this.addExpenseDetails.value.Date,
        UserId: this.userId
      }
      this.expenseService.submitNewExpense(newExpense);
    }
  }

  addCategory(){
    const postedCategory = {
      userId: this.userId,
      name: this.categoryName
    }
    this.categoryService.addNewCategory(postedCategory).subscribe({
      next: (response) => {
        this.addCategoryFlag = false;
        alert("New category added!");
      },
      error: (error) => {
        console.error('Error adding category:', error);
      }
    });
  }
}