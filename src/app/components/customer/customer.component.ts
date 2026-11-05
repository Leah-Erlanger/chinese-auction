import { Component, inject } from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Customer } from '../../models/customer.model';
import { CustomerServiceService } from '../../services/customer.service';
import { GiftServiceService } from '../../services/gift-service.service';
import { Gift } from '../../models/gift.model';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrl: './customer.component.css'
})
export class CustomerComponent {
  customer:Customer[]=[];
  gifts$:Gift[]=[];
  dialogVisible: boolean = false;
  constructor(private messageService: MessageService, private confirmationService: ConfirmationService) { }
  customerSrv: CustomerServiceService = inject(CustomerServiceService);
  crudSrv:GiftServiceService=inject(GiftServiceService)
  ngOnInit() {
    this.crudSrv.getAll().subscribe((gifts) => {
      this.gifts$ = gifts;
      
})
this.customerSrv.getCustomers().subscribe((customer1)=>{
  this.customer=customer1
  console.log(this.customer);
  
})
}
showDialog() {
  this.dialogVisible = true;
}


}
