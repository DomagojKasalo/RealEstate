import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CompanyLight } from 'src/app/models/CompanyLight';
import { User } from 'src/app/models/User';
import { Role } from 'src/app/models/role';
import { AuthService } from 'src/app/services/auth.service';
import { UserService } from 'src/app/services/user.service';
import { UserRoleService } from 'src/app/services/userRole.service';

@Component({
  selector: 'app-index',
  templateUrl: './index.page.html',
  styleUrls: ['./index.page.scss'],
})
export class IndexPage implements OnInit {

  userId: string | null = "";
  user!: User;
  userForm!: FormGroup;
  roles: Role[] = []; 
  initialRole: string = '';
  company: CompanyLight[] = [];
  companyId = 0;
  public welcomeMessage: string = `Welcome to our Real Estate App! Discover properties tailored just for you.`;

  // Adding showProfile variable
  showProfile: boolean = false;

  constructor(
    private authService: AuthService,
    private userService: UserService,
    private router: Router,
    private formBuilder: FormBuilder,
    private userRoleService: UserRoleService,
    // private companyService: CompanyLightService,
  ) { }

  ngOnInit(): void {
    this.userId = this.authService.getUserId();
    this.loadUserDetails();
    this.initForm(); 
  }

  initForm() {
    this.userForm = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      address: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      roles: ['', Validators.required],
    });
  }

  loadUserDetails() {
    if (this.userId) {
      this.userService.single<User>(this.userId).subscribe(user => {
        this.user = user;
        this.companyId = user.companyId;
        this.updateWelcomeMessage();
        this.userForm.patchValue(user);
        if (this.userId) {
          this.loadUserRoleForUser(this.userId);
        } else {
          console.error('UserId is null.');
        }
      });
    }
  }

  loadUserRoleForUser(userId: string): void {
    this.userRoleService.getUserRole(userId).subscribe(
        (role) => {
            this.initialRole = role.role;
            console.log('Initial Role:', this.initialRole);
        },
        (error) => {
            console.error(error);
        }
    );
 }

  updateWelcomeMessage() {
    this.welcomeMessage = `Welcome to our Real Estate App, ${this.user.firstName}! Discover properties tailored just for you.`;
  }

  updateUser(user: User): void {
    if (this.userId) {
        user.id = this.userId;  
        user.roles = [this.initialRole];
        user.companyId = this.companyId;
    
        this.userService.update<User>(this.userId, user).subscribe(
            () => {
                this.router.navigateByUrl('/catalogs');
            }
        );
    } else {
        console.error("UserId is null, cannot update user.");
    }
}

  Catalogs() {
    this.router.navigate(['/catalogs']);
  }

  AllCatalogs() {
    this.router.navigate(['/all-catalogs']);
  }
}
