using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjrAtiv.Classes
{
    public static class UsuarioLogado 
    {
        public static int Id { get; set; }
        public static string? NomeCorrentista { get; set; }
        public static DateTime? DataNascimento { get; set; }
        public static string? Cidade { get; set; }
        public static string? Endereco { get; set; }
        public static string? Email { get; set; }
        public static string? Telefone { get; set; }
        public static string? Estado { get; set; }
        public static string? Cpf { get; set; }
        public static string? Celular { get; set; }
        public static string? Senha { get; set; }



        public static List<Conta> Contas = new List<Conta>();



        public static void Deslogar()
        {

            
            
        }
    }
}

