using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PReproductorMusica.ListaDoble
{
    public class NodoListDob
    {
        public string dato;
        public NodoListDob adelante;
        public NodoListDob atras;

        //public int getDato()
        //{
        //    return dato;
        //}
        
        public NodoListDob(string entrada)
        {
            dato = entrada;
            adelante = atras = null;
        }
    }
}
