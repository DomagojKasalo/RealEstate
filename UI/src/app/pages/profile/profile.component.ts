import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CompanyLight } from 'src/app/shared/model/companyLight';
import { Role } from 'src/app/shared/model/role';
import { User } from 'src/app/shared/model/user';
import { AuthService } from 'src/app/shared/services';
import { CompanyLightService } from 'src/app/shared/services/modules/companyLight.service';
import { RoleService } from 'src/app/shared/services/modules/role.service';
import { UserService } from 'src/app/shared/services/modules/user.service';
import { UserRoleService } from 'src/app/shared/services/modules/userRole.service';

@Component({
  templateUrl: 'profile.component.html',
  styleUrls: ['./profile.component.scss']
})

export class ProfileComponent {
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
    private authService: AuthService,
    private router: Router,
    private roleService: RoleService,
    private companyService: CompanyLightService,
    private userRoleService: UserRoleService
  ) { }

  ngOnInit(): void {
    this.userId = this.authService.getUserId() || '';

    this.userForm = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      address: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      roles: ['', Validators.required],
      companyId: ['', Validators.required],
    });

    this.loadUserDetails();
    this.loadRoles();
    this.fetchCompanies();
  }


  loadUserDetails(): void {
    if (!this.userId) {
      throw new Error("No userId available");
    }
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

  updateUser(user: User): void {
    user.id = this.userId;
    user.roles = [this.initialRole];
    this.userService.update<User>(this.userId, user).subscribe(
      () => {
        this.router.navigateByUrl('/home');
      }
    );
  }

  loadRoles(): void {
    this.roleService.list<Role[]>().subscribe(
      roles => {
        this.roles = roles;
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
