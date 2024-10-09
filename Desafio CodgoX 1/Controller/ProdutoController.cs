using Desafio_CodgoX_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_CodgoX_1.Controller
{
    public class ProdutoController
    {
        private List<Produto> produtos = new List<Produto>();
        private ProdutoView view = new ProdutoView();

        public void InserirProdutos()
        {
            int numeroProdutos = view.PerguntarNumeroProdutos();
            for (int i = 0; i < numeroProdutos; i++)
            {
                Produto produto = view.InserirProduto(i);
                produtos.Add(produto);
                Console.WriteLine("Produto inserido com sucesso!\n");
            }
        }

        public void ExibirProdutos()
        {
            var produtosOrdenados = produtos.Where(p => p.ValorVenda > p.ValorCompra &&
                                                        p.ValorCompra > 0 &&
                                                        p.DataCriacao >= new DateTime(2024, 1, 1) &&
                                                        p.Descricao.Length >= 5)
                                            .OrderBy(t => t.Tipo)
                                            .ToList();

            var produtosSegundoTrimestre = produtos.Where(p => p.DataCriacao >= new DateTime(2024, 4, 1) && p.DataCriacao <= new DateTime(2024, 6, 30)).ToList();

            var produtosMaisLucrativos = produtos.OrderByDescending(p => p.Lucratividade)
                                                 .Take(3)
                                                 .ToList();

            view.ExibirProdutosOrdenados(produtosOrdenados);
            view.ExibirProdutosSegundoTrimestre(produtosSegundoTrimestre);
            view.ExibirProdutosMaisLucrativos(produtosMaisLucrativos);
        }
    }

}
