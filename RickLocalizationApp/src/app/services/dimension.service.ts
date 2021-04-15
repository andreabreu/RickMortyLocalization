import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RickDimension } from "../models/rick-dimension.model";

@Injectable({
  providedIn: 'root'
})
export class DimensionService {
  url = 'https://localhost:44300/api';

  constructor(private http: HttpClient) { }

  get() {
    return this.http.get(this.url + `/dimension`);
  }

  addTravel(rickDimension: RickDimension) {
    return this.http.post(this.url + `/dimension/AddTravel`, rickDimension);
  }
}
