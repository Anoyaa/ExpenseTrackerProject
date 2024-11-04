import { Component } from '@angular/core';
import { ViewProfileComponent } from '../view-profile/view-profile.component';
import { CategoryExpenseComponent } from '../category-expense/category-expense.component';
import { AddExpenseComponent } from '../add-expense/add-expense.component';

@Component({
  selector: 'app-track-expense',
  standalone: true,
  imports: [ViewProfileComponent,TrackExpenseComponent,CategoryExpenseComponent,AddExpenseComponent],
  templateUrl: './track-expense.component.html',
  styleUrl: './track-expense.component.scss'
})
export class TrackExpenseComponent {

}
