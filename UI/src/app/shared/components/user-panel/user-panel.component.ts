import { Component, NgModule, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DxListModule } from 'devextreme-angular/ui/list';
import { DxContextMenuModule } from 'devextreme-angular/ui/context-menu';
import { User } from '../../model/user';
import { UserService } from '../../services/modules/user.service';
import { AuthService } from '../../services';

@Component({
  selector: 'app-user-panel',
  templateUrl: 'user-panel.component.html',
  styleUrls: ['./user-panel.component.scss']
})
export class UserPanelComponent {
  @Input() menuItems: any;
  @Input() menuMode!: string;
  @Input()
  user: User | null = null;
  userId: string = "";

  constructor(
    private userService: UserService,
    private authService: AuthService
  ) { }

  ngOnInit(): void {
    this.userId = this.authService.getUserId() || '';

    // console.log("userId", this.userId)

    this.loadUserDetails();
  }

  loadUserDetails(): void {
    // if (!this.userId) {
    //   throw new Error("No userId available");
    // }
    this.userService.single<User>(this.userId).subscribe(
      user => this.user = user
    );
  }
}

@NgModule({
  imports: [
    DxListModule,
    DxContextMenuModule,
    CommonModule
  ],
  declarations: [ UserPanelComponent ],
  exports: [ UserPanelComponent ]
})
export class UserPanelModule { }
