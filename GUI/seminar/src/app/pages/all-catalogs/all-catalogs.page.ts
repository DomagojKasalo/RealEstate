import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Catalog } from 'src/app/models/Catalog';
import { CatalogType } from 'src/app/models/catalogType';
import { CatalogTypesService } from 'src/app/services/catalogTypes.service';
import { AllCatalogService } from 'src/app/services/getAllCatalogs.service';

@Component({
  selector: 'app-all-catalogs',
  templateUrl: './all-catalogs.page.html',
  styleUrls: ['./all-catalogs.page.scss'],
})
export class AllCatalogsPage implements OnInit {

  catalogs: Catalog[] = [];
  // catalog: Catalog[] = [];
  searchTerm = '';
  filteredCatalogs: Catalog[] = [];
  catalogTypes: CatalogType[] = [];
  selectedCatalogType: number | null = null;
  showSelect = false;

  constructor(
    private catalogService: AllCatalogService,
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

  toggleSelect() {
    this.showSelect = !this.showSelect;
  }

  filterCatalogItems() {
    this.filteredCatalogs = this.catalogs.filter(item =>
      (this.selectedCatalogType ? item.catalogTypeId === this.selectedCatalogType : true) &&
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
