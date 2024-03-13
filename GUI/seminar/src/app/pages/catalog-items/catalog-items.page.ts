import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Catalog } from 'src/app/models/Catalog';
import { CatalogItem } from 'src/app/models/CatalogItem';
import { CatalogItemType } from 'src/app/models/catalogItemType';
import { CatalogService } from 'src/app/services/catalog.service';
import { CatalogItemTypesService } from 'src/app/services/catalogItemTypes.service';

@Component({
  selector: 'app-catalog-items',
  templateUrl: './catalog-items.page.html',
  styleUrls: ['./catalog-items.page.scss'],
})
export class CatalogItemsPage implements OnInit {

  catalogs: Catalog[] = [];
  catalogItems: CatalogItem[] = [];
  searchTerm = '';
  filteredCatalogItems: CatalogItem[] = [];
  catalogItemTypes: CatalogItemType[] = [];
  selectedCatalogType: number | null = null;
  showSelect = false;

  constructor(
    private catalogService: CatalogService,
    private route: ActivatedRoute,
    private router: Router,
    private catalogItemTypesService: CatalogItemTypesService
  ) { }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      let catalogId = params.get('id');
      if (catalogId) {
        this.catalogService.getCatalogItems(catalogId).subscribe(data => {
          this.catalogItems = data;
          this.filteredCatalogItems = [...this.catalogItems];
        });
      }
    })

    this.catalogItemTypesService.list<CatalogItemType[]>().subscribe(
      (catalogItemTypes) => {
        this.catalogItemTypes = catalogItemTypes;
      });
  }

  toggleSelect() {
    this.showSelect = !this.showSelect;
  }

  openCatalogItem(id: string) {
    this.router.navigate([`/catalog-items/${id}/details`]);
  }

  filterCatalogItems() {
    this.filteredCatalogItems = this.catalogItems.filter(item =>
      (this.selectedCatalogType ? item.catalogItemTypeId === this.selectedCatalogType : true) &&
      item.name.toLowerCase().includes(this.searchTerm.toLowerCase())
    );
  }

}
