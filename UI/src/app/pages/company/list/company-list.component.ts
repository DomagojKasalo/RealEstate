import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Company } from 'src/app/shared/model/company';
import { CompanyService } from 'src/app/shared/services/modules/company.service';

@Component({
  selector: 'app-company',
  templateUrl: 'company-list.component.html',
  styleUrls: ['company-list.component.scss']
})
export class CompanyListComponent implements OnInit {
  public companies: Company[] = [];
  public loading = false;

  constructor(
    private companyService: CompanyService,
    private router: Router,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.fetchCompanies();
  }

  fetchCompanies(): void {
    this.loading = true;
    this.companyService.list<Company[]>().subscribe(
      companies => {
        this.companies = companies;
        this.loading = false;
      },
      error => {
        this.loading = false;
        this.toastr.error('Error loading data');
      }
    );
  }

  onRowClick(rowData: Company): void {
    this.router.navigateByUrl(`/companies/edit/${rowData.id}`);
  }

  onAddClick(): void {
    this.router.navigateByUrl('/companies/add');
  }
}
