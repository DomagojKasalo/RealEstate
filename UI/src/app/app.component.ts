import { Component, HostBinding, OnInit } from '@angular/core';
import { AuthService, ScreenService, AppInfoService } from './shared/services';
import { clientNavigation } from './client-navigation';
import { navigation } from './app-navigation';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit  {
  navigation: any[] = [];
  @HostBinding('class') get getClass() {
    return Object.keys(this.screen.sizes).filter(cl => this.screen.sizes[cl]).join(' ');
  }

  constructor(private authService: AuthService, private screen: ScreenService, public appInfo: AppInfoService) { }

  ngOnInit(): void {
    const userRole = this.authService.getUserRole();
    console.log("role", userRole);

    if (userRole === 'Admin') {
      this.navigation = navigation;
    } else if (userRole === 'Client') {
      this.navigation = clientNavigation;
    } else {
     
      this.navigation = [
        {
          text: 'Home',
          path: '/home',
          icon: 'home'
        },
      ]; 
    }
  }

  isAuthenticated() {
    return this.authService.loggedIn;
  }
}
