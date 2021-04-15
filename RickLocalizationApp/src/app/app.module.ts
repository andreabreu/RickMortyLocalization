import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RickMortyListComponent } from './pages/rick-morty-list/rick-morty-list.component';
import { RickMortyViewComponent } from './pages/rick-morty-view/rick-morty-view.component';
import { RickMortyHistoryComponent } from './pages/rick-morty-history/rick-morty-history.component';
import { RickMortyEditComponent } from './pages/rick-morty-edit/rick-morty-edit.component';

import { HttpClientModule } from '@angular/common/http';
import { AvatarModule } from 'ngx-avatar';

import { PaginationModule } from 'ngx-bootstrap/pagination';
import { ModalModule } from 'ngx-bootstrap/modal';

import { NgSelectModule } from '@ng-select/ng-select';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    RickMortyListComponent,
    RickMortyViewComponent,
    RickMortyHistoryComponent,
    RickMortyEditComponent,

  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,

    AvatarModule,
    PaginationModule.forRoot(),
    ModalModule.forRoot(),
    NgSelectModule,
    FormsModule, 
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
