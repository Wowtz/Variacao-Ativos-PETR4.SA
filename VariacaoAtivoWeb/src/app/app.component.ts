import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TabelaAtivosComponent } from './features/components/tabela-ativos/tabela-ativos.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, TabelaAtivosComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'VariacaoAtivoWeb';
}
