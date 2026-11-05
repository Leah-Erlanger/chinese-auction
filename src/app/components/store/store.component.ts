import { Component, inject } from '@angular/core';
// import { ImportsModule } from './imports';
import { DataView, DataViewLayoutOptions, DataViewModule } from 'primeng/dataview';

import { TagModule } from 'primeng/tag';
import { RatingModule } from 'primeng/rating';
import { SelectButtonModule } from 'primeng/selectbutton';
import { signal } from '@angular/core';
import { Gift } from '../../models/gift.model';
import { Donor } from '../../models/donor.model';
import { CommonModule, NgClass, NgFor } from '@angular/common'
import { ButtonModule } from 'primeng/button';
// import { LayOutComponent } from '../lay-out/lay-out.component';
import { FormsModule } from '@angular/forms';
import { DropdownModule } from 'primeng/dropdown';
import { StoreService } from '../../services/store-service.service';
import { Category } from '../../models/category.model';
import { ConfirmationService, MessageService } from 'primeng/api';
import { GiftServiceService } from '../../services/gift-service.service';
import { DonorServiceService } from '../../services/donor-service.service';
import { CategoryServiceService } from '../../services/category-service.service';
// import { StoreServiceService } from '../../services/store-service.service';


@Component({
  selector: 'app-store',
  // standalone: true,
  //  imports: [NgFor, NgClass, ButtonModule, SelectButtonModule, TagModule, DataViewModule, RatingModule, CommonModule,FormsModule,CommonModule,DropdownModule],
  templateUrl: './store.component.html',
  styleUrl: './store.component.css',
  providers: [StoreService]
})
export class StoreComponent {
  srcStore: StoreService = inject(StoreService);
  // flag: boolean = false;
  flagIsDarf: boolean = false;
  layout: any = "grid";

  gifts$ = signal<any>([]);
  gift!: Gift;
  product!:Gift[];
  donors$: Donor[] = [];
  donors2: string[] = [];
  category!: Category;
  category2: string[] = [];
  category$: Category[] = [];
  SelectedGifts: Gift[] = [];
  options = ['list', 'grid'];
  arr=new Array(41)
  flag:boolean=false;
  // input={"label":0}
  
  constructor(public StoreServiceService: StoreService,private messageService: MessageService, private confirmationService: ConfirmationService) { }
  crudSrv: GiftServiceService = inject(GiftServiceService);
  donorSrv: DonorServiceService = inject(DonorServiceService);
  categorySrv: CategoryServiceService = inject(CategoryServiceService);
  storeSrv: StoreService = inject(StoreService);


  
  ngOnInit() {
    this.crudSrv.getAll().subscribe((gifts) => {
      this.gifts$.set(gifts)

      this.categorySrv.getAll().subscribe((category) => {
        this.category$ = category;
        this.category2 = this.category$.map(x => x.nameCategory)
      })
      this.storeSrv.get().subscribe((gift1)=>{
        this.product=gift1
        
      })
      this.donorSrv.getAll().subscribe((donors) => {
        this.donors$ = donors;
        this.donors2 = this.donors$.map(x => x.nameDonor)
        console.log(this.donors2);
        console.log(this.category2);

        return this.donors2, this.category2;


      })



    })
    // let cart=JSON.parse(JSON.stringify(sessionStorage.getItem("cart")))||[]
    // sessionStorage.setItem("cart", cart)
    // for(let i=0;i<this.arr.length;i++)
    //   this.arr[i]={"label":i}
   
  }
  addToBasket(id: number) {
    this.storeSrv.addToBasket1(id).subscribe((h) => {
      console.log(h);
      this.storeSrv.get().subscribe((gift1) => {
        this.product = gift1})
        
    })
   

  }
  delete(id: number) {
    this.storeSrv.delete(id).subscribe((h) => {
      console.log(h);
      this.storeSrv.get().subscribe((gift1) => {
        this.product = gift1})
    })
  }

  buy(id: number) {
    this.flag=false
    this.storeSrv.buy(id).subscribe((h) => {
      console.log(h);
      this.storeSrv.get().subscribe((gift1) => {
        this.product = gift1})

    })
    this.flagIsDarf = true;
  }

}