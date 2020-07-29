using System;
using System.Collections.Generic;
using System.Text;


using Trabalho1.EstruturasDados;

namespace Trabalho1.Properties_
{
    public static class Ordination {

        // algoritmo de ordenação
        public static void InsertionSortAlgorithm<T>( this ArrayList<T> list, Comparer<T> comparer = null) {

            // se o comparador for nulo, inicio-o com o comparador padrão
            comparer = comparer ?? Comparer<T>.Default;

            int i, j;

            //ordenação se a lista não estiver vazia
            for (i = 0; i < list.Count; i++) {

                T value = list[i];
                j = i - 1;

                while ( (j >= 0) && (comparer.Compare(list[j], value) >0 )) {

                    list[j + 1] = list[j];
                    j--;
                }
                list[j + 1] = value;          
            }
        }
        public static void QuickSort(this int[] arr, int start, int end)    // O(n  lg2  n) no melhor caso e  no caso  médio  O(n2) no pior caso ;  
        {
            int i;
            if (start < end)                
            {
                i = Partition(arr, start, end);

                QuickSort(arr, start, i - 1);
                QuickSort(arr, i + 1, end);
            }
        }

        private static int Partition(this int[] arr, int start, int end)  // partition = core of the algorithm => divide to conquer
        {
            int temp;
            int p = arr[end];
            int i = start - 1;

            for (int j = start; j <= end - 1; j++)  // will go through the entire vector
            {
                if (arr[j] <= p)  // if arr [0] is less than arr [end] => if current element is less than or equal EXCHANGE OF POSITION
                {
                    i++;                
                    temp = arr[i];
                    arr[i] = arr[j];    //exchange of positions
                    arr[j] = temp;
                }
            }

            temp = arr[i + 1];
            arr[i + 1] = arr[end];
            arr[end] = temp;
            return i + 1;
        }
    }
}
