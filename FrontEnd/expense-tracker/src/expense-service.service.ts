import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ExpenseServiceService {
  
   /**
    *
    */
   constructor(private http:HttpClient) { }

  submitNewExpense(data:any):any {
       this.http.post('http://localhost:5277/api/Expense', data)
      .subscribe({
        next:(value)=>
        {
          console.log(value);
         },
         error:(err)=>
         {
          console.log('error message:',err);
         }
      })
    
  }

  // to get the expense list
  // getNewExpense(id:number):Observable<any>{
  

    // this.http.get('http://localhost:5277/api/Expense', data)
    // .subscribe({
    //   next:(value)=>
    //   {
    //     console.log(value);
    //    },
    //    error:(err)=>
    //    {
    //     console.log('error message:',err);
    //    }
    //   })
  //     return this.http.get(`http://localhost:5277/api/Expense/${id}`);
  // }
  getNewExpense(id: number): Observable<any> {
    return this.http.get(`http://localhost:4200/api/Expense/${id}`); 
}

}
