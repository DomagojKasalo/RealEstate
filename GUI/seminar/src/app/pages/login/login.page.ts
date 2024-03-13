import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss'],
})
export class LoginPage {
  email: string = "";
  password: string = "";

  constructor(private http: HttpClient, private router: Router) {}

  login() {
    const requestBody = {
      email: this.email,
      password: this.password,
    };

    this.http.post<any>('https://localhost:7059/api/Accounts/Login', requestBody).subscribe(
      (response) => {
        localStorage.setItem('token', response.token);
        this.router.navigate(['/index']);
      },
      (error) => {
        alert('Invalid credentials. Please try again.');
      }
    );
  }
}
