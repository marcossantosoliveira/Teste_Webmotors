import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ApiService } from 'src/app/services/api.service';
import { AnuncioNovo, AnuncioEditar } from './anuncio.class';

@Component({
    selector: 'app-anuncio-criar-editar',
    templateUrl: './anuncio-criar-editar.component.html',
    styleUrls: ['./anuncio-criar-editar.component.scss']
})
export class AnuncioCriarEditarComponent implements OnInit {

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

        this.buscarMarcas();
        this.idAnuncio = this.route.snapshot.params['id'];

        if (this.idAnuncio != "0") {
            this.buscarAnuncio(this.idAnuncio);            
        }
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

            this.selecionarMarca(result.marca);
            this.selecionarModelo(result.modelo);
        });
    }

    buscarMarcas() {
        debugger
        this.apiService.get('Anuncios/GetAllMake').subscribe((result: any[]) => {
            this.listaMarcas = result;
        });
    }

    buscarModelos(idAnuncio: number) {
        this.apiService.get('Anuncios/GetModelByIdMake/' + idAnuncio).subscribe((result: any[]) => {
            this.listaModelos = result
        });
    }

    buscarVersoes(idAnuncio: number) {
        this.apiService.get('Anuncios/GetVersionByIdModel/' + idAnuncio).subscribe((result: any[]) => {
            this.listaVersoes = result
        });
    }

    selecionarMarca(value: any) {
        let id = 0;
       this.listaMarcas.forEach(e => {
           if (e.nome == value) {
               id = e.id;
           }
       });
                  
        this.buscarModelos(id);
    }

    selecionarModelo(value: any) {     
        let id = 0;
        this.listaModelos.forEach(e => {
            if (e.nome == value) {
                id = e.id;
            }
        });  
        this.buscarVersoes(id);
    }

    salvar() {
        debugger
        if (this.idAnuncio == "0") {

            // Valida formulário 
            if (!this.form.valid) {
                for (let ctrl in this.form.controls) { this.form.controls[ctrl].markAsTouched(); }
            }
            else {
                let anuncio = new AnuncioNovo();

                anuncio.marca = this.form.controls['marca'].value;
                anuncio.modelo = this.form.controls['modelo'].value;
                anuncio.versao = this.form.controls['versao'].value;
                anuncio.ano = +this.form.controls['ano'].value;
                anuncio.quilometragem = +this.form.controls['quilometragem'].value;
                anuncio.observacao = this.form.controls['observacao'].value;

                this.apiService.post('Anuncios/Add', anuncio).subscribe((result: any) => {
                    this.voltar();
                });
            }
        }
        else {
            // Valida formulário 
            if (!this.form.valid) {
                for (let ctrl in this.form.controls) { this.form.controls[ctrl].markAsTouched(); }
            }
            else {
                let anuncio = new AnuncioEditar();

                anuncio.id = +this.idAnuncio;
                anuncio.marca = this.form.controls['marca'].value;
                anuncio.modelo = this.form.controls['modelo'].value;
                anuncio.versao = this.form.controls['versao'].value;
                anuncio.ano = +this.form.controls['ano'].value;
                anuncio.quilometragem = +this.form.controls['quilometragem'].value;
                anuncio.observacao = this.form.controls['observacao'].value;

                this.apiService.put('Anuncios/Update', anuncio).subscribe((result: any) => {
                    this.voltar()
                });
            }
        }
    }

    voltar() {
        this.router.navigateByUrl('');
    }
}