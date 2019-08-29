import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl } from '@angular/forms';

import { ClienteService } from '../../cliente.service';
import { ToastrService } from 'ngx-toastr';
import { Location } from '@angular/common';

@Component({
    selector: 'app-cliente-edit',
    templateUrl: './cliente-edit.component.html',
    styleUrls: ['./cliente-edit.component.css']
})
export class ClienteEditComponent implements OnInit {

    formulario: FormGroup;
    tiposPessoa: Array<any> = [
        { value: '', text: '' },
        { value: 'F', text: 'Pessoa Fisica' },
        { value: 'J', text: 'Pessoa Juridica' }
    ];
    tipoPessoaSelecionada: string;

    constructor(
        private clienteService: ClienteService,
        private toastrService: ToastrService,
        private router: Router,
        private route: ActivatedRoute,
        private location: Location) {

        this.formulario = new FormGroup({
            idCliente: new FormControl(),
            nome: new FormControl(),
            cpfCnpj: new FormControl(),
            tipoPessoa: new FormControl(),
            dataNascimento: new FormControl()
        });
    }

    ngOnInit() {
        this.route.params.subscribe(
            (params: any) => {
                this.clienteService.GetById(params.id).subscribe((res: any) => {
                    this.tipoPessoaSelecionada = res.data.tipoPessoa;
                    this.formulario.setValue({
                        idCliente: res.data.idCliente,
                        nome: res.data.nome,
                        cpfCnpj: res.data.cpfCnpj,
                        tipoPessoa: res.data.tipoPessoa,
                        dataNascimento: res.data.dataNascimento
                    });
                });
            }
        );
    }

    onSubmit() {
        this.clienteService.Put(this.formulario.value)
            .subscribe(
                data => {
                    this.toastrService.success('Cliente atualizado com sucesso!!!', 'Sucesso').onHidden.subscribe(() => {
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
