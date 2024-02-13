import { Component, Input, input } from '@angular/core';
import { TableModule } from 'primeng/table';
import { AtivoService } from '../../../services/consultar-ativos.service';
import { VariacaoAtivo } from '../../../models/variacao-ativo.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-tabela-ativos',
  standalone: true,
  imports: [TableModule, CommonModule],
  templateUrl: './tabela-ativos.component.html',
  styleUrl: './tabela-ativos.component.scss'
})
export class TabelaAtivosComponent {
  @Input() ativos: VariacaoAtivo[] = [];
}
