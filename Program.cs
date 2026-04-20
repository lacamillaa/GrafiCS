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
            private int Src;
            private int Dest;

            public Arco(int _src, int _dest) : this(1, _src, _dest) { }

            public Arco(int _peso, int _src, int _dest)
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

            public int _src
            {
                get { return Src; }
                protected set { Src = value; }
            }

            public int _dest
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

            public void Collega(int _peso, int _src, int _dest)
            {
                Arco _arco = new Arco(_peso, _src, _dest);
                Archi.Add(_arco);
            }

            // rappresentazioni del grafo
            public List<int>[] ListaAdiacenza()
            {
                // lista di nodi adiacenti a ogni nodo
                List<int>[] res = new List<int>[Nodi.Count];
                foreach (Arco _arco in Archi)
                {
                    res[_arco._src].Add(_arco._dest);
                }
                return res;
            }

            public bool[,] MatriceAdiacenza()
            {
                bool[,] res = new bool[Nodi.Count, Nodi.Count];
                List<int>[] _listaAdj = ListaAdiacenza();
                for (int n = 0; n < _listaAdj.Length; n++)
                {
                    foreach (int _neighbor in _listaAdj[n])
                    {
                        res[n, _neighbor] = true;
                    }
                }
                return res;
            }

            public void BFSVisita(int _start)
            {
                var _listaAdj = ListaAdiacenza();
                bool[] _visitato = new bool[Nodi.Count];
                Queue<int> _vicini = new Queue<int>();
                _vicini.Enqueue(_start);
                while (_vicini.Count > 0)
                {
                    int _top = _vicini.Dequeue();
                    _visitato[_top] = true;
                    Console.WriteLine(Nodi[_top]._data);
                    foreach (int _vicino in _listaAdj[_top])
                    {
                        if (!_visitato[_vicino])
                        {
                            _vicini.Enqueue(_vicino);
                        }
                    }
                }
            }

            public void DFSVisita(int _start)
            {
                var _listaAdj = ListaAdiacenza();
                bool[] _visitato = new bool[Nodi.Count];
                Stack<int> _vicini = new Stack<int>();
                _vicini.Push(_start);
                while( _vicini.Count > 0)
                {
                    int _top = _vicini.Pop();
                    _visitato[_top] = true;
                    Console.WriteLine(Nodi[_top]._data);
                    foreach (int _vicino in _listaAdj[_top])
                    {
                        if (!_visitato[_vicino])
                        {
                            _vicini.Push(_vicino);
                        }
                    }
                }
            }

            public List<int> TopologicalSort()
            {
                List<int> res = new List<int>();
                var _listaAdj = ListaAdiacenza();
                // crea array con gradi entranti
                int[] _indegrees = new int[Nodi.Count];
                Stack<int> _daVisitare = new Stack<int>();
                foreach (Arco _arco in Archi)
                {
                    _indegrees[_arco._dest]++;
                }
                for (int n = 0; n < Nodi.Count; n++)
                {
                    // prendi i nodi con grado entrante 0
                    if (_indegrees[n] == 0)
                    {
                        _daVisitare.Push(n);
                    }
                }
                bool[] _visitato = new bool[Nodi.Count];
                while (_daVisitare.Count > 0)
                {
                    var _top = _daVisitare.Pop();
                    _visitato[_top] = true;
                    res.Add(_top);
                    foreach (int _vicino in _listaAdj[_top])
                    {
                        if (!_visitato[_vicino] && --_indegrees[_vicino] == 0)
                        {
                            _daVisitare.Push(_vicino);
                        }
                    }
                }
                return res;
            }
        }
    }
}
