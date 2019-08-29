import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ClienteService } from '../../cliente.service';
import { ToastrService } from 'ngx-toastr';


@Component({
    selector: 'app-cliente-list',
    templateUrl: './cliente-list.component.html',
    styleUrls: ['./cliente-list.component.css']
})
export class ClienteListComponent implements OnInit {

    clientes: [];

    constructor(private clienteService: ClienteService, private toastrService: ToastrService) { }

    ngOnInit() {
        this.clienteService.GetAll().subscribe((res: any) => {
            this.clientes = res.data;
        });
    }

    delete(id: number) {
        this.clienteService.Delete(id).subscribe(
            data => {
                this.toastrService.success('Cliente removido com sucesso!!!', 'Sucesso');
                this.clienteService.GetAll().subscribe((responseList: any) => {
                    this.clientes = responseList.data;
                });
            },
            error => {
                error.error.forEach(element => {
                    this.toastrService.error(element.Message, 'Erro');
                });
            }
        );
    }
}
