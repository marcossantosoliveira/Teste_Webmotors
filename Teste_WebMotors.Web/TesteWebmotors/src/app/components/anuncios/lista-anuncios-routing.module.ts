
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListaAnunciosComponent } from './lista-anuncios.component';

const routes: Routes = [{ path: '', component: ListaAnunciosComponent }];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class ListaAnunciosRoutingModule { }
