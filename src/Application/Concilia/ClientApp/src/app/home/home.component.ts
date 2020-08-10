import { Component } from '@angular/core';
import { FileUploader } from 'ng2-file-upload';
import { HttpHeaders } from '@angular/common/http';


// const URL = '/api/';
const URL = 'http://localhost:5000/uploadextratos/upload';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent {
  uploader: FileUploader;
  hasBaseDropZoneOver: boolean;
  hasAnotherDropZoneOver: boolean;
  response: string;

  constructor() {


    this.uploader = new FileUploader({
      //headers: [{ name: 'Access-Control-Allow-Origin', value: '*' },
      //  // { name: 'Content-Type', value: 'application/octet-stream' },
      //  { name: 'withCredentials', value: 'false'}],
      url: URL,
      disableMultipart: true, // 'DisableMultipart' must be 'true' for formatDataFunction to be called.
      formatDataFunctionIsAsync: true,
      formatDataFunction: async (item) => {
        return new Promise((resolve, reject) => {
          resolve({
            name: item._file.name,
            length: item._file.size,
            date: new Date()
          });
        });
      }
    });

    this.uploader.onBeforeUploadItem = (item) => {
      item.withCredentials = false;
    }


    this.response = '';

    this.uploader.response.subscribe(res => this.response = res);
  }
}
