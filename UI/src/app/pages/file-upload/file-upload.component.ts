import { NgModule, Component, enableProdMode } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';
import RemoteFileSystemProvider from 'devextreme/file_management/remote_provider';
import { BlobServiceClient } from '@azure/storage-blob';


@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.scss'],
})
export class FileUploadComponent {
  allowedFileExtensions: string[];

  fileSystemProvider: RemoteFileSystemProvider;

  wrapperClassName: string;

  loadPanelVisible: boolean;

  constructor(http: HttpClient) {
    this.allowedFileExtensions = [];

    // Configure Azure Blob Storage client with your connection string or access key
    const blobServiceClient = BlobServiceClient.fromConnectionString('YOUR_CONNECTION_STRING');

    // Configure RemoteFileSystemProvider with Azure Blob Storage endpoint URL
    this.fileSystemProvider = new RemoteFileSystemProvider({
      endpointUrl: 'https://youraccount.blob.core.windows.net/containername',
      // blobServiceClient: blobServiceClient, // Pass the configured Azure Blob Storage client
    });

    this.wrapperClassName = '';
    this.loadPanelVisible = true;

    this.checkAzureStatus(http);
  }

  checkAzureStatus(http: HttpClient) {
    lastValueFrom(http.get<{ active: boolean }>('https://js.devexpress.com/Demos/Mvc/api/file-manager-azure-status?widgetType=fileManager'))
      .then((result) => {
        this.wrapperClassName = result.active ? 'show-widget' : 'show-message';
        this.loadPanelVisible = false;
      });
  }
}


// selectedFile: File | undefined;
// uploadedUrl: string | undefined;

// constructor(private fileUploadService: FileUploadService) {}



// onFileSelected(event: any) {
//   this.selectedFile = event.target.files[0];
// }

// uploadFile() {
//   if (this.selectedFile) {
//     this.fileUploadService.uploadFile(this.selectedFile).subscribe(
//       (url) => {
//         this.uploadedUrl = url;
//       },
//       (error) => {
//         console.error('Error uploading file:', error);
//       }
//     );
//   }
// }
