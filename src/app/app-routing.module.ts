import { NgModule } from '@angular/core';
import { GiftComponent } from './components/gift/gift.component';
import { DonorComponent } from './components/donor/donor.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { CategoryComponent } from './components/category/category.component';
import { StoreComponent } from './components/store/store.component';
// import { NavigationBarUserComponent } from './components/navigation-bar-user/navigation-bar-user.component';
import { RouterModule, Routes } from '@angular/router';
// import { HomeComponent } from './home/home.component';
import { NavigationBarAdminComponent } from './navigation-bar-admin/navigation-bar-admin.component';
import { CustomerServiceService } from './services/customer.service';

const routes: Routes = [ 
  {path: '', redirectTo:'home/0', pathMatch:'full'},

  { path: 'home/:id', component: NavigationBarAdminComponent ,children:[
    { path: 'register', component: RegisterComponent},
    { path: 'login', component: LoginComponent },
    { path: 'donor', component: DonorComponent},
    { path: 'store', component: StoreComponent },
    { path: 'gift', component: GiftComponent },
    { path: 'customer', component: CustomerServiceService },
  ]},  // דף הבית שלך
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

// const routes: Routes = [
//   { path: '**', pathMatch: 'full',redirectTo: 'login' },
//   { path: 'login', component: LoginComponent },
//   { path: 'register', component: RegisterComponent },

//   {
//     path: '', component: NavigationBarUserComponent,
//     children: [
//       {path: 'store', component: StoreComponent},
// ]},
//   // app-navigation-bar-user
//   { path: 'gift', component: GiftComponent },
//   { path: 'donor', component: DonorComponent },
//   { path: 'category', component: CategoryComponent },
//   // {path:'buing', component:BuingComponent}
// ];

// @NgModule({
//   imports: [RouterModule.forRoot(routes)],
//   exports: [RouterModule]
// })
export class AppRoutingModule { }


