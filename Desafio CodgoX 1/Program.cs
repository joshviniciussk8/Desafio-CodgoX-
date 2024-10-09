using System;
using System.Collections.Generic;
using System.Linq;

class Program
{

    public enum TipoProduto
    {
        Final,
        Intermediario,
        Consumo,
        MateriaPrima
    }
    public class Produto
    {
        public string Descricao { get; set; }
        public double ValorVenda { get; set; }
        public double ValorCompra { get; set; }
        public TipoProduto Tipo { get; set; }
        public DateTime DataCriacao { get; set; }
        public double Lucratividade => ValorVenda - ValorCompra;
    }

    static void Main(string[] args)
    {
        
        List<Produto> produtos = new List<Produto>();

        int numeroProdutos = 0;

        Console.WriteLine("Quantos produtos você deseja inserir?");
        bool valorValido = false;
        while (!valorValido)
        {
            try
            {
                numeroProdutos = int.Parse(Console.ReadLine());
                valorValido = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ops Você digitou um valor inválido, \nQuantos produtos você deseja inserir?");
            }
        }
        for (int i = 0; i < numeroProdutos; i++)
        {
            Console.WriteLine($"Insira os dados do produto {i + 1}:");
            string descricao;
            do
            {
                Console.Write("Descrição (mínimo 5 caracteres): ");
                descricao = Console.ReadLine();
            }
            while (descricao.Length < 5);

            bool CompraIsValid;
            bool VendaIsValid;
            double valorCompra, valorVenda;
            do
            {
                do
                {
                    Console.Write("Valor de Compra (deve ser maior que zero): ");
                    string valorCompraString = Console.ReadLine();
                    CompraIsValid = double.TryParse(valorCompraString, out valorCompra);
                    if (!CompraIsValid) Console.Write("\nErro: Valor inválido \n");
                } while (!CompraIsValid);

                do
                {
                    Console.Write("Valor de Venda (deve ser maior que Valor de Compra): ");
                    string valorVendaString = Console.ReadLine();
                    VendaIsValid = double.TryParse(valorVendaString, out valorVenda);
                    if(!VendaIsValid) Console.Write("\nErro: Valor inválido\n ");
                } while (!VendaIsValid);

                

                if (valorVenda <= valorCompra) Console.WriteLine("Erro: O valor de venda deve ser maior que o valor de compra!");
                
                if (!CompraIsValid) Console.WriteLine("Erro: O Valor de compra não é válido");
                if (!VendaIsValid) Console.WriteLine("Erro: O Valor de Venda não é válido");


            } while (valorCompra <= 0 || valorVenda <= valorCompra );

            bool DataIsValid;
            DateTime dataCriacao;
            
            do
            {
                Console.Write("Data de Criação (Deve ser igual ou superior a 01/01/2024): ");
                string dataCriacaoString = Console.ReadLine();
                DataIsValid = DateTime.TryParse(dataCriacaoString, out dataCriacao);
            }
            while (dataCriacao < new DateTime(2024, 1, 1) || !DataIsValid);

            bool TipoIsValid;
            TipoProduto tipo;
            string tipoString;
            int TotalTipo;
            do
            {
                Console.WriteLine("Escolha o Tipo do Produto: (0 = Final, 1 = Intermediario, 2 = Consumo, 3 = MateriaPrima)");
                tipoString = Console.ReadLine();
                TipoIsValid = TipoProduto.TryParse(tipoString, out tipo);
                TotalTipo = Enum.GetValues(typeof(TipoProduto)).Length - 1;
                if (!TipoIsValid || ((int)tipo) > TotalTipo || ((int)tipo)<0) Console.WriteLine("Erro: Tipo do Produto Inválido");
            } while (!TipoIsValid || ((int)tipo)> TotalTipo || ((int)tipo) < 0);
            

            
            produtos.Add(new Produto
            {
                Descricao = descricao,
                ValorCompra = valorCompra,
                ValorVenda = valorVenda,
                Tipo = tipo,
                DataCriacao = dataCriacao
            });

            Console.WriteLine("Produto inserido com sucesso!\n");
        }
        var produtosOrdenados = produtos.Where(p => p.ValorVenda > p.ValorCompra &&
                                                  p.ValorCompra > 0 &&
                                                  p.DataCriacao >= new DateTime(2024, 1, 1) &&
                                                  p.Descricao.Length >= 5).OrderBy(t => t.Tipo).ToList();

        var produtosSegundoTrimestre = produtos.Where((p) => p.DataCriacao >= new DateTime(2024, 6, 1)).ToList();

        var produtosMaisLucrativos = produtos
            .OrderByDescending(p => p.Lucratividade)
            .Take(3) 
            .ToList();

        Console.WriteLine("\nTodos os Produtos ordenados por tipo");
        foreach (var produto in produtosOrdenados)
        {
            Console.WriteLine($"Tipo: {produto.Tipo} " +
                              $"Descrição: {produto.Descricao} " +
                              $"Valor Compra: R${produto.ValorCompra:F2} " +
                              $"Valor Venda: R${produto.ValorVenda:F2} " +
                              $"Data Criação: {produto.DataCriacao:dd/MM/yyyy}");
        }

        Console.WriteLine("\nProdutos Criados no Segundo Trimestre de 2024:");
        foreach (var produto in produtosSegundoTrimestre)
        {
            Console.WriteLine($"Descrição: {produto.Descricao} " +
                              $"Valor Compra: R${produto.ValorCompra:F2} " +
                              $"Valor Venda: R${produto.ValorVenda:F2} " +
                              $"Tipo: {produto.Tipo}, " +
                              $"Data Criação: {produto.DataCriacao:dd/MM/yyyy}");
        }

        Console.WriteLine("\nOs 3 Produtos mais Lucrativos:");
        foreach (var produto in produtosMaisLucrativos)
        {
            Console.WriteLine($"Descrição: {produto.Descricao} " +
                              $"Valor Compra: R${produto.ValorCompra:F2} " +
                              $"Valor Venda: R${produto.ValorVenda:F2} " +
                              $"Tipo: {produto.Tipo} " +
                              $"Lucro: R${produto.Lucratividade:F2} " +
                              $"Data Criação: {produto.DataCriacao:dd/MM/yyyy}");
        }


    Console.ReadLine();
    }
}

