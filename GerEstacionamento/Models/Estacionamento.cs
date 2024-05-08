using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerEstacionamento.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo: ");
            string? novoVeiculo = Console.ReadLine();
            if (!String.IsNullOrEmpty(novoVeiculo))
            {
                this.veiculos.Add(novoVeiculo);
                Console.WriteLine($"Veículo com a placa {novoVeiculo} adicionado!");
            }
            else
            {
                Console.WriteLine("Valor inválido.");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo: ");
            string? placa = Console.ReadLine();

            if (!String.IsNullOrEmpty(placa))
            {
                if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
                {
                    Console.WriteLine("Digite a quantidade de hora que o veículo permaneceu no estacionamento: ");
                    int quantHora = Convert.ToInt32(Console.ReadLine());
                    decimal valorTotal = (quantHora * this.precoPorHora) + this.precoInicial;
                    this.veiculos.Remove(placa);

                    Console.WriteLine($"O veículo de placa {placa} foi removido e o preço a pagar é R$ {valorTotal}");
                }
                else
                {
                    Console.WriteLine("O veículo não se encontra no estacionamento.");
                }
            }
            else
            {
                Console.WriteLine("Valor da placa inválido.");
            }
        }

        public void ListarVeiculos()
        {
            if (this.veiculos.Any())
            {
                Console.WriteLine("---- Veículos ----");

                foreach(string veiculo in this.veiculos)
                {
                    Console.WriteLine($"- {veiculo}");
                }
            }
            else
            {
                Console.WriteLine("Não existem veículos no estacionamento.");
            }
        }
    }
}