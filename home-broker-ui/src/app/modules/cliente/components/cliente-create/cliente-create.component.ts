import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

import { ClienteService } from '../../cliente.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { Location } from '@angular/common';

@Component({
    selector: 'app-cliente-create',
    templateUrl: './cliente-create.component.html',
    styleUrls: ['./cliente-create.component.css']
})
export class ClienteCreateComponent implements OnInit {

    formulario: FormGroup;

    constructor(
        private clienteService: ClienteService,
        private toastrService: ToastrService,
        private router: Router,
        private location: Location) { }

    ngOnInit() {
        this.formulario = new FormGroup({
            nome: new FormControl(),
            cpfCnpj: new FormControl(),
            tipoPessoa: new FormControl(),
            dataNascimento: new FormControl()
        });
    }

    onSubmit() {
        this.clienteService.Post(this.formulario.value)
            .subscribe(
                data => {
                    this.toastrService.success('Cliente cadastrado com sucesso!!!', 'Sucesso').onHidden.subscribe(() => {
                        this.router.navigate(['/cliente']);
                    });
                },
                error => {
                    error.error.forEach(element => {
                        this.toastrService.error(element.Message, 'Erro');
                    });
                });
    }

    Back() {
        this.location.back(); // <-- go back to previous location on cancel
    }
}
