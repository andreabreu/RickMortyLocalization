import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { RickModel } from 'src/app/models/rick.model';
import { RickService } from 'src/app/services/rick.service';
import { DimensionService } from 'src/app/services/dimension.service';
import { DimensionModel } from 'src/app/models/dimension.model';
import { NgSelectConfig } from '@ng-select/ng-select';
import { RickDimension } from 'src/app/models/rick-dimension.model';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-rick-morty-view',
  templateUrl: './rick-morty-view.component.html',
  styleUrls: ['./rick-morty-view.component.css']
})
export class RickMortyViewComponent implements OnInit {

  rickInfo: RickModel;
  showHistory: boolean = false;

  constructor(private actRoute: ActivatedRoute,
    private rickService: RickService,
  ) {
  
  }

  ngOnInit(): void {
    var id = this.actRoute.snapshot.params.id;
    this.loadRickInfo(id);
  }

  loadRickInfo(id: number) {

    this.rickService.getById(id).subscribe((data: RickModel) => {
      this.rickInfo = data;
    })
  }
}
