import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
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

@Component({
  selector: 'app-catalog-item-detail',
  templateUrl: 'realEstateCatalogItem-details.component.html',
  styleUrls: ['realEstateCatalogItem-edit.component.scss']
})
export class RealEstateCatalogItemEditComponent implements OnInit {

  catalogItemForm!: FormGroup;
  loading = true;
  catalogItemId: number = 0;
  public detailData!: RealEstateCatalogItem;
  serverURL = 'http://localhost:3000';
  catalogItemType: RealEstateCatalogItemType[] = [];
  catalogItemStatus: RealEstateCatalogItemStatus[] = [];
  catalog: RealEstateCatalog[] = [];

  constructor(
    private formBuilder: FormBuilder,
    private catalogItemService: RealEstateCatalogItemsService,
    private editCatalogItem: RealEstateCatalogItemAddService,
    private toastr: ToastrService,
    private router: Router,
    private route: ActivatedRoute,
    private catalogService: RealEstateCatalogsService,
    private catalogItemStatusService: RealEstateCatalogItemStatusesService,
    private catalogItemTypesService: RealEstateCatalogItemTypesService,
  ) { }

  ngOnInit(): void {
    this.catalogItemId = +this.route.snapshot.params['id'];
    this.catalogItemForm = this.formBuilder.group({
      id: [this.catalogItemId],
      name: ['', Validators.required],
      catalogId: ['', Validators.required],
      companyId: ['', Validators.required],
      companyName: [''],
      description: ['', Validators.required],
      imagePath: ['', Validators.required],
      catalogName: [''],
      versionIdentifier: [''],
      quote: [''],
      isEnabled: [false],
      floors: ['', Validators.required],
      rooms: ['', Validators.required],
      bathrooms: ['', Validators.required],
      garagePlaces: ['', Validators.required],
      lamella: [''],
      floor: [''],
      units: [''],
      dimensions: [''],
      netArea: [''],
      bruttoArea: [''],
      isFeatured: [false],
      catalogItemTypeId: [''],
      catalogItemStatusId: [''],
      disclaimer: [''],
      isDisclamer: [false],
      approvedUser: [''],
      deploymentStatusId: [''],
      imageFile: [null],
    });

    this.fetchCatalogItem();
    this.fetchCatalogItemTypes();
    this.fetchCatalogItemStatuses();
    this.fetchCatalogs();

    this.catalogItemForm.addControl('imageFiles', this.formBuilder.control(null));

  }

  fetchCatalogItem(): void {
    this.catalogItemService.single<RealEstateCatalogItem>(this.catalogItemId).subscribe(
      catalogItem => {
        this.detailData = catalogItem;
        this.loading = false;

        this.catalogItemForm.patchValue({
          name: this.detailData.name,
          description: this.detailData.description,
          catalogId: this.detailData.catalogId,
          companyId: this.detailData.companyId,
          companyName: this.detailData.companyName,
          catalogName: this.detailData.catalogName,
          catalogItemTypeId: this.detailData.catalogItemTypeId,
          catalogItemStatusId: this.detailData.catalogItemStatusId,
          floors: this.detailData.floors,
          rooms: this.detailData.rooms,
          bathrooms: this.detailData.bathrooms,
          garagePlaces: this.detailData.garagePlaces,
          netArea: this.detailData.netArea,
          bruttoArea: this.detailData.bruttoArea,
          isEnabled: this.detailData.isEnabled,
          lamella: this.detailData.lamella,
          floor: this.detailData.floor,
          units: this.detailData.units,
          createdDate: this.detailData.createdDate,
          createdUser: this.detailData.createdUser,
          modifiedDate: this.detailData.modifiedDate,
          modifiedUser: this.detailData.modifiedUser,
          versionIdentifier: this.detailData.versionIdentifier,
          dimensions: this.detailData.dimensions,
          isFeatured: this.detailData.isFeatured,
          disclaimer: this.detailData.disclaimer,
          isDisclamer: this.detailData.isDisclamer,
          approvedUser: this.detailData.approvedUser,
          deploymentStatusId: this.detailData.deploymentStatusId,
          quote: this.detailData.quote
        });
      },
      error => {
        this.loading = false;
        this.toastr.error('Failed to fetch Catalog Item');
      }
    );
  }

  updateCatalogItem(catalogItem: RealEstateCatalogItem): void {
    const formData: FormData = new FormData();

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

    this.editCatalogItem.update<RealEstateCatalogItem>(this.catalogItemId, formData).subscribe(
      () => {
        this.toastr.success('Catalog Item updated successfully');
        this.router.navigateByUrl('/catalogItems');
      }
    );
  }

  uploadMultipleImages(): void {
    this.router.navigateByUrl(`/catalogItems/upload/${this.catalogItemId}`);
}

  deleteCatalogItem = (e: any) => {
    this.catalogItemService.delete<RealEstateCatalogItem>(this.catalogItemId).subscribe(
      () => {
        this.toastr.success('Catalog Item deleted successfully');
        this.router.navigateByUrl('/catalogItems');
      },
      (error) => {
        this.toastr.error('Failed to delete Catalog Item');
      }
    );
  }

  fetchCatalogItemTypes(): void {
    this.catalogItemTypesService.list<RealEstateCatalogItemType[]>().subscribe(
      (catalogItemTypes) => {
        this.catalogItemType = catalogItemTypes;
        console.log("type", catalogItemTypes);
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
    this.catalogService.list<RealEstateCatalog[]>().subscribe(
      (catalog) => {
        this.catalog = catalog;
      },
      (error) => {
        this.toastr.error('Failed to fetch catalogs');
      }
    );
  }
}
