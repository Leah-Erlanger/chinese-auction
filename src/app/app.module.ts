// import { NgModule } from '@angular/core';
// import { BrowserModule } from '@angular/platform-browser';
// import { AppRoutingModule } from './app-routing.module';
// import { AppComponent } from './app.component';
// import { GiftComponent } from './components/gift/gift.component';
// import {NoopAnimationsModule} from '@angular/platform-browser/animations'
// import {ImportsModule} from './imports'
// @NgModule({
//   declarations: [
//     AppComponent,
//     GiftComponent,
//   ],
//   imports: [    
//     BrowserModule,
//     AppRoutingModule,
//     NoopAnimationsModule,
//     ImportsModule
//   ],
//   providers: [],
//   bootstrap: [AppComponent]
// })
// export class AppModule { }
import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {FormsModule} from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {RouterModule} from '@angular/router';

import { AppComponent }   from './app.component';
import { GiftServiceService } from './services/gift-service.service';

import {TableModule} from 'primeng/table';
import {ToastModule} from 'primeng/toast';
import {CalendarModule} from 'primeng/calendar';
import {SliderModule} from 'primeng/slider';
import {MultiSelectModule} from 'primeng/multiselect';
import {ContextMenuModule} from 'primeng/contextmenu';
import {DialogModule} from 'primeng/dialog';
import {ButtonModule} from 'primeng/button';
import {DropdownModule} from 'primeng/dropdown';
import {ProgressBarModule} from 'primeng/progressbar';
import {InputTextModule} from 'primeng/inputtext';
import {FileUploadModule} from 'primeng/fileupload';
import {ToolbarModule} from 'primeng/toolbar';
import {RatingModule} from 'primeng/rating';
import {RadioButtonModule} from 'primeng/radiobutton';
import {InputNumberModule} from 'primeng/inputnumber';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ConfirmationService } from 'primeng/api';
import { MessageService } from 'primeng/api';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { Gift } from './models/gift.model';
import { GiftComponent } from './components/gift/gift.component';
import { DonorComponent } from './components/donor/donor.component';
import { DonorServiceService } from './services/donor-service.service';
import { CategoryComponent } from './components/category/category.component';
import { CategoryServiceService } from './services/category-service.service';
import { LoginComponent } from './components/login/login.component';
import { LoginService } from './services/login-service.service';
import { RegisterComponent } from './components/register/register.component';
import { RegisterService } from './services/register-service.service';
// import { StoreComponent } from './components/store/store.component';
import { StoreService } from './services/store-service.service';
import { StoreComponent } from './components/store/store.component';
import { DataViewModule } from 'primeng/dataview';
import {MenubarModule} from 'primeng/menubar';
import {MenuItem} from 'primeng/api';

import { OrderListModule } from 'primeng/orderlist';
import { AppRoutingModule } from './app-routing.module';
// import { HomeComponent } from './home/home.component';
import { NavigationBarAdminComponent } from './navigation-bar-admin/navigation-bar-admin.component';
import { FloatLabelModule } from 'primeng/floatlabel';
import { CustomerComponent } from './components/customer/customer.component';
import { CustomerServiceService } from './services/customer.service';
@NgModule({
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    TableModule,
    CalendarModule,
		SliderModule,
		DialogModule,
		MultiSelectModule,
		ContextMenuModule,
		DropdownModule,
		ButtonModule,
		ToastModule,
    InputTextModule,
    ProgressBarModule,
    HttpClientModule,
    FileUploadModule,
    ToolbarModule,
    RatingModule,
    FormsModule,
    RadioButtonModule,
    InputNumberModule,
    ConfirmDialogModule,
    InputTextareaModule,
    BrowserAnimationsModule,
    DataViewModule,
    OrderListModule,
    AppRoutingModule,
    MenubarModule,
    FloatLabelModule,
    RouterModule.forRoot([
      {path:'',component: AppComponent}

		])
  ],
  declarations: [ AppComponent, GiftComponent, DonorComponent, CategoryComponent, LoginComponent, RegisterComponent, StoreComponent, NavigationBarAdminComponent, CustomerComponent ],
  bootstrap:    [ AppComponent ],
  providers: [GiftServiceService, MessageService, ConfirmationService,DonorServiceService,CategoryServiceService,RegisterService,StoreService,LoginService,CustomerServiceService]
})

export class AppModule { 
  
} 