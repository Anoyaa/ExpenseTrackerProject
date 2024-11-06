import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Route, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class ExpenseServiceService {

   constructor(private http:HttpClient) {}

  submitNewExpense(data:any):any {
      console.log(data)
       this.http.post('http://localhost:5277/api/Expense', data)
      .subscribe({
        next:(value)=>
        {
          console.log(value);
          alert("New Expense added successfully !");
         },
         error:(err)=>
         {
          console.log('error message:',err);
         }
      })
    
  }

  getNewExpense(id: number): Observable<any> {
    const params=new HttpParams().set('id',id);
    return this.http.get(`http://localhost:5277/api/Expense`,{params}); 
}

getTotalExpense(id:number):Observable<any>
{
  const params=new HttpParams().set('id',id);
  console.log();
  return this.http.get(`http://localhost:5277/api/Expense/total-by-date`,{params});  
}

getFilterExpense(id:number,startDate:Date,endDate:Date):Observable<any>
{
   const params=new HttpParams().set('Userid',id).set('startDate',startDate.toDateString()).set('endDate',endDate.toDateString());
  return this.http.get('http://localhost:5277/api/Expense/expense-by-date',{params});
}

removeExpense(UserId: number,ExpenseId:number) {
  const params=new HttpParams().set('UserId',UserId).set('ExpenseId',ExpenseId);
  const headers = { 'Accept': 'application/json' };

  return this.http.delete('http://localhost:5277/api/Expense',{params,headers});  
}

}