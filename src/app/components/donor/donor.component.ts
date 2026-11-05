import { Component, inject } from '@angular/core';
import { Donor } from '../../models/donor.model';
import { DonorServiceService } from '../../services/donor-service.service';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Observable } from 'rxjs';
import { Gift } from '../../models/gift.model';


@Component({
  selector: 'app-donor',
  templateUrl: './donor.component.html',
  styleUrl: './donor.component.css'
})
export class DonorComponent {
donorDialog!: boolean;

donors$!: Donor[];

donor!: Donor;

SelectedDonors!: Donor[] ;

submitted!: boolean;
donorSrv: DonorServiceService = inject(DonorServiceService);
constructor(private messageService: MessageService, private confirmationService: ConfirmationService) { }
list$: Observable<Donor[]> = this.donorSrv.getAll();
ngOnInit() {
    // console.log("aaa")
    // this.giftService.getAll().then(this.gift => console.log("bb",data) )//.then(data => this.gifts = data);
    // console.log("aaa")
    this.donorSrv.getAll().subscribe((donors) => {
        this.donors$ = donors
    }) 
}

openNew() {
    this.donor = new Donor();
    this.submitted = false;
    this.donorDialog = true;

}

deleteSelectedDonors() {
    this.confirmationService.confirm({
        message: 'Are you sure you want to delete the selected products?',
        header: 'Confirm',
        icon: 'pi pi-exclamation-triangle',
        accept: () => {
            for (let index = 0; index < this.SelectedDonors.length; index++) {
                this.donorSrv.deleteDonor(this.SelectedDonors[index].id).subscribe((donor)=>{this.donors$=donor})
            }
            this.SelectedDonors = [];
            this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Products Deleted', life: 3000 });
        }
    });
}

editDonor(donor: Donor) {
    this.donor = { ...donor };
    this.donorDialog = true;
}

deleteDonor(donor: Donor) {
    this.confirmationService.confirm({
        message: 'Are you sure you want to delete ' + donor.nameDonor + '?',
        header: 'Confirm',
        icon: 'pi pi-exclamation-triangle',
        accept: () => {
            this.donorSrv.deleteDonor(donor.id).subscribe((donors) => {
                this.donors$ = donors
            })
            //   this.gifts$ = this.gifts$.filter(val => val.id!== gift.id);
            // this.gift ={};
            this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Product Deleted', life: 3000 });
        }
    });
}

hideDialog() {
    this.donorDialog = false;
    this.submitted = false;
}
saveDonor() {
    this.submitted = true;

    if (this.donor.nameDonor?.trim()) {
        if (this.donor.id) {
            // this.gifts[this.findIndexById(this.gift.id)] = this.gift;
            
            this.donorSrv.editDonor(this.donor).subscribe((gifts)=>{
                this.donors$=gifts;
            })
         
        
            this.messageService.add({
                severity: 'success',
                summary: 'Successful',
                detail: 'Product Updated',
                life: 3000
             
            });
            


        } else {
            // this.gift.id = this.createId()
            this.donorSrv.add(this.donor).subscribe(()=>{this.loadDemoData()})
            // this.giftSrv.add(this.gift).subscribe((x)=>{this.newGifts = x})

            // this.donor.image = 'product-placeholder.svg';
            this.donors$.push(this.donor);
            this.messageService.add({
                severity: 'success',
                summary: 'Successful',
                detail: 'Product Created',
                life: 3000
            });
        }
      
        this.donors$ = [...this.donors$];
        this.donorDialog = false;
        this.donor = new Donor();
    }
}
    loadDemoData() {
        throw new Error('Method not implemented.');
    }

findIndexById(id: number): number {
    let index = -1;
    for (let i = 0; i < this.donors$.length; i++) {
        if (this.donors$[i].id === id) {
            index = i;
            break;
        }
    }

    return index;
}

// createId(): string {
//     let Id = '';
//     var chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
//     for (var i = 0; i < 5; i++) {
//         Id += chars.charAt(Math.floor(Math.random() * chars.length));
//     }
//     return Id;
// }

}

