using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafiCS
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }

        public class Nodo
        {
            private object Data;

            public Nodo(object _data)
            {
                Data = _data;
            }

            public object _data
            {
                get { return Data; }
            }
        }

        public class Arco
        {
            private int Peso;
            private Nodo Src;
            private Nodo Dest;

            public Arco(Nodo _src, Nodo _dest) : this(1, _src, _dest) { }

            public Arco(int _peso, Nodo _src, Nodo _dest)
            {
                Peso = _peso;
                Src = _src;
                Dest = _dest;
            }

            public int _peso
            {
                get { return Peso; }
                protected set { Peso = value; }
            }

            public Nodo _src
            {
                get { return Src; }
                protected set { Src = value; }
            }

            public Nodo _dest
            {
                get { return _dest; }
                protected set {  Dest = value; }
            }
        }

        public class Grafo
        {
            private List<Nodo> Nodi;
            private List<Arco> Archi;

            public Nodo AggiungiNodo(Nodo _nodo)
            {
                Nodi.Add(_nodo);
                return _nodo;
            }

            public void Collega(int _peso, Nodo _src, Nodo _dest)
            {
                Arco _arco = new Arco(_peso, _src, _dest);
                Archi.Add(_arco);
            }
        }
    }
}
