import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RickMortyListComponent } from './pages/rick-morty-list/rick-morty-list.component';
import { RickMortyViewComponent } from './pages/rick-morty-view/rick-morty-view.component';

const routes: Routes = [
  { path: '', component: RickMortyListComponent },
  { path: 'rick/:id', component: RickMortyViewComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

