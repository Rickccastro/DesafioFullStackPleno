import { Usuario } from '../Usuario';

export type UsuarioLoginResponse = Pick<Usuario, 'nome' | 'email'>;

export interface LoginResponse {
  usuario: Usuario;  
  token: string;     
}