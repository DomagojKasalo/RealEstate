import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { RealEstateCatalogItemStatus } from 'src/app/shared/model/catalogItemStatus';
import { RealEstateCatalogItemType } from 'src/app/shared/model/catalogItemType';
import { RealEstateCatalog } from 'src/app/shared/model/realEstateCatalog';
import { RealEstateCatalogItem } from 'src/app/shared/model/realEstateCatalogItem';
import { RealEstateCatalogItemAddService } from 'src/app/shared/services/modules/realEstateCatalogItemAdd.service';
import { RealEstateCatalogItemStatusesService } from 'src/app/shared/services/modules/realEstateCatalogItemStatuses.service';
import { RealEstateCatalogItemTypesService } from 'src/app/shared/services/modules/realEstateCatalogItemTypes.service';
import { RealEstateCatalogItemsService } from 'src/app/shared/services/modules/realEstateCatalogItems.service';
import { RealEstateCatalogsService } from 'src/app/shared/services/modules/realEstateCatalogs.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-real-estate-catalog-item-add',
  templateUrl: 'realEstateCatalogItem-add.component.html',
  styleUrls: ['realEstateCatalogItem-add.component.scss']
})
export class RealEstateCatalogItemAddComponent implements OnInit {
  catalogItemForm!: FormGroup;
  loading = false;
  catalogItemType: RealEstateCatalogItemType[] = [];
  catalogItemStatus: RealEstateCatalogItemStatus[] = [];
  catalog: RealEstateCatalog[] = [];
  // formData: any = {};

  constructor(
    private formBuilder: FormBuilder,
    private addNewService: RealEstateCatalogItemAddService,
    private catalogItemTypesService: RealEstateCatalogItemTypesService,
    private toastr: ToastrService,
    private ccatalogService: RealEstateCatalogsService,
    private catalogItemStatusService: RealEstateCatalogItemStatusesService,
    private router: Router,
  ) { }

  ngOnInit(): void {
    this.catalogItemForm = this.formBuilder.group({
      name: ['', Validators.required],
      catalogId: ['', Validators.required],
      description: [''],
      // isEnabled: ['', Validators.required],
      catalogItemTypeId: ['', Validators.required],
      catalogItemStatusId: ['', Validators.required],
      floors: ['', Validators.required],
      rooms: ['', Validators.required],
      bathrooms: ['', Validators.required],
      garagePlaces: ['', Validators.required],
      netArea: ['', Validators.required],
      // imagePath: [null],
      imageFile: [null]
    });

    this.fetchCatalogItemTypes();
    this.fetchCatalogItemStatuses();
    this.fetchCatalogs();
  }

  createCatalogItem(catalogItem: RealEstateCatalogItem): void {
    const formData = new FormData();

    console.log('Catalog:', catalogItem);

    Object.keys(catalogItem).forEach(key => {
      if (catalogItem.hasOwnProperty(key)) {
        let value = catalogItem[key as keyof RealEstateCatalogItem];

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
    
    this.addNewService.add<RealEstateCatalogItem>(formData).subscribe(
      (createdCatalogItem) => {
        this.toastr.success('Catalog item created successfully');
        this.router.navigateByUrl('/catalogItems');
      });
  }

  fetchCatalogItemTypes(): void {
    this.catalogItemTypesService.list<RealEstateCatalogItemType[]>().subscribe(
      (catalogItemTypes) => {
        this.catalogItemType = catalogItemTypes;
      },
      (error) => {
        this.toastr.error('Failed to fetch catalog item types');
      }
    );
  }

  fetchCatalogItemStatuses(): void {
    this.catalogItemStatusService.list<RealEstateCatalogItemStatus[]>().subscribe(
      (catalogItemStatus) => {
        this.catalogItemStatus = catalogItemStatus;
      },
      (error) => {
        this.toastr.error('Failed to fetch catalog item statuses');
      }
    );
  }

  fetchCatalogs(): void {
    this.ccatalogService.list<RealEstateCatalog[]>().subscribe(
      (catalog) => {
        this.catalog = catalog;
      },
      (error) => {
        this.toastr.error('Failed to fetch catalogs');
      }
    );
  }
}
