
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AnuncioCriarEditarComponent } from './anuncio-criar-editar.component';

const routes: Routes = [{path: '', component: AnuncioCriarEditarComponent}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],  
  
})
export class AnuncioCriarEditarRoutingModule { }
