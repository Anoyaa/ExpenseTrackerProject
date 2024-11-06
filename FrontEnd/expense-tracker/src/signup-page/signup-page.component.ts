import { Component } from '@angular/core';
import { IRegister } from '../i-register.interface';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { CustomerServiceService } from '../customer-service.service';
import { Route, Router } from '@angular/router';


@Component({
  selector: 'app-signup-page',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './signup-page.component.html',
  styleUrl: './signup-page.component.scss'
})
export class SignupPageComponent {

  RegisterUser!: FormGroup<IRegister>;
  password: string = '';
  registerSubmitted: boolean = false;

/**
 *
 */
constructor(private customerService:CustomerServiceService,private router:Router) { }

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
  
    this.RegisterUser = new FormGroup<IRegister>
      ({
        name: new FormControl('', Validators.required),
        phoneNumber: new FormControl('', [Validators.required, Validators.pattern('^[0-9]{10}$')]),
        initialBudget:new FormControl(0,Validators.required),
        password: new FormControl('', [Validators.required, Validators.minLength(8)]),
        cPassword: new FormControl('', [Validators.required, Validators.minLength(8)])
      });
  }
  AddNewUser() {
    this.registerSubmitted = true;
    if (this.RegisterUser.valid) {
      console.log("button clicked");
      const newUser = {
        Name: this.RegisterUser.value.name,
        PhoneNumber: this.RegisterUser.value.phoneNumber,
        Password: this.RegisterUser.value.password,
      }
      
      this.customerService.submitNewUser(newUser);
      this.router.navigate(['/log-in']);
        alert("User Successfully Registered !");
  
    }
  }
}
