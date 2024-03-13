import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AllCatalogsPage } from './all-catalogs.page';

describe('AllCatalogsPage', () => {
  let component: AllCatalogsPage;
  let fixture: ComponentFixture<AllCatalogsPage>;

  beforeEach(async(() => {
    fixture = TestBed.createComponent(AllCatalogsPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
