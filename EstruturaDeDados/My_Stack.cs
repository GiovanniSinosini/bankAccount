using System;
using System.Collections.Generic;
using System.Collections;
using Trabalho1.EstruturasDados;

namespace Trabalho1.EstruturaDeDados
{
    public class My_Stack<T> : IEnumerable<T> where T : IComparable<T>
    {
        //declaracao da colecao
        private ArrayList<T> _collection;
        int capacidade;

        public My_Stack() {

            //so quando for chamado o construtor
            //será inicializado
        _collection = new ArrayList<T>();
   
        // construtor por limitação de capacidade - inicializa com a capacidade
         _collection = new ArrayList<T>(capacidade);         
}
        
        public void Push(T elem) {

            _collection.Add(elem);    // O(1)
        }

        //adicionar valores na stack
        public int Count {
            get {
                return _collection.Count;
            }
        }

        //retorna o top elemento da stack
        public T Top
        {
            get
            {
                return _collection[_collection.Count - 1];   // O(1)
            }
        }

        //remove elemento da stack e retorna o valor
        public T Pop() {
            if (Count > 0)
            {
                //guardar valor
                var top = Top;

                //remover valor
                _collection.RemoveAt(_collection.Count - 1);
                // retornar
                return top;
            }
           throw new Exception("a Stack está vazia");
    }
        //limpar a stack
           public void Clear()
        {
            _collection.Clear();
        }
   
        /********************** classes de suporte para iteracao ******************************/

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _collection.Count - 1; i >= 0; --i)
                yield return _collection[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}