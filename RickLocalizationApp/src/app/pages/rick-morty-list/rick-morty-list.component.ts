import { Component, OnInit } from '@angular/core';
import { forkJoin } from 'rxjs';
import { groupBy } from 'rxjs/internal/operators/groupBy';
import { LocationsService } from '../../services/locations.service'
import { RickService } from '../../services/rick.service'
import { RickModel } from '../../models/rick.model'
import { PagedResponse } from '../../models/wrappers/paged-response'
import { Router } from '@angular/router';

@Component({
  selector: 'app-rick-morty-list',
  templateUrl: './rick-morty-list.component.html',
  styleUrls: ['./rick-morty-list.component.css']
})
export class RickMortyListComponent implements OnInit {

  title = 'RickLocalizationApp';
  locations = Array<any>();
  ricks = Array<RickModel>();

  response: PagedResponse = new PagedResponse();


  constructor(private locationService: LocationsService, 
    private rickService: RickService,
    private route: Router
    ) { }

  ngOnInit(): void {
    this.loadRicks();
  }

  loadRicks() {
    this.rickService.get(1).subscribe((response: PagedResponse) => {
      this.response = response;

      this.ricks = this.response.data;
    })
  }

  pageChanged(event: any): void {
    this.rickService.get(Number(event.page)).subscribe((response: PagedResponse) => {
      this.response = response;

      this.ricks = this.response.data;
    })
  }


  openRick(id: Number) {

    this.route.navigate(['/rick/' + id])
  }

  loadLocations() {

    this.locationService.getLocations(1).subscribe((data: any) => {
      this.readAllPagesLocation(data.info.pages);
    })
  }

  readAllPagesLocation(pages: number) {

    var locationsRequests = new Array<any>();

    for (let i = 1; i <= pages; i++) {
      var request = this.locationService.getLocations(i);
      locationsRequests.push(request);
    }



    forkJoin(locationsRequests).subscribe(results => {
      results.forEach((result: any) => {
        this.locations.push(result.results);
      });
      var x = this.groupBy(this.locations[0], 'dimension')
      console.log(x)
    });


  }

  groupBy(xs, key) {

    return xs.reduce(function (rv, x) {
      (rv[x[key]] = rv[x[key]] || []).push(x);
      return rv;
    }, {});

  };



}
