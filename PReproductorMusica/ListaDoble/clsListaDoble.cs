using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PReproductorMusica.ListaDoble
{
    public class clsListaDoble
    {
        public NodoListDob primero;
        public NodoListDob ultimo;
        public NodoListDob cabeza; //es el nodo que se llama primero

        public clsListaDoble()
        {
            cabeza = null;
        }

        public clsListaDoble insertarCabezaLista(string entrada)
        {

            NodoListDob nuevo;
            nuevo = new NodoListDob(entrada);
            nuevo.adelante = cabeza;
            if (cabeza != null)
            {
                cabeza.atras = nuevo;
            }
            cabeza = nuevo;
            return this;
        }

        public clsListaDoble insertaDespues(NodoListDob anterior, string entrada)
        {
            NodoListDob nuevo;
            nuevo = new NodoListDob(entrada);
            nuevo.adelante = anterior.adelante;
            if (anterior.adelante != null)
            {
                anterior.adelante.atras = nuevo;

            }
            anterior.adelante = null;
            nuevo.atras = anterior;
            return this;
        }

        public void eliminar(string entrada)
        {
            NodoListDob actual;
            bool encontrado = false;
            actual = cabeza;

            //blucle de busqueda
            while ((actual != null) && (!encontrado))
            {
                encontrado = (actual.dato == entrada);
                if (!encontrado)
                {
                    actual = actual.adelante;

                }

            }

            //enlace del nodo anterior con el siguiente
            if (actual != null)
            {
                //disntinguir entre nodo cabecera del resto de la lista
                if (actual == cabeza)
                {
                    cabeza = actual.adelante;
                    if (actual.adelante != null)
                    {
                        actual.adelante.atras = null;
                    }
                }
                else if (actual.adelante != null)
                {//quiere decir que no es el ultimo nodo
                    actual.atras.adelante = actual.adelante;
                    actual.adelante.atras = actual.atras;
                }
                else
                {//ultimo nodo
                    actual.atras.adelante = null;
                }
                actual = null;
            }

        }

        public void visualizar()
        {
            NodoListDob n;
            n = cabeza;
            while (n != null)
            {
                Console.WriteLine(n.dato + "\n");
                n = n.adelante;

            }
        }

        public void insert(String name)
        {
            NodoListDob nuevo;
            nuevo = new NodoListDob(name);
            if (primero == null)
            {
                primero = nuevo;
                primero.adelante = null;
                primero.atras = null;
                ultimo = primero;
            }
            else
            {
                ultimo.adelante = nuevo;
                nuevo.adelante = null;
                nuevo.atras = ultimo;
                ultimo = nuevo;
            }
        }
    }
}
