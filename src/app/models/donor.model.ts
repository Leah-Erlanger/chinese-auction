import { Gift } from "./gift.model";

export  class Donor{
    id: number=0;
    nameDonor: string ="";
    emailDonor? : string="" ;
    phoneDonor? : string="";
    giftListForDonor!:Gift[];
} 