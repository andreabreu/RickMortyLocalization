import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RickMortyEditComponent } from './rick-morty-edit.component';

describe('RickMortyEditComponent', () => {
  let component: RickMortyEditComponent;
  let fixture: ComponentFixture<RickMortyEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RickMortyEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RickMortyEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
