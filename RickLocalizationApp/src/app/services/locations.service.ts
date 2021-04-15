import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class LocationsService {

  constructor(private http: HttpClient) { }

  getLocations(page: number) {
    var urlApi = 'https://rickandmortyapi.com/api/location?page=' + page;

    return this.http.get(urlApi);
  }
}
