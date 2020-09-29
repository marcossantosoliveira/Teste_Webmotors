import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
    
    {
        path: '', 
        loadChildren: () => import('../../src/app/components/anuncios/lista-anuncios.module')
        .then(mod => mod.ListaAnunciosModule)     
    },
    {
        path: 'anuncio/:id', 
        loadChildren: () => import('../../src/app/components/anuncios/anuncio-criar-editar/anuncio-criar-editar.module')
        .then(mod => mod.AnuncioCriarEditarModule)     
    },
    {
        path: 'anuncio-detalhe/:id', 
        loadChildren: () => import('../../src/app/components/anuncios/anuncio-detalhe/anuncio-detalhe.module')
        .then(mod => mod.AnuncioDetalheModule)     
    },
  ];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
