import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {
  public extratoConciliado;
  public currentCount = 0;
  public dotnetport = 'http://localhost:5000/';

  constructor(http: HttpClient) {

    const httpOptions = {
      headers: new HttpHeaders({
        'Access-Control-Allow-Origin': '*',
        'responseType' : 'json' 
      })
    };

    http.get<string>(this.dotnetport + 'conciliaextratos', httpOptions).subscribe(result => {
      this.extratoConciliado = result;
    }, error => console.error(error));
  }
}
