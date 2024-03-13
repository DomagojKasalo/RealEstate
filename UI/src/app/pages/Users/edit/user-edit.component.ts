import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CompanyLight } from 'src/app/shared/model/companyLight';
import { Role } from 'src/app/shared/model/role';
import { User } from 'src/app/shared/model/user';
import { CompanyLightService } from 'src/app/shared/services/modules/companyLight.service';
import { RoleService } from 'src/app/shared/services/modules/role.service';
import { UserService } from 'src/app/shared/services/modules/user.service';
import { UserRoleService } from 'src/app/shared/services/modules/userRole.service';
import { forkJoin } from 'rxjs';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-edit.component.scss']
})
export class UserDetailComponent implements OnInit {

  userForm!: FormGroup;
  loading = false;
  userId: string = "";
  roles: Role[] = [];
  company: CompanyLight[] = [];
  catalogId: number = 0;
  initialRole: string = '';

  constructor(
    private formBuilder: FormBuilder,
    private userService: UserService,
    private router: Router,
    private route: ActivatedRoute,
    private roleService: RoleService,
    private companyService: CompanyLightService,
    private userRoleService: UserRoleService
  ) { }

  ngOnInit(): void {
    this.userId = this.route.snapshot.params['id'].toString();
    this.userForm = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      address: ['', Validators.required],
      roles: ['', Validators.required],
      companyId: ['', Validators.required],
    });

    this.loadRoles();
    this.loadUserDetails();
    this.fetchCompanies();
  }


  loadUserDetails(): void {
    this.userService.single<User>(this.userId).subscribe(
      user => {
        this.userForm.patchValue(user);
        this.loadUserRoleForUser(this.userId);
      }
    );
  }

  loadUserRoleForUser(userId: string): void {
    this.userRoleService.getUserRole(userId).subscribe(
        (role) => {
            this.initialRole = role.role;
        },
        (error) => {
            console.error(error);
        }
    );
 }

  updateUser(userId: string, user: User): void {

    if (typeof user.roles === 'string') {
      user.roles = [user.roles as any];
    }

    user.id = userId;
    user.roles = [this.initialRole];

    this.userService.update<User>(userId, user).subscribe(
      () => {
        this.router.navigateByUrl('/user');
      }
    );
  }


  loadRoles(): void {
    this.roleService.list<Role[]>().subscribe(roles => {
      this.roles = roles;
  });
  }

  deleteUser(): void {
    this.userService.delete<User>(this.userId).subscribe(
      () => {
        this.router.navigateByUrl('/user');
      }
    );
  }

  fetchCompanies(): void {
    this.companyService.list<CompanyLight[]>().subscribe(
      (company) => {
        this.company = company;
      }
    );
  }
}
