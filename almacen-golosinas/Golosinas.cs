using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace almacen_golosinas
{
    public class Golosinas : Almacen
    {
        private List<Producto> _Golosinas;
        public Golosinas()
        {
            _Golosinas = new List<Producto>();
        }
        public override void addProduct(Producto product)
        {
            _Golosinas.Add(product);

        }
        public override List<Producto> getProduct(string product)
        {
            var golosinas = new List<Producto>();
            if (product.Equals(""))
            {
                golosinas = _Golosinas;
            }
            else
            {
                golosinas = _Golosinas.Where(g => g.Name.Equals(product)).ToList();
            }
            return golosinas;
        }
    }
}
