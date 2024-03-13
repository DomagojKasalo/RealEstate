import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { RealEstateCatalog } from 'src/app/shared/model/realEstateCatalog';
import { RealEstateCatalogItem } from 'src/app/shared/model/realEstateCatalogItem';
import { RealEstateCatalogItemsService } from 'src/app/shared/services/modules/realEstateCatalogItems.service';
import { RealEstateCatalogsService } from 'src/app/shared/services/modules/realEstateCatalogs.service';
import { HttpParams } from '@angular/common/http';
import { DxDataGridComponent } from 'devextreme-angular';
import { GridService } from 'src/app/shared/services/modules/grid.service';
import { GridColumn } from 'src/app/shared/model/grid.model';
import { RealEstateCatalogItemTypesService } from 'src/app/shared/services/modules/realEstateCatalogItemTypes.service';
import { RealEstateCatalogItemType } from 'src/app/shared/model/catalogItemType';
import DataSource from "devextreme/data/data_source";
import { HttpGetListOptions } from 'src/app/shared/services/generic-rest/generic-rest.types';


@Component({
  templateUrl: 'realEstateCatalogItems-list.component.html',
  styleUrls: ['realEstateCatalogItems-list.component.scss']
})
export class RealEstateCatalogItemsListComponent implements OnInit {
  public catalogItems: RealEstateCatalogItem[] = [];
  public catalogs: RealEstateCatalog[] = [];
  public catalogType: RealEstateCatalogItemType[] = [];
  changedOptions: { name: string, value: any }[] = [];
  params!: HttpParams;
  dataSource!: DataSource;
  filterCatalogList!: GridColumn[];
  sortList!: GridColumn[];

  @ViewChild(DxDataGridComponent, { static: false }) dataGrid: DxDataGridComponent | undefined;

  constructor(
    private gridService: GridService,
    private catalogItemService: RealEstateCatalogItemsService,
    private catalogItemTypeService: RealEstateCatalogItemTypesService,
    private router: Router,
    private catalogService: RealEstateCatalogsService,
  ) {
  }

  ngOnInit(): void {
    const storedFilterOptions = sessionStorage.getItem('filterOptions1');
    if (storedFilterOptions) {
      this.changedOptions = JSON.parse(storedFilterOptions);
    }

    this.filterCatalogList = [
      { index: 1, name: 'catalogName' },
      { index: 2, name: 'catalogtype' },
    ];
    this.sortList = [
      { index: 0, name: 'name' },
      { index: 1, name: 'catalogname' },
    ];

    this.loadData();
  }

  handleOptionChanged(e: { name: string; value?: any; fullName: string; component: any }): void {
    if (e.name !== 'dataSource') {
      const existingChange = this.changedOptions.find((ch) => ch.name === e.fullName);
      if (existingChange) {
        existingChange.value = e.value;
      } else {
        this.changedOptions.push({ name: e.fullName, value: e.value });
      }

      this.loadData();
    }
  }

  ngOnDestroy() {
    sessionStorage.setItem('filterOptions1', JSON.stringify(this.changedOptions));
  }

  loadData() {
    this.dataSource = new DataSource({
      load: async (loadOptions) => {
        this.params = this.gridService.createSearchParams(this.changedOptions, loadOptions, this.filterCatalogList, this.sortList);
        const testOptions: HttpGetListOptions<RealEstateCatalogItem> = {
          urlPostfix: 'filtered',
          params: this.params,
        }
        return new Promise((resolve, reject) => {
          this.catalogItemService.listPagination(testOptions).subscribe(
            response => {
              this.fetchCatalogs();
              this.fetchCatalogTypes();
              console.log("res", response)
              resolve({
                data: response.items,
                totalCount: response.totalCount
              });
            },
            error => {
              reject({
                data: [],
                totalCount: 0
              });
            }
          );
        });
      }
    });
    
  }

  fetchCatalogs(): void {
    this.catalogService.list<RealEstateCatalog[]>().subscribe(
      catalogs => {
        this.catalogs = catalogs;
        this.updateHeaderFilterOptions("catalogName", this.catalogs);
      },
    );
  }

  fetchCatalogTypes(): void {
    this.catalogItemTypeService.list<RealEstateCatalogItemType[]>().subscribe(
      (catalogType: RealEstateCatalogItemType[]) => {
        this.catalogType = catalogType;
        this.updateHeaderFilterOptions("catalogItemTypeName", this.catalogType);
      }
    );
  }

  fetchCatalogItems(): void {
    this.catalogItemService.list<RealEstateCatalogItem[]>().subscribe(
      catalogItems => {
        this.catalogItems = catalogItems;
      }
    );
  }

  updateHeaderFilterOptions(columnName: string, catalog: any): void {
    if (this.dataGrid) {
      const catalogNameColumn = this.dataGrid.instance.columnOption(columnName);

      if (catalogNameColumn) {
        catalogNameColumn.headerFilter.dataSource = catalog.map((item: any) => ({
          text: item.name,
          value: item.name
        }));
      }
    }
  }

  clearFilters() {
    this.changedOptions = [];
    this.clearStoredFilters();
    this.loadData();
  }

  clearStoredFilters() {
    sessionStorage.removeItem('filterOptions');
  }

  onRowClick(rowData: RealEstateCatalogItem): void {
    this.router.navigateByUrl(`/catalogItems/edit/${rowData.id}`);
  }

  onAddClick(): void {
    this.router.navigateByUrl('/catalogItems/add');
  }
}