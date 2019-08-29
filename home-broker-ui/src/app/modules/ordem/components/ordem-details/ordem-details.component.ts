import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { OrdemService } from '../../ordem.service';

@Component({
    selector: 'app-ordem-details',
    templateUrl: './ordem-details.component.html',
    styleUrls: ['./ordem-details.component.css']
})
export class OrdemDetailsComponent implements OnInit {

    id: number;
    ordem: any;

    constructor(
        private ordemService: OrdemService,
        private route: ActivatedRoute,
        private location: Location
    ) { }


    ngOnInit() {
        this.route.params.subscribe(params => { this.id = params.id; });
        this.ordemService.GetById(this.id).subscribe((res: any) => { this.ordem = res.data; });
    }

    Back() {
        this.location.back(); // <-- go back to previous location on cancel
    }
}
