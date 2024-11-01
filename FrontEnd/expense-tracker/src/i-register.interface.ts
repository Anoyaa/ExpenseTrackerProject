import { FormControl } from "@angular/forms";

export interface IRegister 
{
    name:FormControl<string|null>;
    phoneNumber:FormControl<string|null>;
    password:FormControl<string|null>;
    cPassword:FormControl<string|null>;
}

