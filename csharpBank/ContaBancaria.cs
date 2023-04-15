using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpBank
{
    public class ContaBancaria
    {
        public long NumeroDaConta { get; private set; }
        public string NomeTitular { get; private set; }
        public double ContaSaldo { get; private set; }

        public static long QuantidadeDeContas { get; private set;}
        public ContaBancaria(string nomeTitular, double contaSaldo)
        {
            NumeroDaConta++;
            QuantidadeDeContas++;
            NomeTitular = nomeTitular;
            ContaSaldo = contaSaldo;
        }
        public string DepositarValor(double valor)
        {
            if (valor < 0)
                throw new ArgumentException("O valor depositado não pode ser negativo");
            else
                ContaSaldo += valor;
                return "Valor depositado: R$"+valor;
        }

        public string SacarValor(double valor)
        {
            ContaSaldo -= valor;
            return "Valor sacado: R$"+valor;
        }

        public string TransferirValor(double valor, ContaBancaria contaDestino)
        {
            if (valor < 0)
                throw new ArgumentException("O valor transferido não pode ser negativo!");
            else
                ContaSaldo -= valor;
                contaDestino.DepositarValor(valor);
            return "Valor R$" + valor + " transferido para conta " + contaDestino.NumeroDaConta + " com sucesso!";
        }
    }
}
