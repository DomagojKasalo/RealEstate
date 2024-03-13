import { ComponentFixture, TestBed, async } from '@angular/core/testing';
import { CatalogItemsPage } from './catalog-items.page';

describe('CatalogItemsPage', () => {
  let component: CatalogItemsPage;
  let fixture: ComponentFixture<CatalogItemsPage>;

  beforeEach(async(() => {
    fixture = TestBed.createComponent(CatalogItemsPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
