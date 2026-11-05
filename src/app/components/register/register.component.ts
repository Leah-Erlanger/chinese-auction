import { Component } from '@angular/core';
import { LoginService } from '../../services/login-service.service';
import { ConfirmationService, MessageService} from 'primeng/api';
import { ActivatedRoute, Router } from '@angular/router';
import { Customer } from '../../models/customer.model';
import { RegisterService } from '../../services/register-service.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  register= new Customer();
  constructor(private registerService: RegisterService, private messageService: MessageService, private confirmationService: ConfirmationService, public router: Router, private activatedRoute: ActivatedRoute){}
  Register(){
         console.log(this.register);
          this.registerService.Register(this.register).subscribe({
              next:
                  () => {
                       this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Customer Added', life: 3000 });
                       this.router.navigate(['login'], {relativeTo: this.activatedRoute.parent})
                     
                      // this.resetForm(); // לאפס את הטופס לאחר ההצלחה
                  },
              error: (err) => {
                  this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Could not add Customer', life: 3000 });
              }
              
          });
          this.router.navigate(['login'], {relativeTo: this.activatedRoute.parent})
        } 
       

    //   register1= new Register();
      
  }

