using System;
using System.Collections.Generic;
using System.Text;

namespace Trabalho1.common
{
    public static class GenericSwap{

        public static void Swap <T>(this IList<T> list, int primeiroIndex, int segundoIndex){

            if (list.Count < 2 || primeiroIndex == segundoIndex)
                return;

            var variavel_aux = list[primeiroIndex];

            list[primeiroIndex] = list[segundoIndex];

            list[segundoIndex] = variavel_aux;
        }
     }
}
