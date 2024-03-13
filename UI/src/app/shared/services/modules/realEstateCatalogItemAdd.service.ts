import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CatalogItemImages } from '../../model/catalogItemImages';

@Injectable({ providedIn: "root" })
export class RealEstateCatalogItemAddService {
  baseUrl: string = "https://localhost:7059/api/cpm/v1";
  resourceName: string = "RealestateCatalogItems";

  url: string = "https://localhost:7059/api/cpm/v1/RealestateCatalogItems/filtered"

  constructor(private http: HttpClient) { }

  add<T>(data: FormData): Observable<T> {
    return this.http.post<T>(`${this.baseUrl}/${this.resourceName}`, data);
  }

  update<T>(id: number, data: FormData): Observable<T> {
    return this.http.put<T>(`${this.baseUrl}/${this.resourceName}/${id}`, data);
  }

  uploadMultipleImages(catalogItemId: number, images: FileList): Observable<any> {
    const formData = new FormData();
  
    Array.from(images).forEach((image, index) => {
      formData.append(`imageFile`, image, image.name); 
    });
  
    return this.http.post(`${this.baseUrl}/RealestateCatalogItems/${catalogItemId}/images`, formData);
  }

  getCatalogItemImages(catalogItemId: number): Observable<CatalogItemImages[]> {
    return this.http.get<CatalogItemImages[]>(`${this.baseUrl}/RealestateCatalogItems/${catalogItemId}/images`);
  }

  deleteCatalogItemImage(catalogItemId: number, imageId: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/RealestateCatalogItems/${catalogItemId}/images/${imageId}`);
  }

  list<T>(page: number, pageSize: number, search: string, catalogId?: number): Observable<T> {
    let params = new HttpParams()
      .set('page', page.toString())
      .set('pageSize', pageSize.toString())
      .set('search', search);
  
    // Add catalogId to the parameters if it's specified
    if (catalogId != null) {
      params = params.set('catalogId', catalogId.toString());
    }
  
    return this.http.get<T>(this.url, { params });
  }
}



