import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class CustomerServiceService {
  constructor(private http: HttpClient,private router:Router) { }

  submitNewUser(data: any): any {
     console.log("inside service:");
     console.log(data);
    this.http.post('http://localhost:5277/api/Users', data)
      .subscribe({
        next: (value) => {
          console.log(value);
          alert("User created successfully");
          this.router.navigate(['/login-page']);
        },
        error: (err) => {
          console.error('Registration error:', err);
        }
      })
  }

}
