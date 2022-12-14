import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { throwError } from 'rxjs';
import { Slika } from '../../models/slika.model';
@Injectable({
  providedIn: 'root',
})
export class RestApiService {
  apiURL = 'https://localhost:7212/api/GIF/';
  constructor(private http: HttpClient) { }
  // https://www.positronx.io/angular-httpclient-http-service/
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

  async GenerirajGIF(listaParam: any): Promise<Slika> {
    return await this.http.post<Slika>(this.apiURL + "GenerateGIF", listaParam).toPromise() as Slika;
  }
  
  // Error handling
  handleError(error: any) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    window.alert(errorMessage);
    return throwError(() => {
      return errorMessage;
    });
  }
}