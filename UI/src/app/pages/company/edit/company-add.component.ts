import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Company } from 'src/app/shared/model/company';
import { CompanyService } from 'src/app/shared/services/modules/company.service';
import { CompanyType } from 'src/app/shared/model/companyType';
import { CompanyTypeService } from 'src/app/shared/services/modules/companyType.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-company-add',
  templateUrl: 'company-add.component.html',
  styleUrls: ['./company-add.component.scss']
})
export class CompanyAddComponent implements OnInit {
  companyForm!: FormGroup;
  loading = false;
  companyType: CompanyType[] = [];

  constructor(
    private formBuilder: FormBuilder,
    private companyService: CompanyService,
    private companyTypeService: CompanyTypeService,
    private toastr: ToastrService,
    private router: Router,
  ) {}

  ngOnInit(): void {
    this.companyForm = this.formBuilder.group({
      companyName: ['', Validators.required],
      companyTypeId: ['', Validators.required],
      companyAcronym: ['', Validators.required],
      email: ['', Validators.required],
      phone: ['', Validators.required],
      webSite: ['', Validators.required],
      shipingAddress: ['', Validators.required],
    });

    this.fetchCompanyType();
  }

  createCompany(company:Company): void {

    console.log('Company:', company);

    this.companyService.add<Company>(company).subscribe(
      () => {
        this.toastr.success('Company created successfully');
        this.router.navigateByUrl('/companies');
      },
      (error) => {
        this.toastr.error('Failed to create company');
      }
    );
  }

  fetchCompanyType(): void {
    this.companyTypeService.list<CompanyType[]>().subscribe(
      (companyTypes) => {
        this.companyType = companyTypes;
      },
      (error) => {
        this.toastr.error('Failed to fetch company types');
      }
    );
  }

}
