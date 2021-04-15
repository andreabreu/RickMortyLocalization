import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RickMortyHistoryComponent } from './rick-morty-history.component';

describe('RickMortyHistoryComponent', () => {
  let component: RickMortyHistoryComponent;
  let fixture: ComponentFixture<RickMortyHistoryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RickMortyHistoryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RickMortyHistoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
