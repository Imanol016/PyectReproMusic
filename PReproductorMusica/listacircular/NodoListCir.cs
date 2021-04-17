using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PReproductorMusica.listacircular
{
    public class NodoListCir
    {
        public String dato;
        public NodoListCir enlace;

        public NodoListCir(String entrada)
        {
            dato = entrada;
            enlace = this; // se apunta asímismo

        }
    }
}
