import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit, ViewChild } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';

@Component({
    selector: 'app-lista-anuncios',
    templateUrl: './lista-anuncios.component.html',
    styleUrls: ['./lista-anuncios.component.scss']
})
export class ListaAnunciosComponent implements OnInit {

    public dataSource;
    public displayedColumns = [];
    public listaAnuncios: any[] = [];
    public columnNames = [{id: 'marca',value:'Marca',},{id: 'modelo',value:'Modelo',},{id: 'versao',value:'versão',}
    ,{id: 'ano',value:'Ano',},{id: 'quilometragem',value:'Quilometragem',},{id: 'observacao',value:'Observacao',},{id: 'detalhe',value:'Detalhe',},{id: 'editar',value:'Editar',},{id: 'excluir',value:'Excluir',}];
    
    @ViewChild(MatSort) sort: MatSort;
    

    constructor(private apiService: ApiService, private router: Router, private route: ActivatedRoute) { }

    ngOnInit() {
        this.buscarAnuncios();
    }    

    buscarAnuncios() {
        debugger
        this.apiService.get('Anuncios/GetAll').subscribe((result: any) => {
            this.listaAnuncios = result;
            this.dataSource = new MatTableDataSource(this.listaAnuncios);
            this.dataSource.sort = this.sort;
            this.displayedColumns = this.columnNames.map(m=>m.id);
        });
    }

    criar(){
        this.router.navigateByUrl('/anuncio/0');
    }

    editar(id:any){
        debugger

        this.router.navigateByUrl('/anuncio/' + id);
    }

    detalhe(id:any){
        debugger

        this.router.navigateByUrl('/anuncio-detalhe/' + id);
    }

    excluir(id:string){
        debugger
        this.apiService.delete('Anuncios/Delete/' + id ).subscribe((result: any) => {
          this.buscarAnuncios();
        });
    }
}