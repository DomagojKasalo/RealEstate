import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Catalog } from '../models/Catalog';
import { CatalogItem } from '../models/CatalogItem';
import { CatalogItemStatus } from '../models/catalogItemStatus';
import { User } from '../models/User';
import { CatalogItemImages } from '../models/catalogItemImages';

@Injectable({
  providedIn: 'root'
})
export class CatalogService {

  private baseUrl = 'https://localhost:7059/api/cpm/v1';

  constructor(private http: HttpClient) { }

  getCatalogs(): Observable<Catalog[]> {
    return this.http.get<Catalog[]>(`${this.baseUrl}/RealestateCatalogs`);
  }

  getCatalogItems(catalogId: string): Observable<CatalogItem[]> {
    return this.http.get<CatalogItem[]>(`${this.baseUrl}/RealestateCatalogs/${catalogId}/catalogItems`);
  }

  getCatalogItemDetails(itemId: string): Observable<CatalogItem> {
    return this.http.get<CatalogItem>(`${this.baseUrl}/RealestateCatalogItems/${itemId}`);
  }

  getCatalogItemStatuses(): Observable<CatalogItemStatus[]> {
    return this.http.get<CatalogItemStatus[]>(`${this.baseUrl}/RealestateCatalogItemStatus`);
  }

  updateCatalogItem(item: CatalogItem): Observable<CatalogItem> {
    return this.http.put<CatalogItem>(`${this.baseUrl}/RealestateCatalogItems/${item.id}`, item);
  }

  reserveOrBuyItem(request: { itemId: number, action: number, user: User }): Observable<any> {
    return this.http.post<any>(`https://localhost:7059/api/Accounts/reserveOrBuy/`, request);
  }

  getCatalogItemImages(catalogItemId: number): Observable<CatalogItemImages[]> {
    return this.http.get<CatalogItemImages[]>(`${this.baseUrl}/RealestateCatalogItems/${catalogItemId}/images`);
  }
}
