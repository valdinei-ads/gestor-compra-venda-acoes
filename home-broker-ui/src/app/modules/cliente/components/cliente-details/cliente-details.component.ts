import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';


import { ClienteService } from '../../cliente.service';
import { Cliente } from '../../cliente';
import { Location } from '@angular/common';

@Component({
    selector: 'app-cliente-details',
    templateUrl: './cliente-details.component.html',
    styleUrls: ['./cliente-details.component.css']
})
export class ClienteDetailsComponent implements OnInit {

    cliente: Cliente;

    constructor(
        private clienteService: ClienteService,
        private route: ActivatedRoute,
        private location: Location) {
        this.cliente = new Cliente();
    }

    ngOnInit() {
        this.route.params.subscribe(params => {
            this.clienteService.GetById(params.id).subscribe((res: any) => {
                this.cliente.idCliente = res.data.idCliente;
                this.cliente.nome = res.data.nome;
                this.cliente.tipoPessoa = res.data.tipoPessoa;
                this.cliente.cpfCnpj = res.data.cpfCnpj;
                this.cliente.dataNascimento = res.data.dataNascimento;
            });
        });
    }

    Back() {
        this.location.back(); // <-- go back to previous location on cancel
    }
}
