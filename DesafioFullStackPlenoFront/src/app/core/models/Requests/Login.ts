import { Usuario } from "../Usuario";

export type Login = Pick<Usuario, 'email' | 'senha'>;
