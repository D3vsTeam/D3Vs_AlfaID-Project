using AlphaId.Dominio.Entidades;
using AlphaId.Dominio.Enums;
using AlphaId.Infra.Data.InMemory.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaId.Servico
{
    public class UsuarioServico
    {
        private UsuarioRepositorio usuarioRepositorio;

        public UsuarioServico()
        {
            usuarioRepositorio = new UsuarioRepositorio();
        }

        public void Cadastrar(Usuario usuario)
        {
            if (usuario.Cpf.Length != 11)
                throw new Exception("O CPF informado é inválido.");

            if (usuario.Nome.Length < 3)
                throw new Exception("O nome informado deve ser maior do que 3 caracteres.");

            var usuarioJaExiste = usuarioRepositorio.RecuperarPorCpf(usuario.Cpf);

            if (usuarioJaExiste != null)
                throw new Exception("O usuário deste CPF já está cadastrado.");

            usuarioRepositorio.InserirUsuario(usuario);
        }

        public List<Usuario> ListarOperarios()
        {
            return usuarioRepositorio.ListarUsuarios(TipoUsuario.OPERARIO);
        }

        public Usuario Login(string cpf, string senha)
        {
            var usuario = usuarioRepositorio.RecuperarPorCpfESenha(cpf, senha);

            if (usuario == null)
                throw new Exception("Usuário não cadastrado.");
            else
                return usuario;
        }
        public Usuario Confirm(string senha)
        {
            var usuario = usuarioRepositorio.RecuperarPorSenha(senha);

            if (usuario == null)
                throw new Exception("Senha invalida");
            else
                throw new Exception("senha valida");
        }
        public Usuario Tipos(TipoUsuario tipousuario)
        {
            return usuarioRepositorio.Tipo(tipousuario);
        }

    }
}
