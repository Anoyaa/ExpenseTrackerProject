import { Component } from '@angular/core';
import { IRegister } from '../i-register.interface';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { CustomerServiceService } from '../customer-service.service';


@Component({
  selector: 'app-signup-page',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './signup-page.component.html',
  styleUrl: './signup-page.component.scss'
})
export class SignupPageComponent {

  RegisterUser!: FormGroup<IRegister>;

  registerSubmitted: boolean = false;


  constructor(private customerService: CustomerServiceService) { }

  ngOnInit(): void {
    this.RegisterUser = new FormGroup<IRegister>
      ({
        name: new FormControl('', Validators.required),
        phoneNumber: new FormControl('', [Validators.required, Validators.pattern('^[0-9]{10}$')]),
        password: new FormControl('', [Validators.required, Validators.minLength(8)]),
        cPassword: new FormControl('', [Validators.required, Validators.minLength(8)])
      });
  }
  AddNewUser() {
    this.registerSubmitted = true;
    if (this.RegisterUser.valid) {
      //console.log("button clicked");
      const newUser = {
        Name: this.RegisterUser.value.name,
        PhoneNumber: this.RegisterUser.value.phoneNumber,
        Password: this.RegisterUser.value.password,
      }
      this.customerService.submitNewUser(newUser);
    }
  }
}
