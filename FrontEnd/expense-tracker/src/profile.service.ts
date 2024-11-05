import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  constructor(private http: HttpClient) { }

  viewProfile(id: number): Observable<any> {
    const params = new HttpParams().set('id', id);
    return this.http.get(`http://localhost:5277/api/Users`, { params });
  }

  updateBudgetService(id: number,amount:number): Observable<any> {
    const body = { UserId: id, Amount: amount };
    return this.http.put(`http://localhost:5277/api/Budget`, body);
  }
}