import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';

import { CotacaoService } from '../../cotacao.service';
import { ToastrService } from 'ngx-toastr';
import { Location } from '@angular/common';

@Component({
    selector: 'app-cotacao-edit',
    templateUrl: './cotacao-edit.component.html',
    styleUrls: ['./cotacao-edit.component.css']
})
export class CotacaoEditComponent implements OnInit {

    id: number;
    formulario = new FormGroup({
        idCotacaoAcao: new FormControl(),
        codigoAcao: new FormControl(),
        dataCotacao: new FormControl(),
        valorCotacao: new FormControl()
    });

    constructor(
        private cotacaoService: CotacaoService,
        private toastrService: ToastrService,
        private router: Router,
        private route: ActivatedRoute,
        private location: Location
    ) {

    }

    ngOnInit() {
        this.route.params.subscribe(params => {
            this.cotacaoService.GetById(params.id).subscribe((res: any) => {
                this.formulario.setValue({
                    idCotacaoAcao: res.data.idCotacaoAcao,
                    codigoAcao: res.data.codigoAcao,
                    dataCotacao: res.data.dataCotacao,
                    valorCotacao: res.data.valorCotacao
                });
            });
        });
    }

    onSubmit() {
        this.cotacaoService
            .Put(this.formulario.value)
            .subscribe(
                data => {
                    this.toastrService.success('Cotação atualizada com sucesso!!!', 'Sucesso').onHidden.subscribe(() => {
                        this.router.navigate(['/cotacao']);
                    });
                },
                error => {
                    error.error.errors.forEach(element => {
                        this.toastrService.error(element.Message, 'Erro');
                    });
                });
    }

    Back() {
        this.location.back(); // <-- go back to previous location on cancel
    }

}
