using System;

namespace DIO.bank
{
    public class Conta
    {
        private string Nome { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private TipoConta TipoConta { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            if(this.Saldo - valorSaque < (this.Credito *-1))
            {
                Console.WriteLine("Saldo insulficiente para saque!");
                return false;
            }

            this.Saldo -= valorSaque;
            Console.WriteLine($"Saldo atual da conta de {this.Nome} e {this.Saldo}");

            return true;                
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;

            Console.WriteLine($"Saldo atual da conta de {this.Nome} é {this.Saldo}");
        }

        public void Trasnferir(double valorTrasferir, Conta contaDepositar)
        {
            if(this.Sacar(valorTrasferir)){
                contaDepositar.Depositar(valorTrasferir);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Credito " + this.Credito;
            return retorno;
        }
    }
}