using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiron.LojaVirtual.Dominio.Entidades;

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
