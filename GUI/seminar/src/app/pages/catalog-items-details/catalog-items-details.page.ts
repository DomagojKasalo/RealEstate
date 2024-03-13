import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { CatalogItem } from 'src/app/models/CatalogItem';
import { Company } from 'src/app/models/Company';
import { User } from 'src/app/models/User';
import { CatalogItemImages } from 'src/app/models/catalogItemImages';
import { CatalogItemStatus } from 'src/app/models/catalogItemStatus';
import { CatalogItemType } from 'src/app/models/catalogItemType';
import { AuthService } from 'src/app/services/auth.service';
import { CatalogService } from 'src/app/services/catalog.service';
import { CatalogItemTypesService } from 'src/app/services/catalogItemTypes.service';
import { CompanyService } from 'src/app/services/company.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-catalog-items-details',
  templateUrl: './catalog-items-details.page.html',
  styleUrls: ['./catalog-items-details.page.scss'],
})
export class CatalogItemsDetailsPage implements OnInit {

  catalogItem!: CatalogItem;
  catalogItems: CatalogItem[] = [];
  catalogItemStatuses: CatalogItemStatus[] = []; 
  user!: User;
  userId: string = "";
  companyId: number = 0;
  public company: Company | null = null;
  catalogItemImages: CatalogItemImages[] = [];
  currentSlide: number = 0;
  detailsArray: { label: string, value: any }[] = [];

  constructor(
    private catalogService: CatalogService,
    private userService: UserService, 
    private route: ActivatedRoute,
    private authService: AuthService,
    private companyService: CompanyService,
    ) { }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      let itemId = params.get('id');
      if (itemId) {
        this.catalogService.getCatalogItemDetails(itemId).subscribe(data => {
          this.catalogItem = data;
          if (itemId != null)
            this.loadCatalogItemImages(+itemId); 
            this.fetchCompanies(this.catalogItem.companyId);
            this.detailsArray = [
              { label: 'Description', value: this.catalogItem?.description },
              { label: 'Floors', value: this.catalogItem?.floors },
              { label: 'Rooms', value: this.catalogItem?.rooms },
              { label: 'Bathrooms', value: this.catalogItem?.bathrooms },
              { label: 'Garage Places', value: this.catalogItem?.garagePlaces },
              { label: 'Dimensions', value: this.catalogItem?.netArea },
              { label: 'Status', value: this.getStatusName(this.catalogItem?.catalogItemStatusId) }
            ];
        });
      }
      this.userId = this.authService.getUserId() || '';

      this.loadUserDetails();
      
    })

    this.catalogService.getCatalogItemStatuses().subscribe(statuses => {
      this.catalogItemStatuses = statuses;
    });
  }

  plusSlides(n: number): void {
    this.currentSlide = (this.currentSlide + n + this.catalogItemImages.length) % this.catalogItemImages.length;
  }

  isCurrentSlide(index: number): boolean {
    return index === this.currentSlide;
  }

  fetchCompanies(companyId: number): void {
    this.companyService.single<Company>(companyId).subscribe(
      company => {
        this.company = company;
        console.log("Company", company);
      }
    );
  }

  loadCatalogItemImages(itemId: number) {
    this.catalogService.getCatalogItemImages(itemId).subscribe(images => {
      this.catalogItemImages = images;
    });
    
  }

  openFullScreen(imagePath: string | undefined) {
    if (imagePath) {
      const fullSizeImage = new Image();
      fullSizeImage.src = 'http://localhost:3000' + imagePath;
      fullSizeImage.style.display = 'block';
      fullSizeImage.style.margin = 'auto';
      fullSizeImage.style.maxWidth = '100%';
      fullSizeImage.style.maxHeight = '100vh';

      const div = document.createElement('div');
      div.id = 'full-screen-image-container';
      div.style.position = 'fixed';
      div.style.top = '20';
      div.style.left = '0';
      div.style.width = '100%';
      div.style.height = '100vh';
      div.style.backgroundColor = 'rgba(0,0,0,0.8)';
      div.style.zIndex = '99999';
      div.appendChild(fullSizeImage);
      div.onclick = () => {
        document.body.removeChild(div);
      };

      document.body.appendChild(div);
    }
  }

  getStatusName(catalogItemStatusId: number): string {
    let status = this.catalogItemStatuses.find(status => status.id === catalogItemStatusId);
    return status ? status.name : 'Status not found';
  }

  loadUserDetails() {
    if (this.userId) {
      this.userService.single<User>(this.userId).subscribe(user => {
        this.user = user;
        if (this.user.companyId) {
        }
      });
    }
  }

  updateStatus(statusId: number) {
    this.catalogItem.catalogItemStatusId = statusId; 
    this.catalogService.updateCatalogItem(this.catalogItem).subscribe(() => {
      let action = statusId === 2 ? 0 : 1;
      let request = {
        itemId: this.catalogItem.id,
        action: action,
        user: this.user
      };
      this.catalogService.reserveOrBuyItem(request)
        .subscribe(() => {
        });
    });
  }
}
