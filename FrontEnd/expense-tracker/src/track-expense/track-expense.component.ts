import { Component } from '@angular/core';
import { UserIdService } from '../user-id.service';

@Component({
  selector: 'app-track-expense',
  standalone: true,
  imports: [],
  templateUrl: './track-expense.component.html',
  styleUrl: './track-expense.component.scss'
})
export class TrackExpenseComponent {
  userId: number|null = null;

  constructor(private userIdService : UserIdService){}

  ngOnInit(): void {
    //this.userId= this.userIdService.getUserId()
    //console.log("in track-expense userid is: ",this.userId)
    
  }
}
