using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_CodgoX_1.Model
{
    public class Produto
    {
        public enum TipoProduto
        {
            Final,
            Intermediario,
            Consumo,
            MateriaPrima
        }
        public string Descricao { get; set; }
        public double ValorVenda { get; set; }
        public double ValorCompra { get; set; }
        public TipoProduto Tipo { get; set; }
        public DateTime DataCriacao { get; set; }
        public double Lucratividade => ValorVenda - ValorCompra;
        
    }
}
