import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { ChartModule } from 'primeng/chart';
import { VariacaoAtivo } from '../../../models/variacao-ativo.model';

@Component({
  selector: 'app-chart-ativo',
  standalone: true,
  imports: [ChartModule],
  templateUrl: './chart-ativo.component.html',
  styleUrl: './chart-ativo.component.scss'
})

export class ChartAtivoComponent implements OnChanges {
  @Input() ativos: VariacaoAtivo[] = [];
  data: any;
  options: any;
  valores: number[] = [];
  variacaoD1: number[] = [];
  variacaoInicio: number[] = [];
  dias: number[] = [];

  ngOnChanges(changes: SimpleChanges) {
    if (changes['ativos'] && changes['ativos'].currentValue) {
      this.montarValoresAtivos();
      this.montarGrafico();
    }
  }

  montarGrafico() {
      const documentStyle = getComputedStyle(document.documentElement);
      const textColor = documentStyle.getPropertyValue('--text-color');
      const textColorSecondary = documentStyle.getPropertyValue('--text-color-secondary');
      const surfaceBorder = 'grey';

      this.montarValoresAtivos();

      this.data = {
          labels: this.dias,
          datasets: [
              {
                  label: 'Valor',
                  data: this.valores,
                  fill: false,
                  borderColor: documentStyle.getPropertyValue('--pink-500'),
                  tension: 0.4
              },
              {
                  label: 'Variação em relaçào a D-1',
                  data: this.variacaoD1,
                  fill: false,
                  borderColor: documentStyle.getPropertyValue('--blue-500'),
                  tension: 0.4
              },
              {
                  label: 'Variação em relação a primeira data',
                  data: this.variacaoInicio,
                  fill: false,
                  borderColor: documentStyle.getPropertyValue('--green-500'),
                  tension: 0.4
              }
          ]
      };

      this.options = {
          maintainAspectRatio: false,
          aspectRatio: 0.6,
          plugins: {
              legend: {
                  labels: {
                      color: textColor
                  }
              }
          },
          scales: {
              x: {
                  ticks: {
                      color: textColorSecondary
                  },
                  grid: {
                      color: surfaceBorder,
                      drawBorder: false
                  }
              },
              y: {
                  ticks: {
                      color: textColorSecondary
                  },
                  grid: {
                      color: surfaceBorder,
                      drawBorder: false
                  }
              }
          }
      };
  }

  private montarValoresAtivos(): void {
    this.valores = [];
    this.variacaoD1 = [];
    this.variacaoInicio = [];
    this.dias = [];
  
    this.ativos.forEach(ativo => {
      this.dias.push(ativo.Dia)
      this.valores.push(ativo.Valor);
      this.variacaoD1.push(ativo.VariacaoD1);
      this.variacaoInicio.push(ativo.VariacaoInicio);
    });
  }
}
