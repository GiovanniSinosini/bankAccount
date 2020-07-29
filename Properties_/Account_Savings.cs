using Account;
using System;
using System.Collections.Generic;
using System.Text;
using Trabalho1.Properties_;

namespace Trabalho1.Properties_
{
    class Account_Savings : Account_Order{
      
        Account_Savings(){
        }

        public Account_Savings(int id, Holder holder1, double balance, int openingYear, string type)
        {
            Id = id;
            Holder1 = holder1;
            Balance = balance;
            OpeningYear = openingYear;
            Type = type;
        }
        public Account_Savings(int id, Holder holder1, Holder holder2, double balance, int openingYear, string type)
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
