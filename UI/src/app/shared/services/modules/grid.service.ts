import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { GridColumn } from '../../model/grid.model';

@Injectable({
  providedIn: 'root',
})
export class GridService {

  constructor(private http: HttpClient) { }

  fetchFilteredCatalogItems(params: HttpParams): Observable<any> {
    return this.http.get<any>('https://localhost:7059/api/cpm/v1/RealestateCatalogItems/filtered', { params }).pipe(
      map((data) => {
        return {
          data: data.items,
          totalCount: data.totalCount
        };
      })
    );
  }

  createSearchParams(changedOptions: any, loadOptions: any, filterCatalogList: GridColumn[], sortList: GridColumn[]
  ): HttpParams {
    let searchValue = '';
    const filterValuesList: { name: string; value: any; }[] = [];

    changedOptions.forEach((option: { name: string; value: string | null }) => {
      if (option.name === 'searchPanel.text') {
        searchValue = option.value || '';
      } else if (option.name.endsWith('.filterValues')) {
        const match = option.name.match(/columns\[(\d+)\].filterValues/);
        if (match && match[1]) {
          const filter = filterCatalogList.find((category) => category.index === +match[1]);
          if (filter) {
            const filterValue = option.value === null ? '' : option.value;
            filterValuesList.push({ name: filter.name, value: filterValue });
          }
        }
      }
    });

    const filterParam = filterValuesList
      .map((filter) => `${filter.name}#${filter.value}`)
      .join(';');

    const sort = changedOptions
      .filter((option: { name: string }) => option.name.endsWith('.sortOrder'))
      .map((option: { name: string; value: string }) => {
        const match = option.name.match(/columns\[(\d+)\].sortOrder/);
        if (match && match[1]) {
          const sortColumn = sortList.find((column) => column.index === +match[1]);
          if (sortColumn) {
            if (option.value === 'asc' || option.value === 'desc') {
              return `${sortColumn.name}_${option.value}`;
            }
          }
        }
        return '';
      });

    const uniqueSort = Array.from(new Set(sort));
    const finalSort = uniqueSort.length > 0 ? [uniqueSort[0]] : [];

    const page = (loadOptions.skip ?? 0) / (loadOptions.take ?? 1) + 1;
    const pageSize = loadOptions.take ?? 10;

    return new HttpParams()
      .set('page', page)
      .set('pageSize', pageSize)
      .set('search', searchValue)
      .set('filter', filterParam)
      .set('sort', sort);
  }
}
