import { environment } from '../../../environments/environment';
import { HttpErrorResponse } from '@angular/common/http';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { throwError } from 'rxjs';

@Injectable({
    providedIn: 'root'
})

export class HttpClientService {
    constructor(private http: HttpClient) { }

    get(endPoint: string, id: any): Promise<object> {
        let response = this.http.get(`${environment.backend}/${endPoint}?id=${id}`)
            .toPromise()
            .then(result => result as any)
            .catch(this.handleError);
        return response;
    }

    getAll(endPoint: string): Promise<object> {
        let response = this.http.get(`${environment.backend}/${endPoint}/GetAll`)
            .toPromise()
            .then(result => result as any[])
            .catch(this.handleError);
        return response;
    }

    getDetallePorProducto(endPoint: string, id: any): Promise<object> {
        let response = this.http.get(`${environment.backend}/${endPoint}/GetPorProductoId?id=${id}`)
            .toPromise()
            .then(result => result as any[])
            .catch(this.handleError);
        return response;
    }

    create(endPoint: string, data: any): Promise<object> {
        let response = this.http.post(`${environment.backend}/${endPoint}`, data)
            .toPromise()
            .then(result => result as any)
            .catch(this.handleError);
        return response;
    }

    update(endPoint: string, data: any): Promise<object> {
        let response = this.http.put(`${environment.backend}/${endPoint}`, data)
            .toPromise()
            .then(result => result as any)
            .catch(this.handleError);
        return response;
    }

    private handleError(error: HttpErrorResponse) {
        if (error.error instanceof ErrorEvent) {
            // Ocurre un error al lado del cliente o error de red
            console.error('Ocurrio un error:', error.error.message);
        } else {
            // El Api retorna respuesta no satisfactoria.
            // El cuerpo de la respueta puede contener algo que indique el error.
            console.error(
                `Api retorna codigo ${error.status}, ` +
                `con cuerpo: ${error.message}`);
        }
        // retorna un observable con mensaje de error
        return throwError(
            'Algo ha sucedio un error; favor intentarlo de nuevo más tarde.');
    }
}
