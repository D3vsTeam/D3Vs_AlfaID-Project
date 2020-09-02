using AlphaId.Dominio.Entidades;
using AlphaId.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlphaId.Infra.Data.InMemory.Repositorios
{
    public class UsuarioRepositorio
    {
        private Contexto contexto;

        public UsuarioRepositorio()
        {
            contexto = new Contexto();
        }

        public void InserirUsuario(Usuario usuario)
        {
            contexto.Add(usuario);
            contexto.SaveChanges();
        }

        public List<Usuario> ListarUsuarios(TipoUsuario tipoUsuario)
        {
            return contexto.Usuarios.Where(w => w.TipoUsuario == tipoUsuario).ToList();
        }

        public Usuario RecuperarPorCpf(string cpf)
        {
            return contexto.Usuarios.SingleOrDefault(w => w.Cpf == cpf);
        }
        public Usuario RecuperarPorCpfESenha(string cpf, string senha)
        {
            return contexto.Usuarios.SingleOrDefault(w => w.Cpf == cpf && w.Senha == senha);
        }
        public Usuario RecuperarPorSenha(string senha)
        {
            return contexto.Usuarios.SingleOrDefault(w => w.Senha == senha);
        }
        public Usuario Tipo(TipoUsuario tipoUsuario)
        {
            return contexto.Usuarios.SingleOrDefault(w => w.TipoUsuario == tipoUsuario);
        }



    }
}
