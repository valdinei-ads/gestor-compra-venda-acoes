import { Component, OnInit } from '@angular/core';
import { OrdemService } from '../../ordem.service';

@Component({
    selector: 'app-ordem-list',
    templateUrl: './ordem-list.component.html',
    styleUrls: ['./ordem-list.component.css']
})
export class OrdemListComponent implements OnInit {

    ordens: [];

    constructor(private ordemService: OrdemService) { }

    ngOnInit() {
        this.ordemService.GetAll().subscribe((res: any) => {
            this.ordens = res.data;
        });
    }
}