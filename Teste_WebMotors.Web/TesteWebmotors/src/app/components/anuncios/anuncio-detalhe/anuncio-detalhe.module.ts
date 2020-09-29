import { MatInputModule } from '@angular/material/Input';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { AnuncioDetalheComponent } from './anuncio-detalhe.component';
import { AnuncioDetalheRoutingModule } from './anuncio-detalhe-routing.module';

@NgModule({
    declarations: [AnuncioDetalheComponent],
    imports: [
        CommonModule,
        AnuncioDetalheRoutingModule,
        ReactiveFormsModule,              
        MatInputModule,                
    ]
})
export class AnuncioDetalheModule { }
