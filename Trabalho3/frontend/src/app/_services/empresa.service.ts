import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Empresa } from '../_modules/Empresa';


@Injectable({
  providedIn: 'root'
})
export class EmpresaService {
    baseUrl = "https://sistemasdistribuidosfurb.azurewebsites.net/empresa";
    constructor(private http: HttpClient) { }

    adicionarEmpresa(model: Empresa): Observable<any> {
      return this.http.post(`${this.baseUrl}`, model);
    }
    editarEmpresa(model: Empresa): Observable<any> {
      return this.http.put(`${this.baseUrl}`, model);
    }
    excluirEmpresa(idEmpresa: number): Observable<any> {
      return this.http.delete(`${this.baseUrl}/${idEmpresa}`);
    }
    obterEmpresaPorId(idEmpresa: any): Observable<any> {
      return this.http.get<Empresa[]>(`${this.baseUrl}/${idEmpresa}`);
    }
    obterEmpresa(): Observable<Empresa[]> {
      return this.http.get<Empresa[]>(`${this.baseUrl}/GetEmpresas`);
    }
}
