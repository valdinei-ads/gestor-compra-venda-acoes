import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class CotacaoService {

    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json',
        })
    };
    url = 'http://localhost:53769/api/v1/cotacao';

    constructor(private httpClient: HttpClient) { }

    GetAll() {
        return this.httpClient.get(this.url);
    }

    GetById(id: number) {
        return this.httpClient.get(this.url + '/' + id);
    }

    Post(cotacao: any) {
        return this.httpClient.post(this.url, JSON.stringify(cotacao), this.httpOptions);
    }

    Put(cotacao: any) {
        return this.httpClient.put(this.url, JSON.stringify(cotacao), this.httpOptions);
    }

    Remove(id: number) {
        return this.httpClient.delete(this.url + '/' + id, this.httpOptions);
    }
}
