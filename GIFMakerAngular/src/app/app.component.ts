import { Component } from '@angular/core';
import { Slika } from '../models/slika.model';
import { RestApiService } from './api-service/rest-api.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'GIF Maker Angular';

  slikeLista: Slika[] = [];
  slikeNazivi: string[] = [];
  msg = "";
  slika: Slika = new Slika;
  slikaGIF: Slika = new Slika;
  loading: boolean = false;

  constructor(public restApi: RestApiService, private http: HttpClient) {
    if (localStorage.getItem("slike") !== null)
      this.slikeLista = JSON.parse(localStorage.getItem('slike') || '{}');
  }

  selectFile(event: any) {
    if (!event.target.files[0] || event.target.files[0].length == 0) {
      this.msg = 'Morate odabrati sliku';
      return;
    }

    var mimeType = event.target.files[0].type;

    if (mimeType.match(/image\/*/) == null) {
      this.msg = "Samo su slike podržane";
      return;
    }

    var reader = new FileReader();
    reader.readAsDataURL(event.target.files[0]);

    reader.onload = (_event) => {
      this.msg = "";

      this.slika = new Slika;
      this.slika.base64 = reader.result;
      this.slika.ekstenzija = mimeType;
      this.slika.naziv = event.target.files[0].name.split('.').slice(0, -1).join('.'); //https://stackoverflow.com/questions/4250364/how-to-trim-a-file-extension-from-a-string-in-javascript

      this.slikeLista.push(this.slika);
      localStorage.setItem("slike", JSON.stringify(this.slikeLista));          
    }    
    //console.log(this.slikeLista);
  }

  brisanjeSlike(indeks:number)
  {
    delete this.slikeLista[indeks];
    //console.log("Brisanje slike!");
    this.slikeLista.splice(indeks, 1);
    localStorage.setItem("slike", JSON.stringify(this.slikeLista));
  }

  async generirajGIF()
  {
    this.loading = true;
    var odgovor = this.restApi.GenerirajGIF(this.slikeLista);
    this.slikaGIF = new Slika;
    this.slikaGIF.base64 = (await odgovor).base64;
    this.slikaGIF.naziv = (await odgovor).naziv;
    this.slikaGIF.ekstenzija = (await odgovor).ekstenzija;
    //console.log(this.slikaGIF);
    this.loading = false;
  }

}
