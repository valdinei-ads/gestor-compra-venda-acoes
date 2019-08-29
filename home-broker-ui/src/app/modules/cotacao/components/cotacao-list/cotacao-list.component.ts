import { Component, OnInit } from '@angular/core';
import { CotacaoService } from '../../cotacao.service';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'app-cotacao-list',
    templateUrl: './cotacao-list.component.html',
    styleUrls: ['./cotacao-list.component.css']
})
export class CotacaoListComponent implements OnInit {

    cotacoes: [];

    constructor(
        private cotacaoService: CotacaoService,
        private toastrService: ToastrService
        ) { }

    ngOnInit() {
        this.cotacaoService.GetAll().subscribe((res: any) => {
            this.cotacoes = res.data;
        });
    }

    delete(id: number) {
        this.cotacaoService.Remove(id)
            .subscribe(
                data => {
                    this.toastrService.success('Cotação removida com sucesso!!!', 'Sucesso');
                    this.cotacaoService.GetAll().subscribe((res: any) => {
                        this.cotacoes = res.data;
                    });
                },
                error => {
                    error.error.errors.foreach(element => {
                        this.toastrService.error(element.Message, 'Erro');
                    });
                });
    }
}
