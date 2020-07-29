using Account;
using Trabalho1.EstruturaDeDados;
using Trabalho1.Properties_;

namespace Trabalho1.Properties_

{
    class Account_Order : Interface1_OperationsAccount {
        
        private int id;     
        private double balance;
        private int openingYear;

        private Holder holder1;
        private Holder holder2;

        private string type;
        private int countOperations = 1;

        My_Stack<string> recordOperations = new My_Stack<string>();
        Queue<string> recordOperationQueue = new Queue<string>(15);

        public int Id { get => id; set => id = value; }
        public double Balance { get => balance; set => balance = value; }
        public int OpeningYear { get => openingYear; set => openingYear = value; }
        internal Holder Holder1 { get => holder1; set => holder1 = value; }
        internal Holder Holder2 { get => holder2; set => holder2 = value; }
        public string Type { get => type; set => type = value; }

        // Constructor
        public Account_Order(){
        }
        public Account_Order(int id, Holder holder1, double balance, int openingYear, string type)
        {
           Id = id;
           Holder1 = holder1;
           Balance = balance;
           OpeningYear = openingYear;
            Type = type; 
        }
        public Account_Order(int id, Holder holder1, Holder holder2, double balance, int openingYear, string type)
        {
            Id = id;
            Holder1 = holder1;
            Holder2 = holder2;
            Balance = balance;
            OpeningYear = openingYear;
            Type = type;
        }

        // Interface methods 
        public void Withdraw(double value)
        {
            string res;
            Balance -= value;
            res = countOperations + "- Successful withdrawal of " + value + " made in the account => " + Id;
            countOperations++;
            recordOperations.Push(res);
            recordOperationQueue.Enqueue(res);          
        }

        public void Deposit(double value){
            string res;
            Balance += value;
            res = countOperations + "- Deposit of " + value + " successful made to the account => " + Id;
            countOperations++;
            recordOperations.Push(res);
            recordOperationQueue.Enqueue(res);
        }
        public void CheckBalance(){
            System.Console.WriteLine("Account: " + Id + " has a balance of:  " + Balance + "EUR" );
        }
        public void Payments(double value){
            string res;
            Balance -= value;
            res = countOperations + "- Payment of " + value + " EUR successfully made debited to account => " + Id;
            countOperations++;
            recordOperations.Push(res);
            recordOperationQueue.Enqueue(res);
        }
        public void printRecordOperations(){
            My_Stack<string> printRecordOperations = new My_Stack<string>();
            while (recordOperations.Count != 0)
            {
                printRecordOperations.Push(recordOperations.Pop()); // remove and add to another stack to create a chronological order for printing
            }
            foreach (var item in printRecordOperations)
            {
                System.Console.WriteLine(item);
            }
        }
        public void PrintRecordOperQueue(){
            recordOperationQueue.PrintQueue();
        }
        // class methods
        public override string ToString()
        {
            if (holder2 != null)
            {
                return "\nAccount ID: " + Id + Holder1.ToString() + "\nHolder2:" + Holder2.ToString() + "\nType: " + Type + "\nBalance: " + Balance + "\nOpening Year: " + OpeningYear;
            }
            else
            {
                return "\nAccount ID: " + Id + Holder1.ToString() + "\nAccount Type: " + Type + "\nBalance: " + Balance + "\nOpening Year: " + OpeningYear;
            }
        }        
    }  
}