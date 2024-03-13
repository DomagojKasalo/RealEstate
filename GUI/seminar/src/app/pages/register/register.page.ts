import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.page.html',
  styleUrls: ['./register.page.scss'],
})
export class RegisterPage {
  email: string = "";
  userName: string = "";
  password: string = "";
  inviteCode: string = "";

  constructor(private http: HttpClient, private router: Router) {}

  registerUser() {
    const requestBody = {
      userName: this.userName,
      email: this.email,
      password: this.password,
      inviteCode: this.inviteCode,
    };

    this.http.post<any>('https://localhost:7059/api/Accounts/registerUser', requestBody).subscribe(
      (response) => {
        alert('Registration successful! Please login to continue.');
        this.router.navigate(['/login']);
      },
      (error) => {
        alert('Registration failed. Please try again.');
      }
    );
  }
}
