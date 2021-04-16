import { EventEmitter } from '@angular/core';
import { Component, Input, OnInit, Output, TemplateRef } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgSelectConfig } from '@ng-select/ng-select';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { DimensionModel } from 'src/app/models/dimension.model';
import { RickDimension } from 'src/app/models/rick-dimension.model';
import { RickModel } from 'src/app/models/rick.model';
import { DimensionService } from 'src/app/services/dimension.service';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-rick-morty-history',
  templateUrl: './rick-morty-history.component.html',
  styleUrls: ['./rick-morty-history.component.css']
})
export class RickMortyHistoryComponent implements OnInit {

  @Input() rickInfo: RickModel;
  @Output() saved = new EventEmitter<boolean>();

  modalRef: BsModalRef;

  dimensions: DimensionModel[];
  navigationForm = new FormGroup({
    dimension: new FormControl(1, [Validators.required]),
  });



  constructor(
    private modalService: BsModalService,
    private dimensionService: DimensionService,
    private config: NgSelectConfig) {
    this.config.notFoundText = 'Dimension not found';
    this.config.appendTo = 'body';
    this.config.bindValue = 'value';
  }

  ngOnInit(): void {
    this.loadDimensions();
  }


  loadDimensions() {
    this.dimensionService.get().subscribe((data: DimensionModel[]) => {
      this.dimensions = data;
    })
  }

  dimensionInfo(dimensionId: Number) {
    var dimension = this.dimensions.filter(x => x.id == dimensionId)[0]
    return dimension;
  }

  openModal(template: TemplateRef<any>) {
    this.playAudio('portal');
    this.modalRef = this.modalService.show(template);
  }

  onSubmit() {
    if (this.navigationForm.valid) {
      var id = this.navigationForm.value.dimension;

      var rickDimension = new RickDimension();
      rickDimension.dimensionId = id;
      rickDimension.rickId = this.rickInfo.id;


      var exist = this.rickInfo.rickDimensions.filter(x => x.dimensionId == rickDimension.dimensionId)[0] ? true : false;
      if (exist) {
        Swal.fire({
          title: 'Oops...',
          text: 'You have already visited this dimension and they didn\'t like your visit.',
          imageUrl: 'https://i.pinimg.com/564x/ef/a0/a6/efa0a647497570e7c5799dcb3549285f.jpg',
          imageHeight: 300,
          imageAlt: 'A tall image'
        });
        return;
      }

      this.dimensionService.addTravel(rickDimension)
        .subscribe(() => {
          this.playAudio('rick');
          Swal.fire({
            title: 'Wubba Lubba Dub Dub',
            text: 'Lets go Morty',
            imageUrl: 'https://i.pinimg.com/564x/be/74/cb/be74cb925b68be07e421ca39c177c97a.jpg',
            imageHeight: 300,
            imageAlt: 'A tall image'
          })
            .then(() => {

              var dimension = this.dimensions.filter(x => x.id == id)[0];

              if (dimension.name == 'Dimension C-137') {
                Swal.fire({
                  title: 'Success!',
                  text: 'You have reached the expected dimension.',
                  imageUrl: 'https://media0.giphy.com/media/Njfu3d2zHjkwU/giphy.gif',
                  imageHeight: 300,
                  imageAlt: 'A tall image'
                })
              }

            })
          this.saved.emit(true);
          this.modalService.hide();
        })
    }
  }

  playAudio(name: string) {
    let audio: HTMLAudioElement = new Audio(`../assets/media/${name}.mp3`);
    audio.volume = 0.2;
    audio.play();
  }

}
