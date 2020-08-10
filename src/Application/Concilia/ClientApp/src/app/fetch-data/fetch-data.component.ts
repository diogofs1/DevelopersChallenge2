import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[];
  public dotnetport = 'http://localhost:5000/';

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    const httpOptions = {
      headers: new HttpHeaders({
        'Access-Control-Allow-Origin': '*'
      })
    };

    http.get<WeatherForecast[]>(this.dotnetport + 'weatherforecast', httpOptions).subscribe(result => {
      console.log(result);
      this.forecasts = result;
    }, error => console.error(error));
  }
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
