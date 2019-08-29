import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class ClienteService {

    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json',
        })
    };

    url = 'http://localhost:53769/api/v1/cliente';

    constructor(private httpClient: HttpClient) { }

    GetAll() {
        return this.httpClient.get(this.url);
    }

    GetById(id: number) {
        return this.httpClient.get(this.url + '/' + id);
    }

    Post(cliente: any) {
        return this.httpClient.post(this.url, JSON.stringify(cliente), this.httpOptions);
    }

    Put(cliente: any) {
        console.log(cliente);
        return this.httpClient.put(this.url, JSON.stringify(cliente), this.httpOptions);
    }

    Delete(id: number) {
        return this.httpClient.delete(this.url + '/' + id, this.httpOptions);
    }
}
