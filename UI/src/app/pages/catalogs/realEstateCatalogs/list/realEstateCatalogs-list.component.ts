import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { RealEstateCatalog } from 'src/app/shared/model/realEstateCatalog';
import { RealEstateCatalogsService } from 'src/app/shared/services/modules/realEstateCatalogs.service';

@Component({
  templateUrl: 'realEstateCatalogs-list.component.html',
  styleUrls: ['realEstateCatalogs-list.component.scss']
})
export class RealEstateCatalogListComponent implements OnInit {
  public catalogs: RealEstateCatalog[] = [];
  public loading = false;

  constructor(
    private catalogService: RealEstateCatalogsService,
    private router: Router,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.fetchCatalogs();
  }

  fetchCatalogs(): void {
    this.loading = true;
    this.catalogService.list<RealEstateCatalog[]>().subscribe(
      catalogs => {
        this.catalogs = catalogs;
        this.loading = false;
      },
    );
  }

  onRowClick(rowData: RealEstateCatalog): void {
    this.router.navigateByUrl(`/catalogs/edit/${rowData.id}`);
  }

  onAddClick(): void {
    this.router.navigateByUrl('/catalogs/add');
  }
}
