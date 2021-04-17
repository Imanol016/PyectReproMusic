using PReproductorMusica.clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PReproductorMusica.NewFolder1.obListaOrdenada
{
    public class ListaOrdenada : Lista
    {
        //constructor
        public ListaOrdenada() : base()
        {

        }

        public ListaOrdenada insertaOrden(string entrada)
        {
            Nodo nuevo;
            nuevo = new Nodo(entrada);
            if (primero == null)
            {
                primero = nuevo;
            }
            else if (entrada.CompareTo(primero.getDato())<0)
            {
                nuevo.setEnlace(primero);
                primero = nuevo;
            }
            else
            {
                //Busqueda del nodo anterior, a partir de aqui se hara la insercion
                Nodo anterior, p;
                anterior = p = primero;
                while ((p.getEnlace() != null) && (entrada.CompareTo(p.getDato()))<0)
                {
                    anterior = p;
                    p = p.getEnlace();
                }
                if (entrada.CompareTo(p.getDato())>0)//se inserta despues del ultimo nodo
                {
                    anterior = p;
                }
                nuevo.setEnlace(anterior.getEnlace());
                anterior.setEnlace(nuevo);

            }
            return this;

        }

        public Nodo search(int index)//
        {
            if(index < 0)
            {
                return null;
            }

            int n = 0;
            Nodo aux = primero;
            while (n != index)
            {
                aux = aux.enlace;
                n++;
            }

            return aux;
        }

        public void eliminar(int entrada)
        {
            Nodo actual, anterior;
            bool encontrado;

            Nodo dato = search(entrada);
            actual = primero;
            anterior = null;
            encontrado = false;

            while ((actual != null) && (!encontrado))
            {
                encontrado = (actual.enlace == dato.enlace);

                if (!encontrado)
                {
                    anterior = actual;
                    actual = actual.enlace;
                }
            }// fim while

            //conectar nodo anterior con el siguiente
            if(actual != null)
            {
                if(actual == primero)
                {
                    primero = actual.enlace;
                }
                else
                {
                    anterior.enlace = actual.enlace;
                }
            }
        }//end metodo
    }
}
