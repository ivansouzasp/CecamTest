import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

const baseUrl = 'http://localhost:4200/api';

@Injectable({
    providedIn: 'root'
  })
  export class ClienteService {
    constructor(private http: HttpClient) { }

     getAll(): Observable<any> {
        return this.http.get(`${baseUrl}/Cliente/GetAll`);
      }
    
      get(id: number): Observable<any> {
        return this.http.get(`${baseUrl}/Cliente/${id}`);
      }
    
      create(data: any): Observable<any> {
        return this.http.post(`${baseUrl}/Cliente/AddCliente`, data);
      }
    
      update(id: number, data: any): Observable<any> {
        return this.http.put(`${baseUrl}/Cliente/UpdateCliente`, data);
      }

      delete(id: number): Observable<any> {
        return this.http.delete(`${baseUrl}/Cliente/${id}`);
      }
  }
