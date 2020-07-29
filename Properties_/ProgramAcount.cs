using System;
using Trabalho1.EstruturaDeDados;
using Trabalho1.EstruturasDados;
using Trabalho1.Properties_;



namespace Account
{
    class Program
    {
        static void Main(string[] args){

            // creating bank
            Bank bank1 = new Bank();     
            
            // creating account with account holder
            Account_Order c1 = new Account_Order(1004, new Holder("Gio", "ABC", "04/01/1988", "male"), 300, 2020, "order");
            Account_Order c2 = new Account_Order(1001, new Holder("João", "DEF", "05/10/1985", "male"), new Holder("Miguel", "GHI", "25/05/1955", "male"), 6000, 2020, "order");
            Account_Order c3 = new Account_Order(1002, new Holder("Maria", "GHI", "01/07/1955", "female"),new Holder("Michael", "JLM", "15/03/1915", "male"), 55000, 2019, "order");
            Account_Order c4 = new Account_Order(1003, new Holder("Joana", "NOP", "09/09/1999", "female"), new Holder("Lion", "RST", "29/02/1901", "male"), 203150, 1930, "order");

            Account_Savings p1 = new Account_Savings(2002, new Holder("Gio", "ABC", "04/01/1988", "male"), 19950, 2020, "savings");
            Account_Savings p2 = new Account_Savings(2001, new Holder("João", "DEF", "05/10/1985", "male"), new Holder("Miguel", "GHI", "25/05/1955", "male"), 355.00, 2020, "savings");
            Account_Savings p3 = new Account_Savings(2004, new Holder("Maria", "GHI", "01/07/1955", "female"), new Holder("Michael", "JLM", "15/03/1915", "male"), 13200.09, 2019, "savings");
            Account_Savings p4 = new Account_Savings(2003, new Holder("Joana", "NOP", "09/09/1999", "female"), new Holder("Lion", "RST", "29/02/1901", "male"), 320, 1930, "savings");

            Account_Term t3 = new Account_Term(3004, new Holder("Maria", "GHI", "01/07/1955", "female"), new Holder("Michael", "JLM", "15/03/1915", "male"), 19.09, 2019, "term");
            Account_Term t4 = new Account_Term(3003, new Holder("Joana", "NOP", "09/09/1999", "female"), new Holder("Lion", "RST", "29/02/1901", "male"), 145, 1930, "term");

            // adding account to the list of bank accounts and priting accounts list
            bank1.AddAccount(c1);
            bank1.AddAccount(c2);
            bank1.AddAccount(c3);
            bank1.AddAccount(c4);
            bank1.AddAccount(p1);
            bank1.AddAccount(p2);
            bank1.AddAccount(p3);
            bank1.AddAccount(p4);
            bank1.AddAccount(t3);
            bank1.AddAccount(t4);

            Console.WriteLine("===============================================================");
            Console.WriteLine("");
            Console.WriteLine("Accounts list:");
            Console.WriteLine();
            bank1.ListAccount();
          
            // adding account holder of c1 to the list of bank account holders
            bank1.AddHolder(c1.Holder1);
            bank1.AddHolder(c2.Holder1, c2.Holder2);
            bank1.AddHolder(c3.Holder1, c3.Holder2);
            bank1.AddHolder(c4.Holder1, c4.Holder2);
                                   
            Console.WriteLine("===============================================================");
            Console.WriteLine("");
            Console.WriteLine("Accounts holders list => with InsertionSort");
            Console.WriteLine();
            
            bank1.ListHolder();
            Console.WriteLine("");
            Console.WriteLine("===============================================================");
            Console.WriteLine("");

            Console.WriteLine("Accounts Number list => with QuickSort");
            Console.WriteLine();
            bank1.ListAccountNumber();

            Console.WriteLine();
            Console.WriteLine("===============================================================");

            // withdraw method
            c1.Withdraw(68.35);
            c2.Withdraw(3500.25);
            c3.Withdraw(6000);
            c4.Withdraw(200000.50);

            //deposti method
            c1.Deposit(2250.14);
            c1.Deposit(1200.00);
            c1.Deposit(1250);
            c2.Deposit(1600.25);
            c3.Deposit(25000);
            c4.Deposit(300.25);

            // print all account details
            
            Console.WriteLine();
            Console.WriteLine("Accounts details: ");
            Console.WriteLine(c1.ToString());
            Console.WriteLine(c2.ToString());
            Console.WriteLine(c3.ToString());
            Console.WriteLine(c4.ToString());
            
            Console.WriteLine();

            Console.WriteLine("====================================================");
            Console.WriteLine("Query multiple items");
            Console.WriteLine();
            Console.WriteLine("Check balance");
            c4.CheckBalance();
            c4.Payments(500.00);

            Console.WriteLine();
            bank1.Consult_By_Client("Gio");
            bank1.Consult_By_Client("Gissso");
            Console.WriteLine();
            bank1.Consult_By_Account(1001);
            bank1.Consult_By_Account(1055);

            Console.WriteLine();

            Console.WriteLine("========================================================================");
            Console.WriteLine("My STACK record");
            Console.WriteLine("Operations record of account: " + c1.Id);
            c1.printRecordOperations();
            Console.WriteLine();
            Console.WriteLine("Operations record of account: " + c2.Id);
            c2.printRecordOperations();
            Console.WriteLine();
            Console.WriteLine("Operations record of account: " + c3.Id);
            c3.printRecordOperations();
            Console.WriteLine();
            Console.WriteLine("Operations record of account: " + c4.Id);
            c4.printRecordOperations();
            Console.WriteLine();
            Console.WriteLine("========================================================================");

            Console.WriteLine("========================================================================");
            Console.WriteLine("My QUEUE record");
            Console.WriteLine("Operations record of account: " + c1.Id);
            c1.PrintRecordOperQueue();
            Console.WriteLine();
            Console.WriteLine("Operations record of account: " + c2.Id);
            c2.PrintRecordOperQueue();
            Console.WriteLine();
            Console.WriteLine("Operations record of account: " + c3.Id);
            c3.PrintRecordOperQueue();
            Console.WriteLine();
            Console.WriteLine("Operations record of account: " + c4.Id);
            c4.PrintRecordOperQueue();
            Console.WriteLine();
            Console.WriteLine("========================================================================");   
           
        }
    }
}
