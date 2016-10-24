using Quiron.LojaVirtual.Dominio.Entidades;
using System.Collections.Generic;

namespace Quiron.LojaVirtual.Web.Models
{
    public class ProdutosViewModel
    {
        public IEnumerable<Produto> Produtos { get; set; }
        public Paginacao Paginacao { get; set; }
        public string CategoriaAtual { get; set; }

    }
}