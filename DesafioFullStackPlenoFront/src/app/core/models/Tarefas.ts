import { Usuario } from "./Usuario";

export interface Tarefas {
  id: string;
  titulo: string;
  descricao: string;
  usuarioId: string;
  dataCriacao: string;
  status: string;
}