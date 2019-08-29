import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormControl } from '@angular/forms';

import { ToastrService } from 'ngx-toastr';

import { CotacaoService } from '../../cotacao.service';
import { Location } from '@angular/common';

@Component({
    selector: 'app-cotacao-create',
    templateUrl: './cotacao-create.component.html',
    styleUrls: ['./cotacao-create.component.css']
})
export class CotacaoCreateComponent implements OnInit {

    id: number;
    formulario: FormGroup;

    constructor(
        private cotacaoService: CotacaoService,
        private toastrService: ToastrService,
        private router: Router,
        private location: Location
    ) { }

    ngOnInit() {

        this.formulario = new FormGroup({
            codigoAcao: new FormControl(null),
            dataCotacao: new FormControl(null),
            valorCotacao: new FormControl(null)
        });
    }

    onSubmit() {
        this.cotacaoService.Post(this.formulario.value)
            .subscribe(
                data => {
                    this.toastrService.success('Cotação cadastrada com sucesso!!!', 'Sucesso').onHidden.subscribe(() => {
                        this.router.navigate(['/cotacao']);
                    });
                },
                error => {
                    console.log(error);
                    error.error.errors.forEach(element => {
                        this.toastrService.error(element.message, 'Erro');
                    });
                });
    }

    Back() {
        this.location.back(); // <-- go back to previous location on cancel
    }
}
