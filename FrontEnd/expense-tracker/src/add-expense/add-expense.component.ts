import { Component } from '@angular/core';
import { ExpenseServiceService } from '../expense-service.service';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { IExpenseInterface } from '../i-expense.interface';

@Component({
  selector: 'app-add-expense',
  standalone: true,
  imports: [CommonModule,ReactiveFormsModule],
  templateUrl: './add-expense.component.html',
  styleUrl: './add-expense.component.scss'
})
export class AddExpenseComponent {

  expenseSubmitted:boolean=false;
  addExpenseDetails!: FormGroup<IExpenseInterface>;

  /**
   *
   */
  constructor(private expenseService: ExpenseServiceService) { }

  today: Date = new Date();
  dd = (this.today.getDate()).toString();
  mm = (this.today.getMonth() + 1).toString(); //January is 0!
  yyyy = (this.today.getFullYear()).toString();

  shownDate = this.yyyy + '-' + this.mm + '-' + this.dd;

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.addExpenseDetails = new FormGroup<IExpenseInterface>
      ({
        Amount: new FormControl(0, [Validators.required]),
        Description: new FormControl(''),
        Category: new FormControl('', Validators.required),
        Id: new FormControl(1)
      });
  }

  addExpense() {
    this.expenseSubmitted=true;

    if (this.addExpenseDetails.valid) {
      const newExpense =
      {
        Amount: this.addExpenseDetails.value.Amount,
        Description: this.addExpenseDetails.value.Description,
        CategoryName:this.addExpenseDetails.value.Category,
        UserId:this.addExpenseDetails.value.Id
      }
      this.expenseService.submitNewExpense(newExpense);
    }
  }
}
