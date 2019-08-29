import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class OrdemService {

    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json',
        })
    };
    url = 'http://localhost:53769/api/v1/ordem';

    constructor(private httpClient: HttpClient) { }

    GetAll() {
        return this.httpClient.get(this.url);
    }

    GetById(id: number) {
        return this.httpClient.get(this.url + '/' + id);
    }

    Post(ordem: any) {
         return this.httpClient.post(this.url, JSON.stringify(ordem), this.httpOptions);
    }
}
