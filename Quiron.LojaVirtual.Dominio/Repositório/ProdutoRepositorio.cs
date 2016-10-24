using Quiron.LojaVirtual.Dominio.Entidades;
using System.Collections.Generic;

namespace Quiron.LojaVirtual.Dominio.Repositório
{
    public class ProdutoRepositorio
    {
        private readonly EfDbContext _context = new EfDbContext();
        public IEnumerable<Produto> Produto
        {
            get { return _context.Produto; }
        }
    }
}
