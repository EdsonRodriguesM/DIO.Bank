using System;
using System.Collections.Generic;

namespace DIO.bank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            var opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break; 
                    case "3":
                        Trasnferir();
                        break; 
                    case "4":
                        SacarConta();
                        break; 
                    case "5":
                        Depositar();
                        break; 
                    case "C":
                    Console.Clear();
                        break; 
                    default:
                        throw new ArgumentOutOfRangeException(); 
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");

            if(listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta encontrada");
                return;
            }

            for(int i = 0; i < listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                Console.Write($"#{i} - ");
                Console.WriteLine(conta);
            }
                
        }

         private static void Depositar()
        {
            Console.WriteLine("Digite o numero da conta");
            var conta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor para deposito");
            var valorDeposito = double.Parse(Console.ReadLine());

            listaContas[conta].Depositar(valorDeposito);
        }

        private static void Trasnferir()
        {
            Console.WriteLine("Digite o numero da conta de origem");
            var contaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o numero da conta de Destino");
            var contaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser trasnferido");
            var valorTrasferir = double.Parse(Console.ReadLine());

            listaContas[contaOrigem].Trasnferir(valorTrasferir, listaContas[contaDestino]);
        }

        private static void SacarConta()
        {
            Console.WriteLine("Digite o numero da conta");
            var conta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser sacado");
            var valorSaque = double.Parse(Console.ReadLine());

            listaContas[conta].Sacar(valorSaque);
        }
        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.WriteLine("Digite 1 para conta pessoa fisica ou 2 para Juridica");
            var entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do cliente");
            var nomeCliente = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial");
            var saldoAtual = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o credito");
            var entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta, saldo: saldoAtual, credito: entradaCredito, nome: nomeCliente);

            listaContas.Add(novaConta);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1- ListarContas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Trasnferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
