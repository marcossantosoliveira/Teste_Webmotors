

import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ApiService } from 'src/app/services/api.service';

@Component({
    selector: 'app-anuncio-detalhe',
    templateUrl: './anuncio-detalhe.component.html',
    styleUrls: ['./anuncio-detalhe.component.scss']
})
export class AnuncioDetalheComponent implements OnInit {

    form: FormGroup;
    public idAnuncio: string;
    public maxDateValue = new Date(Date.now());
    public listaMarcas: any[] = [];
    public listaModelos: any[] = [];
    public listaVersoes: any[] = [];

    constructor(private apiService: ApiService, private router: Router, private route: ActivatedRoute) {
        this.form = new FormGroup({
            marca: new FormControl('', Validators.required),
            modelo: new FormControl('', Validators.required),
            versao: new FormControl('', Validators.required),
            ano: new FormControl('', Validators.required),
            quilometragem: new FormControl('', Validators.required),
            observacao: new FormControl('', Validators.required),
        });
    }

    ngOnInit(): void {
        debugger;

        this.idAnuncio = this.route.snapshot.params['id'];
        this.buscarAnuncio(this.idAnuncio);

    }

    buscarAnuncio(idAnuncio: string) {
        this.apiService.get('Anuncios/GetById/' + idAnuncio).subscribe((result: any) => {
            this.form.setValue({
                marca: result.marca,
                modelo: result.modelo,
                versao: result.versao,
                ano: result.ano,
                quilometragem: result.quilometragem,
                observacao: result.observacao
            });
        });
    }

    voltar() {
        this.router.navigateByUrl('');
    }
}

