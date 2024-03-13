import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { RealEstateCatalogType } from 'src/app/shared/model/catalogType';
import { CompanyLight } from 'src/app/shared/model/companyLight';
import { RealEstateCatalog } from 'src/app/shared/model/realEstateCatalog';
import { CompanyLightService } from 'src/app/shared/services/modules/companyLight.service';
import { RealEstateCatalogTypesService } from 'src/app/shared/services/modules/realEstateCatalogTypes.service';
import { RealEstateCatalogsService } from 'src/app/shared/services/modules/realEstateCatalogs.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-real-estate-catalog-add',
  templateUrl: 'realEstateCatalog-add.component.html',
  styleUrls: ['realEstateCatalog-add.component.scss']
})
export class RealEstateCatalogAddComponent implements OnInit {
  catalogForm!: FormGroup;
  catalogType: RealEstateCatalogType[] = [];
  company: CompanyLight[] = [];

  constructor(
    private formBuilder: FormBuilder,
    private catalogsService: RealEstateCatalogsService,
    private catalogTypesService: RealEstateCatalogTypesService,
    private toastr: ToastrService,
    private companyService: CompanyLightService,
    private router: Router,
  ) {}

  ngOnInit(): void {
    this.catalogForm = this.formBuilder.group({
      name: ['', Validators.required],
      companyId: ['', Validators.required],
      description: ['', Validators.nullValidator],
      // isEnabled: ['', Validators.nullValidator],
      catalogTypeId: ['', Validators.required],
    });

    this.fetchCatalogType();
    this.fetchCompanies();
  }

  createCatalog(catalog:RealEstateCatalog): void {
    console.log('Catalog:', catalog);
    
    this.catalogsService.add<RealEstateCatalog>(catalog).subscribe(
      () => {
        this.toastr.success('Catalog created successfully');
        this.router.navigateByUrl('/catalogs');
      },
      (error) => {
        this.toastr.error('Failed to create catalog');
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
}
