import { Component, inject } from '@angular/core';
import { Category } from '../../models/category.model';
import { CategoryServiceService } from '../../services/category-service.service';
import { ConfirmationService, MessageService } from 'primeng/api';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrl: './category.component.css'
})
export class CategoryComponent {
  
  categoryDialog!: boolean;

  category$!: Category[];

  category!: Category;

  SelectedCategory!: Category[] ;

  submitted!: boolean;
  newCategories!:Category[];
  categorySrv: CategoryServiceService = inject(CategoryServiceService);
  constructor(private messageService: MessageService, private confirmationService: ConfirmationService) { }
  ngOnInit() {
    // console.log("aaa")
    // this.giftService.getAll().then(this.gift => console.log("bb",data) )//.then(data => this.gifts = data);
    // console.log("aaa")
    this.categorySrv.getAll().subscribe((category) => {
        this.category$ = category
    })
  }
//   openNew() {
//     console.log("bgfdhghgfhgfh");
    
//     this.category= new Category();
//     this.submitted = false;
//     this.categoryDialog = true;
// }
// saveCategory() {
//   this.categorySrv.add(this.category).subscribe(()=>{this.loadDemoData()})
//   // this.giftSrv.add(this.gift).subscribe((x)=>{this.newGifts = x})

//   // this.category.image = 'product-placeholder.svg';
//   this.category$.push(this.category);
//   this.messageService.add({
//       severity: 'success',
//       summary: 'Successful',
//       detail: 'Product Created',
//       life: 3000
//   });
// }
// loadDemoData() {
//   throw new Error('Method not implemented.');
// }
}
