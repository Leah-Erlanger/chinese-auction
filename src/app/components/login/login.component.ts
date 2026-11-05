import { Component, EventEmitter, OnInit, Output, output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LoginService } from '../../services/login-service.service';
import { Login } from '../../models/login.model';
import { ConfirmationService, Message, MessageService } from 'primeng/api';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})

export class LoginComponent {
  login = new Login();
  // token!: string;
  token: any;
  a: any;
  b: any;
  jsonToken: any;
  messages: Message[] | undefined;
  value!: string;
  @Output() isUser: EventEmitter<number> = new EventEmitter();
  constructor(private loginService: LoginService, private messageService: MessageService, private confirmationService: ConfirmationService, private router: Router,
    private activatedRoute: ActivatedRoute
  ) { }


  logIn() {

    if (this.login.userName && this.login.password) {
      console.log(this.login.userName);

      this.loginService.logIn(this.login).subscribe({
        next: (res) => {

          this.loginService.login = this.login;
          console.log("Response from server:", res);

          // קבלת הטוקן מתוך התגובה
          if (res && res.token) {

            sessionStorage.setItem("token", res.token); // שמירת הטוקן ב-session storage
            if (res.isManager) {
              this.loginService.isUser = 2;
              this.router.navigate(['../' + 2], {relativeTo: this.activatedRoute.parent})

              // this.router.navigate(['store']);
            }
            else {
              this.loginService.isUser = 1;
              this.router.navigate(['../' + 1], {relativeTo: this.activatedRoute.parent})

              // this.router.navigate([".."+/1], 
              //   {relativeTo: this.activatedRoute, queryParams: 
              //         {GfG: 'Geeks for Geeks'}});
              
              // this.router.navigate(['gift']); // ניווט לדף הבית
            }

            // this.showSuccess()
          } else {
            alert("שגיאה: לא התקבל טוקן מהשרת.");
          }
        },
        error: (err) => {
          // console.error("Error during login:", err);

          // טיפול במקרה של שגיאה מהשרת
          if (err.status === 401) {
            // alert("hgdfhgfghgfxd")
            this.showError()
            this.router.navigate(['register'], {relativeTo: this.activatedRoute.parent})

          } else {
            alert("שגיאה: לא ניתן להתחבר כרגע, נסה שוב מאוחר יותר.");
          }
        }
      });
    } else {
      alert("אנא מלא את כל השדות הדרושים!");
    }
  }
  showSuccess() {
    this.messages = [
      { severity: 'success', detail: 'Success Message' },
    ]
    console.log("123123");

  }
  showError() {
    this.messages = [
      { severity: 'success', detail: 'Success Message' },
    ]
    this.messages = [
      { severity: 'error', detail: 'Error Message' },
    ]
  }

  // logIn() {
  //   debugger
  //   if (this.login.userName && this.login.password) {
  //     console.log(this.login.userName);

  //     this.loginService.logIn(this.login).subscribe({
  //       next: (res) => {
  //         debugger
  //         console.log("Response from server:", res);

  //         // קבלת הטוקן מתוך התגובה
  //         if (res && res.token) {
  //           debugger
  //           sessionStorage.setItem("token", res.token); // שמירת הטוקן ב-session storage
  //           debugger
  //           alert("התחברת בהצלחה!");
  //           this.router.navigate(['/donor']); // ניווט לדף הבית
  //         } else {
  //           alert("שגיאה: לא התקבל טוקן מהשרת.");
  //         }
  //       },
  //       error: (err) => {
  //         console.error("Error during login:", err);

  //         // טיפול במקרה של שגיאה מהשרת
  //         if (err.status === 401) {
  //           alert("אתה לא קיים במערכת, יש לבצע רישום.");
  //           this.router.navigate(['/register']);
  //         } else {
  //           alert("שגיאה: לא ניתן להתחבר כרגע, נסה שוב מאוחר יותר.");
  //         }
  //       }
  //     });
  //   } else {
  //     alert("אנא מלא את כל השדות הדרושים!");
  //   }
  // }
  // logIn() {
  //   debugger;
  //   if (this.login.userName && this.login.password) {
  //     console.log(this.login.userName);

  //     this.loginService.logIn(this.login).subscribe({
  //       next: (res) => {
  //         debugger;
  //         console.log("Response from server:", res);

  //         // קבלת הטוקן מתוך התגובה
  //         if (res && res.token) {
  //           debugger;
  //           sessionStorage.setItem("token", res.token); // שמירת הטוקן ב-session storage
  //           debugger;
  //           this.messageService.add({severity: 'success', summary: 'Successful', detail: 'התחברת בהצלחה! ', life: 3000});
  //           this.router.navigate(['/donor']); // ניווט לדף הבית
  //         } else {
  //           alert("שגיאה: לא התקבל טוקן מהשרת.");
  //         }
  //       },
  //       error: (err) => {
  //         console.error("Error during login:", err);

  //         // טיפול במקרה של שגיאה מהשרת
  //         if (err.status === 401) {
  //           this.messageService.add({ severity: 'error', summary: 'Error', detail: 'אתה לא קיים במערכת, יש לבצע רישום', life: 3000 });
  //           this.router.navigate(['/register']);
  //         } else {
  //           alert("שגיאה: לא ניתן להתחבר כרגע, נסה שוב מאוחר יותר.");
  //         }
  //       }
  //     });
  //   } else {
  //     // הודעה אם אחד השדות ריק
  //     alert("אנא מלא את כל השדות הדרושים!");
  //   }
  // }

  navigateToRegister() {
    this.router.navigate(['/register']);

  }
  //  loginForm!: FormGroup ;

  //   submitted = false;

  //   ngOnInit() {
  //       this.loginForm = new FormGroup({
  //           'login': new FormControl('', Validators.required),
  //           'password': new FormControl('', Validators.required)
  //       });
  //   }

  //   onSubmit() { 
  //       this.submitted = true;
  //       alert(JSON.stringify(this.loginForm.value));
  //   }

}