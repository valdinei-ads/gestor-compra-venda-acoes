import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Location } from '@angular/common';
import { Router } from '@angular/router';

import { OrdemService } from '../../ordem.service';
import { ClienteService } from '../../../cliente/cliente.service';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'app-ordem-create',
    templateUrl: './ordem-create.component.html',
    styleUrls: ['./ordem-create.component.css']
})
export class OrdemCreateComponent implements OnInit {

    formulario: FormGroup;
    clientes: [];

    constructor(
        private clienteService: ClienteService,
        private ordemService: OrdemService,
        private toastrService: ToastrService,
        private router: Router,
        private location: Location
    ) { }

    ngOnInit() {

        this.formulario = new FormGroup({
            tipoOrdem: new FormControl(null),
            dataOrdem: new FormControl(null),
            idCliente: new FormControl(null),
            codigoAcao: new FormControl(null),
            quantidadeAcoes: new FormControl(null),
            dataCompra: new FormControl(null),
        });

        this.clienteService.GetAll().subscribe((res: any) => {
            this.clientes = res.data;
        });
    }

    onSubmit() {
        this.ordemService.Post(this.formulario.value).subscribe(
            data => {
                this.toastrService.success('Ordem cadastrada com sucesso!!!', 'Sucesso').onHidden.subscribe(() => {
                    this.router.navigate(['/ordem']);
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
