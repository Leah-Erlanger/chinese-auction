import { Component, inject } from '@angular/core';
import { Gift } from '../../models/gift.model';
import { GiftServiceService } from '../../services/gift-service.service';
import { ConfirmationService } from 'primeng/api';
import { MessageService } from 'primeng/api';
import { Observable } from 'rxjs';
import { DonorServiceService } from '../../services/donor-service.service';
import { Donor } from '../../models/donor.model';
import { Category } from '../../models/category.model';
import { CategoryServiceService } from '../../services/category-service.service';

@Component({
    selector: 'app-gift',
    templateUrl: './gift.component.html',
    styleUrl: './gift.component.css'
})
export class GiftComponent {

    giftDialog!: boolean;

    gifts$!: Gift[];

    gift!: Gift;

    SelectedGifts!: Gift[];

    newGifts!: Gift[];
    donors$: Donor[] = [];
    donors2: string[] = [];
    category2: string[] = [];
    submitted!: boolean;
    categoryDialog!: boolean;

    category$!: Category[];

    category!: Category;

    SelectedCategory!: Category[];
    categorySrv: CategoryServiceService = inject(CategoryServiceService);
    giftSrv: GiftServiceService = inject(GiftServiceService);
    donorSrv: DonorServiceService = inject(DonorServiceService);
    constructor(private messageService: MessageService, private confirmationService: ConfirmationService) { }
    list$: Observable<Gift[]> = this.giftSrv.getAll();
    ngOnInit() {
        this.giftSrv.getAll().subscribe((gifts) => {
            this.gifts$ = gifts
        this.categorySrv.getAll().subscribe((category) => {
                this.category$ = category;
                this.category2 = this.category$.map(x => x.nameCategory)
            })
        this.donorSrv.getAll().subscribe((donors) => {
                this.donors$ = donors;
                this.donors2 = this.donors$.map(x => x.nameDonor)
                //  console.log(this.donors2);
            })
            console.log(this.donors2);
            console.log(this.category2);

            return this.donors2, this.category2;

        })
    }
    openNew() {
        console.log("bgfdhghgfhgfh");

        this.gift = new Gift();
        this.submitted = false;
        this.giftDialog = true;
    }

    deleteSelectedGifts() {
        this.confirmationService.confirm({
            message: 'Are you sure you want to delete the selected products?',
            header: 'Confirm',
            icon: 'pi pi-exclamation-triangle',
            accept: () => {
                for (let index = 0; index < this.SelectedGifts.length; index++) {
                    // this.giftSrv.deleteGift(this.SelectedGifts[index].id).subscribe((gift)=>{this.gifts$=gift})
                }
                this.SelectedGifts = [];
                this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Products Deleted', life: 3000 });
            }
        });
    }
    editGift(gift: Gift) {
        console.log("ggg");
        
        this.gift = { ...gift };
        this.giftDialog = true;
    }

    deleteGift(gift: Gift) {
        this.confirmationService.confirm({
            message: 'Are you sure you want to delete ' + gift.nameGift + '?',
            header: 'Confirm',
            icon: 'pi pi-exclamation-triangle',
            accept: () => {
                this.giftSrv.deleteGift(gift.id).subscribe((gifts) => {
                    this.gifts$ = gifts
                })
                //   this.gifts$ = this.gifts$.filter(val => val.id!== gift.id);
                // this.gift ={};
                this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Product Deleted', life: 3000 });
            }
        });
    }

    hideDialog() {
        this.giftDialog = false;
        this.submitted = false;
    }

    saveGift() {
        this.submitted = true;

        if (this.gift.nameGift?.trim()) {
            if (this.gift.id) {
                // this.gifts[this.findIndexById(this.gift.id)] = this.gift;
                this.giftSrv.editGift(this.gift).subscribe((gifts) => {
                    this.gifts$ = gifts;
                    
                })
                this.messageService.add({
                    severity: 'success',
                    summary: 'Successful',
                    detail: 'Product Updated',
                    life: 3000
                });
            } else {
                // this.gift.id = this.createId()
                this.giftSrv.add(this.gift).subscribe(() => { this.loadDemoData() })
                // this.giftSrv.add(this.gift).subscribe((x)=>{this.newGifts = x})
                this.gift.image = 'product-placeholder.svg';
                this.gifts$.push(this.gift);
                this.messageService.add({
                    severity: 'success',
                    summary: 'Successful',
                    detail: 'Product Created',
                    life: 3000
                });
            }

            this.gifts$ = [...this.gifts$];
            this.giftDialog = false;
            this.gift = new Gift();
        }
    }
    // ngOnInit() {
    //     // console.log("aaa")
    //     // this.giftService.getAll().then(this.gift => console.log("bb",data) )//.then(data => this.gifts = data);
    //     // console.log("aaa")
    //     this.categorySrv.getAll().subscribe((category) => {
    //         this.category$ = category
    //     })
    //   }
    openNewCategory() {
        console.log("bgfdhghgfhgfh");

        this.category = new Category();
        this.submitted = false;
        this.categoryDialog = true;
    }
    saveCategory() {
        this.categorySrv.add(this.category).subscribe(() => { this.loadDemoData() })
        // this.giftSrv.add(this.gift).subscribe((x)=>{this.newGifts = x})

        // this.category.image = 'product-placeholder.svg';
        this.category$.push(this.category);
        this.messageService.add({
            severity: 'success',
            summary: 'Successful',
            detail: 'Product Created',
            life: 3000
        });
    }


    //   saveGift() {
    //     this.submitted = true;

    //     if (this.gift.nameGift.trim()) {
    //       if (this.gift.id) {
    //         // this.gifts$[this.findIndexById(this.gift.id)] = this.gift;


    //         this.crudSrv.update(this.gift).subscribe((gifts) => {
    //           this.gifts$ = gifts;
    //         });

    //         this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Gift Updated', life: 3000 });
    //       }
    //       else {
    //         // this.gift.id = this.createId();
    //         this.gift.image = 'gift-placeholder.svg';
    //         this.gifts$.push(this.gift);
    //         this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Gift Created', life: 3000 });
    //       }


    //       this.gifts$ = [...this.gifts$];
    //       this.giftDialog = false;

    //       // this.gift ;
    //     }
    //   }
    loadDemoData() {
        throw new Error('Method not implemented.');
    }
    findIndexById(id: number): number {
        let index = -1;
        for (let i = 0; i < this.gifts$.length; i++) {
            if (this.gifts$[i].id === id) {
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

