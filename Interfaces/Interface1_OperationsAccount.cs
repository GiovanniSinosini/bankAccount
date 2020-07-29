using System;
using System.Collections.Generic;
using System.Text;
using Trabalho1.Properties_;

namespace Trabalho1.Properties_
{
    interface Interface1_OperationsAccount{

        public void Withdraw(double value);
        public void Deposit(double value);
        public void CheckBalance();
        public void Payments(double value);
                    
    }
}
