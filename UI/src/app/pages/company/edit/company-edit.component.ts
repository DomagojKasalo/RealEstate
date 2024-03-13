import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { DxFormComponent } from 'devextreme-angular';
import { ToastrService } from 'ngx-toastr';
import { Company } from 'src/app/shared/model/company';
import { CompanyType } from 'src/app/shared/model/companyType';
import { CompanyService } from 'src/app/shared/services/modules/company.service';
import { CompanyAddEditService } from 'src/app/shared/services/modules/companyAddEdit.service';
import { CompanyTypeService } from 'src/app/shared/services/modules/companyType.service';

@Component({
  selector: 'app-company-detail',
  templateUrl: 'company-edit.component.html',
  styleUrls: ['company-edit.component.scss']
})
export class CompanyEditComponent implements OnInit {

  @ViewChild('dxForm', { static: false }) dxForm!: DxFormComponent;

  companyForm!: FormGroup;
  loading = false;
  companyId: number = 0;
  public companyType: CompanyType[] = [];
  public id: number = 0;
  public detailData!: Company;
  serverURL = 'http://localhost:3000';

  constructor(
    private formBuilder: FormBuilder,
    private companyService: CompanyService,
    private toastr: ToastrService,
    private router: Router,
    private route: ActivatedRoute,
    private companyTypeService: CompanyTypeService,
    private companyEditService: CompanyAddEditService
  ) { }

  ngOnInit(): void {
    this.companyId = +this.route.snapshot.params['id'];
    this.companyForm = this.formBuilder.group({
      companyName: ['', Validators.required],
      companyTypeId: ['', Validators.required],
      companyAcronym: ['', Validators.required],
      imagePath: ['', Validators.required],
      email: ['', Validators.required],
      phone: ['', Validators.required],
      webSite: ['', Validators.required],
      shipingAddress: ['', Validators.required],
      imageFile: [null],
      statusId: [0],
      description: [''],
      billingAddress: [''],
      billingCityId: [0],
      shipingCityId: [0],
      billingZip: [''],
      shipingZip: [''],
      leadId: [0],
      registrationDate: [null],
      gid: [''],
      gvat: [''],
      fax: [''],
      billingCityStateId: [0],
      billingCityStateCountryId: [0],
      shippingCityStateId: [0],
      shippingCityStateCountryId: [0],
      companyTypeName: [''],
      id: [0],
      createdDate: [null],
      createdUser: [''],
      modifiedDate: [null],
      modifiedUser: ['']
    });
    this.fetchCompanyType();
    this.fetchCompanyData();
  }

  fetchCompanyData(): void {
    this.companyService.single<Company>(this.companyId).subscribe(
      company => {
        this.detailData = company;
        this.companyForm.patchValue({
          companyName: this.detailData.companyName,
          companyTypeId: this.detailData.companyTypeId,
          companyAcronym: this.detailData.companyAcronym,
          email: this.detailData.email,
          phone: this.detailData.phone,
          webSite: this.detailData.webSite,
          shipingAddress: this.detailData.shipingAddress,
          imagePath: this.detailData.imagePath,
          imageFile: this.detailData.imageFile,
          statusId: this.detailData.statusId,
          description: this.detailData.description,
          billingAddress: this.detailData.billingAddress,
          billingCityId: this.detailData.billingCityId,
          shipingCityId: this.detailData.shipingCityId,
          billingZip: this.detailData.billingZip,
          shipingZip: this.detailData.shipingZip,
          leadId: this.detailData.leadId,
          registrationDate: this.detailData.registrationDate,
          gid: this.detailData.gid,
          gvat: this.detailData.gvat,
          fax: this.detailData.fax,
          billingCityStateId: this.detailData.billingCityStateId,
          billingCityStateCountryId: this.detailData.billingCityStateCountryId,
          shippingCityStateId: this.detailData.shippingCityStateId,
          shippingCityStateCountryId: this.detailData.shippingCityStateCountryId,
          companyTypeName: this.detailData.companyTypeName,
          id: this.detailData.id,
          createdDate: this.detailData.createdDate,
          createdUser: this.detailData.createdUser,
          modifiedDate: this.detailData.modifiedDate,
          modifiedUser: this.detailData.modifiedUser
        });
        this.loading = false;
        console.log("com", company);
      },
      error => {
        this.loading = false;
        this.toastr.error('Failed to fetch company data');
      }
    );
  }

  onFileChange(event: Event): void {
    const inputElement = event.target as HTMLInputElement;

    if (inputElement.files && inputElement.files.length > 0) {
      const file = inputElement.files[0];
      this.companyForm.controls['imageFile'].setValue(file);
    }
  }

  updateCompany(company: Company): void {
    const formData: FormData = new FormData();

    Object.keys(company).forEach(key => {
      if (company.hasOwnProperty(key)) {
        let value = company[key as keyof Company];

        if (value !== null && value !== undefined) {
          if (typeof value === 'boolean' || typeof value === 'number') {
            // Convert number and boolean values to string
            value = value.toString();
          } else if (value instanceof Date) {
            // Convert date to ISO string
            value = value.toISOString();
          } else if (value instanceof File) {
            // If value is a file, no conversion is needed
          } else if (typeof value === 'object') {
            // Stringify other object types
            value = JSON.stringify(value);
          }

          formData.append(key, value);
        }
      }
    });

    this.companyEditService.update<Company>(this.companyId, formData).subscribe(
      () => {
        this.toastr.success('Company updated successfully');
        this.router.navigateByUrl('/companies');
      }
    );
  }

  fetchCompanyType(): void {
    this.companyTypeService.list<CompanyType[]>().subscribe(
      companyTypes => {
        this.companyType = companyTypes;
        this.loading = false;
      },
      error => {
        this.loading = false;
        this.toastr.error('Failed to fetch company types');
      }
    );
  }

  onCompanyTypeSelect(id: number) {
    this.detailData.companyTypeId = id;
  }

  deleteCompany = (e: any) => {
    this.companyService.delete<Company>(this.companyId).subscribe(
      () => {
        this.toastr.success('Company deleted successfully');
        this.router.navigateByUrl('/companies');
      },
      (error) => {
        this.toastr.error('Failed to delete company');
      }
    );
  }
}
