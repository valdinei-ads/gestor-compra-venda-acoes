import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { CotacaoService } from '../../cotacao.service';
import { Cotacao } from '../../cotacao';
import { Location } from '@angular/common';

@Component({
    selector: 'app-cotacao-details',
    templateUrl: './cotacao-details.component.html',
    styleUrls: ['./cotacao-details.component.css']
})
export class CotacaoDetailsComponent implements OnInit {

    cotacao: Cotacao;

    constructor(
        private cotacaoService: CotacaoService,
        private route: ActivatedRoute,
        private location: Location) {
        this.cotacao = new Cotacao();
    }

    ngOnInit() {
        this.route.params.subscribe(
            (params: any) => {
                this.cotacaoService.GetById(params.id).subscribe((res: any) => {
                    this.cotacao.idCotacaoAcao = res.data.idCotacaoAcao;
                    this.cotacao.codigoAcao = res.data.codigoAcao;
                    this.cotacao.dataCotacao = res.data.dataCotacao;
                    this.cotacao.valorCotacao = res.data.valorCotacao;
                });
            }
        );
    }

    Back() {
        this.location.back(); // <-- go back to previous location on cancel
    }
}
