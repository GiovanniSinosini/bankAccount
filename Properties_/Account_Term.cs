using Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace Trabalho1.Properties_
{
    class Account_Term : Account_Order{

        Account_Term()
        {
        }

        public Account_Term(int id, Holder holder1, double balance, int openingYear, string type)
        {
            Id = id;
            Holder1 = holder1;
            Balance = balance;
            OpeningYear = openingYear;
            Type = type;
        }
        public Account_Term(int id, Holder holder1, Holder holder2, double balance, int openingYear, string type)
        {
            Id = id;
            Holder1 = holder1;
            Holder2 = holder2;
            Balance = balance;
            OpeningYear = openingYear;
            Type = type;
        }
    }
}
