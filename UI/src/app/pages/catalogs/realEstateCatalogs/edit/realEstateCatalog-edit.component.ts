import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { RealEstateCatalogType } from 'src/app/shared/model/catalogType';
import { CompanyLight } from 'src/app/shared/model/companyLight';
import { RealEstateCatalog } from 'src/app/shared/model/realEstateCatalog';
import { CompanyLightService } from 'src/app/shared/services/modules/companyLight.service';
import { RealEstateCatalogTypesService } from 'src/app/shared/services/modules/realEstateCatalogTypes.service';
import { RealEstateCatalogsService } from 'src/app/shared/services/modules/realEstateCatalogs.service';


@Component({
  selector: 'app-catalog-detail',
  templateUrl: 'realEstateCatalog-details.component.html',
  styleUrls: ['realEstateCatalog-edit.component.scss']
})
export class RealEstateCatalogEditComponent implements OnInit {

  catalogForm!: FormGroup;
  catalogType: RealEstateCatalogType[] = [];
  company: CompanyLight[] = [];
  catalogId: number = 0;
  public detailData!: RealEstateCatalog;

  constructor(
    private formBuilder: FormBuilder,
    private catalogService: RealEstateCatalogsService,
    private toastr: ToastrService,
    private router: Router,
    private route: ActivatedRoute,
    private companyService: CompanyLightService,
    private catalogTypesService: RealEstateCatalogTypesService
  ) {}

  ngOnInit(): void {
    this.catalogId = +this.route.snapshot.params['id'];
    this.catalogForm = this.formBuilder.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
      companyId: ['', Validators.required],
      catalogTypeId: ['', Validators.required],
    });

    this.fetchCatalog();
    this.fetchCatalogType();
    this.fetchCompanies();
    this.fetchCatalogData();
  }

  updateCatalog(catalog: RealEstateCatalog, catalogId: number): void {
    if (this.catalogForm.invalid) {
      return;
    }

    catalog.id = catalogId;
  
    this.catalogService.update<RealEstateCatalog>(catalogId, catalog).subscribe(
      () => {
        this.toastr.success('Catalog updated successfully');
        this.router.navigateByUrl('/catalogs');
      },
      error => {
        this.toastr.error('Failed to update Catalog');
      }
    );
  }
  

  fetchCatalog(): void {
    this.catalogService.list<RealEstateCatalog>().subscribe(
      catalog => {
        this.detailData = catalog;
      },
      error => {
        this.toastr.error('Failed to fetch Catalog');
      }
    );
  }

  fetchCatalogType(): void {
    this.catalogTypesService.list<RealEstateCatalogType[]>().subscribe(
      (catalogTypes) => {
        this.catalogType = catalogTypes;
      },
      (error) => {
        this.toastr.error('Failed to fetch catalog types');
      }
    );
  }

  fetchCompanies(): void {
    this.companyService.list<CompanyLight[]>().subscribe(
      (company) => {
        this.company = company;
      },
      (error) => {
        this.toastr.error('Failed to fetch companies');
      }
    );
  }

  fetchCatalogData(): void {
    this.catalogService.single<RealEstateCatalog>(this.catalogId).subscribe(
      catalog => {
        this.detailData = catalog;
        this.catalogForm.patchValue({
          name: this.detailData.name,
          catalogTypeId: this.detailData.catalogTypeId,
          companyId: this.detailData.companyId,
          description: this.detailData.description
        });
      },
      error => {
        this.toastr.error('Failed to fetch catalog data');
      }
    );
  }

  deleteCatalog = (e: any) => {
    this.catalogService.delete<RealEstateCatalog>(this.catalogId).subscribe(
      () => {
        this.toastr.success('Catalog deleted successfully');
        this.router.navigateByUrl('/catalogs');
      },
      (error) => {
        this.toastr.error('Failed to delete Catalog');
      }
    );
  }
}
