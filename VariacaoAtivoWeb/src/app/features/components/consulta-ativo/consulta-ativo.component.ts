import { Component } from '@angular/core';
import { TabelaAtivosComponent } from '../tabela-ativos/tabela-ativos.component';
import { ChartAtivoComponent } from '../chart-ativo/chart-ativo.component';
import { AtivoService } from '../../../services/consultar-ativos.service';
import { VariacaoAtivo } from '../../../models/variacao-ativo.model';

@Component({
  selector: 'app-consulta-ativo',
  standalone: true,
  imports: [TabelaAtivosComponent, ChartAtivoComponent],
  templateUrl: './consulta-ativo.component.html',
  styleUrl: './consulta-ativo.component.scss'
})
export class ConsultaAtivoComponent {
  ativos: VariacaoAtivo[] = [];
  nome: string = "PETR4.SA";

  constructor(private readonly ativoService: AtivoService) {}

  ngOnInit() {
    if(this.nome != null || this.nome != undefined) {
      this.ativoService.consultarAtivo(this.nome).subscribe((response) => {
        this.ativos = response;
      }, error => {
        console.log('error:', error);
      });
    }
  }
}
