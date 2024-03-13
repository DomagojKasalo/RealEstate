import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/shared/model/user';
import { UserService } from 'src/app/shared/services/modules/user.service';

@Component({
  selector: 'app-user',
  templateUrl: 'user-list.component.html',
  styleUrls: ['user-list.component.scss']
})
export class UserListComponent implements OnInit {
  public user: User[] = [];
  public loading = false;

  constructor(
    private userService: UserService,
    private router: Router,
  ) { }

  ngOnInit(): void {
    this.fetchActivity();
  }

  fetchActivity(): void {
    this.loading = true;
    this.userService.list<User[]>().subscribe(
      user => {
        this.user = user;
        this.loading = false;
      },
      error => {
        this.loading = false;
        alert("Error loading data")
      }
    );
  }

  onRowClick(rowData: User): void {
    this.router.navigateByUrl(`/user/edit/${rowData.id}`);
  }

  onAddClick(): void {
    this.router.navigateByUrl('/createAcc');
  }
}
