import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { RealEstateCatalogAddComponent } from '../../realEstateCatalogs/edit/realEstateCatalog-add.component';
import { RealEstateCatalogItemAddService } from 'src/app/shared/services/modules/realEstateCatalogItemAdd.service';
import { CatalogItemImages } from 'src/app/shared/model/catalogItemImages';

@Component({
  selector: 'app-catalog-item-upload',
  templateUrl: 'realEstateCatalogItem-upload.component.html',
  styleUrls: ['realEstateCatalogItem-upload.component.scss']
})
export class RealEstateCatalogItemUploadComponent implements OnInit {

  imageUploadForm: FormGroup;
  selectedFiles: FileList | null = null;
  catalogItemId: number = 1; 
  catalogItemImages: CatalogItemImages[] = [];

  constructor(
    private fb: FormBuilder, 
    private imageService: RealEstateCatalogItemAddService,
    private route: ActivatedRoute,
    ) { 
    this.imageUploadForm = this.fb.group({});
  }

  ngOnInit(): void {
    this.catalogItemId = +this.route.snapshot.params['id'];

    this.loadCatalogItemImages()
  }

  onFileSelect(event: any) {
    this.selectedFiles = event.target.files;
  }

  uploadImages() {
    if (this.selectedFiles) {
      this.imageService.uploadMultipleImages(this.catalogItemId, this.selectedFiles)
        .subscribe(
          res => {
            console.log('Upload successful', res);
          },
          err => {
            console.log('Upload failed', err);
          }
        );
    }
  }

  loadCatalogItemImages() {
    this.imageService.getCatalogItemImages(this.catalogItemId).subscribe(images => {
      this.catalogItemImages = images;
      console.log("images", this.catalogItemImages);
    });
    
  }

  deleteImage(imageId: number): void {
    this.imageService.deleteCatalogItemImage(this.catalogItemId, imageId).subscribe(
      res => {
        // Remove deleted image from local array
        this.catalogItemImages = this.catalogItemImages.filter(img => img.id !== imageId);
        console.log('Image deleted successfully');
      },
      err => {
        console.log('Error deleting image', err);
      }
    );
  }
}
