import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class RickService {

  url = 'https://localhost:44300/api';

  constructor(private http: HttpClient) { }

  get(pageNumber: Number) {
    return this.http.get(this.url + `/rick?PageNumber=${pageNumber}&PageSize=12`);
  }

  getById(id: Number)  {
    return this.http.get(this.url + `/rick/${id}`);
  }
}
