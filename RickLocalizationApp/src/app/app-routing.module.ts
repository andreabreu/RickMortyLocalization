import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RickMortyEditComponent } from './pages/rick-morty-edit/rick-morty-edit.component';
import { RickMortyListComponent } from './pages/rick-morty-list/rick-morty-list.component';
import { RickMortyViewComponent } from './pages/rick-morty-view/rick-morty-view.component';

const routes: Routes = [
  { path: '', component: RickMortyListComponent },
  { path: 'rick/:id', component: RickMortyViewComponent },
  { path: 'rick/:id/travel', component: RickMortyEditComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

