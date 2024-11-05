import { Injectable } from '@angular/core';
import { CustomerServiceService } from './customer-service.service';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserIdService {

  userId: number| null = 0;
  constructor(private customerService: CustomerServiceService) { }

  setUserId(id: number): void {
    this.userId = id;
    console.log("SETuserid calledd")
  }

  getUserId(): Observable<number>{
    console.log("GETuserid calledd")
    return of(this.userId!);
  }


}
