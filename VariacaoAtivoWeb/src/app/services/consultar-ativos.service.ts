import { HttpClient } from "@angular/common/http";
import { Observable, take } from "rxjs";
import { VariacaoAtivo } from "../models/variacao-ativo.model";
import { Injectable } from "@angular/core";
import { environment } from "../../enviroments/enviroment";

@Injectable({
  providedIn: 'root',
})

export class AtivoService {
  url = environment.apiUrl

  private URLs = {
    consultarAtivo: (nome: string) => `${this.url}v1/VariacaoAtivos/${nome}`
  };

  constructor(private http: HttpClient) {}

  public consultarAtivo(nome: string): Observable<VariacaoAtivo[]> {
    return this.http.get<VariacaoAtivo[]>(this.URLs.consultarAtivo(nome)).pipe(take(1));
  }
}