import { Component, OnInit, Input, inject } from '@angular/core';
import { Gift } from './models/gift.model';
import { GiftServiceService } from './services/gift-service.service';
import { ConfirmationService, MenuItem } from 'primeng/api';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
    styles: [`
        :host ::ng-deep .p-dialog .product-image {
            width: 150px;
            margin: 0 auto 2rem auto;
            display: block;
        }
    `],
    styleUrls: ['./app.component.scss']
})
export class AppComponent {

}