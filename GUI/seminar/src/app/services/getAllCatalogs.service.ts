import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Catalog } from '../models/Catalog';
import { CatalogItem } from '../models/CatalogItem';
import { CatalogItemStatus } from '../models/catalogItemStatus';
import { User } from '../models/User';

@Injectable({
  providedIn: 'root'
})
export class AllCatalogService {

  private baseUrl = 'https://localhost:7059/api/cpm/v1';

  constructor(private http: HttpClient) { }

  getCatalogs(): Observable<Catalog[]> {
    return this.http.get<Catalog[]>(`${this.baseUrl}/RealestateCatalogs/all`);
  }

  getCatalogItems(): Observable<CatalogItem[]> {
    return this.http.get<CatalogItem[]>(`${this.baseUrl}/RealestateCatalogItems/all`);
  }
}
