using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace pjrAtiv.Classes
{
    public class Conta
    {

        public int IdConta { get; set; }
        public int IdCliente { get; set; }

        public double Saldo { get; set; }
        public string? Status { get; set; }
        public double Limite { get; set; }

        public DateTime DataAbertura { get; set; }
        public DateTime DataEncerramento { get; set; }

        public Conta() 
        { 
            
            
        
        }
        public delegate void teste(int conta);
        public double Depositar(double ValorDeposito) 
        {

            this.Saldo += ValorDeposito;
            return this.Saldo;
        
        
        
        }
        
        
    }
}
