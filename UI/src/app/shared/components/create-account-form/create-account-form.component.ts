import { Component } from '@angular/core';
import { AuthService } from '../../services';
import notify from 'devextreme/ui/notify';
import { Router } from '@angular/router';
import { User } from '../../model/user';
import { Role } from '../../model/role';
import { RoleService } from '../../services/modules/role.service';
import { CompanyLightService } from '../../services/modules/companyLight.service';
import { CompanyLight } from '../../model/companyLight';

@Component({
  selector: 'app-create-account-form',
  templateUrl: './create-account-form.component.html',
  styleUrls: ['./create-account-form.component.scss']
})
export class CreateAccountFormComponent {
  loading = false;
  formData: User = new User();
  roles: Role[] = [];
  company: CompanyLight[] = [];

  constructor(
    private authService: AuthService,
    private router: Router,
    private roleService: RoleService,
    private companyService: CompanyLightService
  ) { }

  ngOnInit(): void {
    this.fetchRoles()
    this.fetchCompanies()
  }

  async onSubmit(e: Event) {
    e.preventDefault();
    this.loading = true;
  
    let roles = this.formData.roles;
    if (!Array.isArray(roles)) {
      roles = [roles];
    }
    const submissionData = {
      ...this.formData,
      roles,
    };
  
    const result = await this.authService.createUser(submissionData);
  
    this.loading = false;
  
    if (result.isOk) {
      this.router.navigate(['/home']);
    } else {
      notify(result.message, 'error', 2000);
    }
  }
  

  confirmPassword = (e: any) => {
    return e.value === this.formData.password;
  }

  fetchRoles(): void {
    this.roleService.list<Role[]>().subscribe(
      (roles) => {
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