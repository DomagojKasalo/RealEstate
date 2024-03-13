import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Catalog } from 'src/app/models/Catalog';
import { CatalogItem } from 'src/app/models/CatalogItem';
import { CatalogType } from 'src/app/models/catalogType';
import { CatalogService } from 'src/app/services/catalog.service';
import { CatalogTypesService } from 'src/app/services/catalogTypes.service';

@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.page.html',
  styleUrls: ['./catalog.page.scss'],
})
export class CatalogPage implements OnInit {

  catalogs: Catalog[] = [];
  searchTerm = '';
  filteredCatalogs: Catalog[] = [];
  catalogTypes: CatalogType[] = [];
  selectedCatalogType: number | null = null;

  constructor(
    private catalogService: CatalogService,
    private route: ActivatedRoute,
    private router: Router,
    private catalogTypesService: CatalogTypesService,
  ) { }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.catalogService.getCatalogs().subscribe(data => {
        this.catalogs = data;
        this.filteredCatalogs = [...this.catalogs];
      });
    })

    this.catalogTypesService.list<CatalogType[]>().subscribe(
      (catalogTypes) => {
        this.catalogTypes = catalogTypes;
      });

  }

  filterCatalogItems() {

    this.filteredCatalogs = this.catalogs.filter(item =>
      (this.selectedCatalogType !== null ? item.catalogTypeId === this.selectedCatalogType : true) &&
      item.name.toLowerCase().includes(this.searchTerm.toLowerCase())
    );
  }

  loadMoreCatalogItems(event: any) {
    setTimeout(() => {
      event.complete();
    }, 500);
  }

  openCatalogItem(id: string) {
    this.router.navigate([`/catalog-items/${id}`]);
  }

}
