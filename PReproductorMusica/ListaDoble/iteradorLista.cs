using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PReproductorMusica.ListaDoble
{
    class iteradorLista
    {
        public NodoListDob actual;

        public iteradorLista(clsListaDoble Id)
        {
            actual = Id.cabeza;
        }

        public NodoListDob siguiente()
        {
            NodoListDob a;
            a = actual;
            if (actual != null)
            {
                actual = actual.adelante;
            }
            return a;
        }
    }
}
