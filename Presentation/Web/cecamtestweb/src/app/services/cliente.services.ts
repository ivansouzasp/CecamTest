import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

const baseUrl = 'http://localhost:4200';

@Injectable({
    providedIn: 'root'
  })
  export class ClienteService {
    constructor(private http: HttpClient) { }

     getAll(): Observable<any> {
        return this.http.get(`${baseUrl}/api/Cliente/GetAll`);
      }
    
      get(id: number): Observable<any> {
        return this.http.get(`${baseUrl}/api/Cliente/${id}`);
      }
    
      create(data: any): Observable<any> {
        return this.http.post(`${baseUrl}/api/Cliente/AddCliente`, data);
      }
    
      update(id: number, data: any): Observable<any> {
        return this.http.put(`${baseUrl}/api/Cliente/UpdateCliente`, data);
      }

      delete(id: number): Observable<any> {
        return this.http.delete(`${baseUrl}/api/Cliente/${id}`);
      }
  }
