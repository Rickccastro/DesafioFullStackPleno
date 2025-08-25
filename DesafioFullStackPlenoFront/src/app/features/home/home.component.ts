import { Component, inject, OnInit, signal } from '@angular/core'; 
import { ChartOptions, ChartType, ChartData } from 'chart.js';
import { BaseChartDirective } from 'ng2-charts';
import { TarefasService } from '../../shared/services/tarefas.service';
import { UsuarioService } from '../../shared/services/usuario.service';
import { ActivatedRoute } from '@angular/router';
import { Tarefas } from '../../core/models/Tarefas';
import { Usuario } from '../../core/models/Usuario';

@Component({
  selector: 'app-home',
  imports: [BaseChartDirective],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
})
export class HomeComponent implements OnInit {
  tarefaService = inject(TarefasService);
  usuarioService = inject(UsuarioService);
  private route = inject(ActivatedRoute);
  listaUsuarios = signal<Usuario[]>([]);
  listaTarefas = signal<Tarefas[]>([]);

  // --- Gráfico 1: Número de tarefas por status ---
  public tarefasStatusChartType: ChartType = 'pie';
  public tarefasStatusChartData: ChartData<'pie'> = { labels: [], datasets: [] };
  public tarefasStatusChartOptions: ChartOptions = { responsive: true };

  // --- Gráfico 2: Últimas 5 tarefas criadas ---
  public ultimasTarefasChartType: ChartType = 'bar';
  public ultimasTarefasChartData: ChartData<'bar'> = { labels: [], datasets: [] };
  public ultimasTarefasChartOptions: ChartOptions = { responsive: true };

  ngOnInit(): void {
    this.route.data.subscribe((data) => {
      const usuarios: Usuario[] = data['usuarios'];
      const tarefas: Tarefas[] = data['tarefas'];

      this.listaUsuarios.set(usuarios);
      this.listaTarefas.set(tarefas);

      this.configurarGraficos(tarefas);
    });
  }

  private configurarGraficos(tarefas: Tarefas[]) {
    // --- Gráfico 1: Número de tarefas por status ---
    const statusCounts = tarefas.reduce((acc, t) => {
      acc[t.status] = (acc[t.status] || 0) + 1;
      return acc;
    }, {} as Record<string, number>);

    this.tarefasStatusChartData = {
      labels: Object.keys(statusCounts),
      datasets: [
        {
          data: Object.values(statusCounts),
          backgroundColor: ['#4CAF50', '#FF9800', '#2196F3'],
        },
      ],
    };
    this.tarefasStatusChartOptions = {
      responsive: true,
      plugins: { legend: { position: 'top' } },
    };

    // --- Gráfico 2: Últimas 5 tarefas criadas ---
    const ultimasCinco = [...tarefas]
      .sort((a, b) => new Date(b.dataCriacao).getTime() - new Date(a.dataCriacao).getTime())
      .slice(0, 5);

    this.ultimasTarefasChartData = {
      labels: ultimasCinco.map((t) => t.titulo),
      datasets: [
        {
          label: 'Últimas 5 tarefas',
          data: ultimasCinco.map(() => 1), // cada tarefa conta como 1
          backgroundColor: '#42A5F5',
        },
      ],
    };
    this.ultimasTarefasChartOptions = {
      responsive: true,
      plugins: { legend: { display: false } },
    };
  }
}
