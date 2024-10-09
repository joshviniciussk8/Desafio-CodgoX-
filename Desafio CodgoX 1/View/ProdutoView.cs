using Desafio_CodgoX_1.Model;
using System;
using System.Collections.Generic;
using static Desafio_CodgoX_1.Model.Produto;


public class ProdutoView
{
    public int PerguntarNumeroProdutos()
    {
        int numeroProdutos;
        Console.WriteLine("Quantos produtos você deseja inserir?");
        while (!int.TryParse(Console.ReadLine(), out numeroProdutos))
        {
            Console.WriteLine("Valor inválido, insira um número inteiro:");
        }
        return numeroProdutos;
    }

    public Produto InserirProduto(int indice)
    {
        Console.WriteLine($"Insira os dados do produto {indice + 1}:");
        var produto = new Produto();
        do
        {
            Console.Write("Descrição (mínimo 5 caracteres): ");
            produto.Descricao = Console.ReadLine();
        } while (produto.Descricao.Length < 5);

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
            } while (!CompraIsValid || valorCompra<=0);           
            do
            {
                Console.Write("Valor de Venda (deve ser maior que Valor de Compra): ");
                string valorVendaString = Console.ReadLine();
                VendaIsValid = double.TryParse(valorVendaString, out valorVenda);
                if (!VendaIsValid) Console.Write("\nErro: Valor inválido\n ");
            } while (!VendaIsValid);
            


            if (valorVenda <= valorCompra) Console.WriteLine("Erro: O valor de venda deve ser maior que o valor de compra!");

            if (!CompraIsValid) Console.WriteLine("Erro: O Valor de compra não é válido");
            if (!VendaIsValid) Console.WriteLine("Erro: O Valor de Venda não é válido");


        } while (valorCompra <= 0 || valorVenda <= valorCompra);
        produto.ValorCompra = valorCompra;
        produto.ValorVenda = valorVenda;

        bool DataIsValid;
        DateTime dataCriacao;

        do
        {
            Console.Write("Data de Criação (Deve ser igual ou superior a 01/01/2024), Não pode cadastrar uma data Maior que a atual: ");
            string dataCriacaoString = Console.ReadLine();
            DataIsValid = DateTime.TryParse(dataCriacaoString, out dataCriacao);
        }
        while (dataCriacao < new DateTime(2024, 1, 1) || !DataIsValid || dataCriacao>DateTime.Now);
        produto.DataCriacao = dataCriacao;
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
            if (!TipoIsValid || ((int)tipo) > TotalTipo || ((int)tipo) < 0) Console.WriteLine("Erro: Tipo do Produto Inválido");
        } while (!TipoIsValid || ((int)tipo) > TotalTipo || ((int)tipo) < 0);
        produto.Tipo = tipo;

        return produto;
    }

    public void ExibirProdutosOrdenados(IEnumerable<Produto> produtos)
    {
        Console.WriteLine("\nProdutos ordenados por tipo:");
        foreach (var produto in produtos)
        {
            Console.WriteLine($"Tipo: {produto.Tipo}, Descrição: {produto.Descricao}, Valor Compra {produto.ValorCompra:C2} ,Valor Venda: {produto.ValorVenda:C2}");
        }
    }

    public void ExibirProdutosSegundoTrimestre(IEnumerable<Produto> produtos)
    {
        Console.WriteLine("\nProdutos criados no segundo trimestre de 2024:");
        foreach (var produto in produtos)
        {
            Console.WriteLine($"Descrição: {produto.Descricao}, Data Criação: {produto.DataCriacao:dd/MM/yyyy}");
        }
    }

    public void ExibirProdutosMaisLucrativos(IEnumerable<Produto> produtos)
    {
        Console.WriteLine("\nOs produtos mais lucrativos:");
        foreach (var produto in produtos)
        {
            Console.WriteLine($"Descrição: {produto.Descricao}, Lucro: {produto.Lucratividade:C2}");
        }
    }
}
