using System;
using System.Collections;
using System.Collections.Generic;



namespace Trabalho1.EstruturaDeDados
{
    class Queue<T> : IEnumerable<T> where T : IComparable<T>
    {

        private T[] _collection { get; set; }   //array - variável

        private int tamanhoFila { get; set; }
        private int head { get; set; }   //apontador para INÍCIO da fila
        private int tail { get; set; }   //apontador para o FIM da fila
            
        private const int tamanhoPorDefeitoDoArray = 8;

        public Queue() : this(tamanhoPorDefeitoDoArray)
        {
        }

        public Queue(int capacidade)
        {
            tamanhoFila = 0;
            head = 0;
            tail = 0;
            _collection = new T[capacidade];   //inicialização variável
        }

        //métodos
        public void Enqueue(T value){ //adicionar elementos
            
            if (IsFull()){
                throw new Exception("Queue is FULL.");
            }
            else {
                _collection[tail] = value;
                tail = (tail + 1) % _collection.Length;
                tamanhoFila++;
            }            
        }
        public T Dequeue(){  //remove e imprime o valor removido

            if (IsEmpty()){
                throw new Exception("Queue is EMPTY.");
            }
            else {
                T firstElement;
                firstElement = _collection[head];

                head = (head + 1) % _collection.Length;
                tamanhoFila--;

                return firstElement;
            }
        }

        public T Peek(){    // apenas consulta

            T firstElement;
            firstElement = _collection[head];

            return firstElement;
        }

        public Boolean IsEmpty() {

            return tamanhoFila == 0 ;
        }
        public Boolean IsFull()
        {
            return tamanhoFila == _collection.Length;
        }

        public void PrintQueue(){
            foreach (var item in _collection)
            {
                if (item != null)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _collection.GetEnumerator() as IEnumerator<T>;

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }  
    }
}