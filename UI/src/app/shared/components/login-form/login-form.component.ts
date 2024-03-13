import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html'
})
export class LoginComponent {
  user = {
    email: '',
    password: ''
  };
  loading = false;

  constructor(private authService: AuthService, private router: Router) { }

  async onSubmit(e: { preventDefault: () => void; }) {
    e.preventDefault();
    const { email, password } = this.user;
    this.loading = true;
  
    try {
      const result = await this.authService.logIn(email, password);
  
      this.loading = false;
  
      if (result?.isOk) {
        this.router.navigateByUrl('/home');
      } else {
        if (result && 'message' in result) {
          window.alert(result.message || 'Login failed.');
        }
         
      }
    } catch (error) {
      this.loading = false;
      window.alert((error as any).message || 'An error occurred during login. Please try again later.');
    }
  }

  onCreateAccountClick() {
    this.router.navigate(['/create-account']);
  }

}
