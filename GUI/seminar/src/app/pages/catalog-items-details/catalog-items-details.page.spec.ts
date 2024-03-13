import { ComponentFixture, TestBed, async } from '@angular/core/testing';
import { CatalogItemsDetailsPage } from './catalog-items-details.page';

describe('CatalogItemsDetailsPage', () => {
  let component: CatalogItemsDetailsPage;
  let fixture: ComponentFixture<CatalogItemsDetailsPage>;

  beforeEach(async(() => {
    fixture = TestBed.createComponent(CatalogItemsDetailsPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
