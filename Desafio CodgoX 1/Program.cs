using Desafio_CodgoX_1.Controller;
using Desafio_CodgoX_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using static Desafio_CodgoX_1.Model.Produto;

class Program
{

    

    static void Main(string[] args)
    {

        ProdutoController controller = new ProdutoController();

        controller.InserirProdutos();
        controller.ExibirProdutos();

        Console.ReadLine();
    }
}

