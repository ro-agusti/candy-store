using System;
using System.Collections.Generic;
using System.Text;

namespace almacen_golosinas
{
    public abstract class Almacen
    {
        public abstract List<Producto> getProduct(string product);
        public abstract void addProduct(Producto product);
    }
}
