
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AnuncioDetalheComponent } from './anuncio-detalhe.component';

const routes: Routes = [{path: '', component: AnuncioDetalheComponent}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],  
  
})
export class AnuncioDetalheRoutingModule { }
