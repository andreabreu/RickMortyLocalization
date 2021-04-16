import { Component, OnInit } from '@angular/core';
import { LocationsService } from '../../services/locations.service'
import { RickService } from '../../services/rick.service'
import { RickModel } from '../../models/rick.model'
import { PagedResponse } from '../../models/wrappers/paged-response'
import { Router } from '@angular/router';
import { animate, state, style, transition, trigger } from '@angular/animations';



@Component({
  selector: 'app-rick-morty-list',
  templateUrl: './rick-morty-list.component.html',
  styleUrls: ['./rick-morty-list.component.css'],
  animations: [
    trigger('fade', [
      state('in', style({ opacity: 0.93 })),
      transition(':enter', [style({ opacity: 0 }), animate(600)]),
      transition(':leave', animate(600, style({ opacity: 0 })))
    ])
  ]
})

export class RickMortyListComponent implements OnInit {

  title = 'RickLocalizationApp';
  locations = Array<any>();
  ricks = Array<RickModel>();

  response: PagedResponse;


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
}
