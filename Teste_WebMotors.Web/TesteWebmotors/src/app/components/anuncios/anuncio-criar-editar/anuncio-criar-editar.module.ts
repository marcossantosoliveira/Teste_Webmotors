import { MatInputModule } from '@angular/material/Input';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';

import { AnuncioCriarEditarComponent } from './anuncio-criar-editar.component';
import { AnuncioCriarEditarRoutingModule } from './anuncio-criar-editar-routing.module';

@NgModule({
    declarations: [AnuncioCriarEditarComponent],
    imports: [
        CommonModule,
        AnuncioCriarEditarRoutingModule,
        ReactiveFormsModule,              
        MatInputModule,                
    ]
})
export class AnuncioCriarEditarModule { }
