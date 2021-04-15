import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RickMortyViewComponent } from './rick-morty-view.component';

describe('RickMortyViewComponent', () => {
  let component: RickMortyViewComponent;
  let fixture: ComponentFixture<RickMortyViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RickMortyViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RickMortyViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
