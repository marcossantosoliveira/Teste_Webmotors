
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { ListaAnunciosComponent } from './lista-anuncios.component';
import { ListaAnunciosRoutingModule } from './lista-anuncios-routing.module';

@NgModule({
    declarations: [
        ListaAnunciosComponent
    ],
    imports: [
      CommonModule,
      ListaAnunciosRoutingModule,
      MatTableModule,
      MatSortModule    
    ],
    exports:[
        ListaAnunciosComponent
    ]
  })
export class ListaAnunciosModule { }
