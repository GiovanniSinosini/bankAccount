using System;
using System.Collections.Generic;
using System.Text;
using Trabalho1.Properties_;
using Trabalho1.EstruturaDeDados;
using Trabalho1.EstruturasDados;

namespace Account
{
    class Bank{

        private string nameBank;
        List<Account_Order> listAccount = new List<Account_Order>();
        List<Holder> listHolder = new List<Holder>();
        
        ArrayList<String> arrayOrdenado = new ArrayList<String>{};
        int[] arrayOrdenadoAccountNumber = new int[]{};
        double[] arrayBalance = new double[] { };

        public Bank() {
        }

        public string NameBank { get => nameBank; set => nameBank = value; }

        public void AddAccount(Account_Order newAccount) {
            listAccount.Add(newAccount);        
        }
         
        public void ListAccount(){
            foreach (var item in listAccount) {
                if (item.Holder2 != null){
                    Console.WriteLine("Number account: " + item.Id + "\nAccount Type: " + item.Type + " \nFirst holder: " + item.Holder1.Name + " \nSecond holder: " + item.Holder2.Name + "\nBalance: " + item.Balance);
                    Console.WriteLine("");
                } else {
                    Console.WriteLine("Number account: " + item.Id + "\nAccount Type: " + item.Type + " \nFirst holder: " + item.Holder1.Name + "\nBalance: " + item.Balance);
                    Console.WriteLine("");
                }                     
            }
        }
        
        public void AddHolder(Holder newHolder)
        {
            listHolder.Add(newHolder);
        }

        public void AddHolder(Holder newHolder1, Holder newHolder2)
        {
            listHolder.Add(newHolder1);
            listHolder.Add(newHolder2);
        }
        public void ListHolder(){
            foreach (var item in listHolder){
                if (arrayOrdenado.Contains(item.Name) == false){
                    arrayOrdenado.Add(item.Name);
                }
             }
            arrayOrdenado.InsertionSortAlgorithm();
            foreach (var item in arrayOrdenado){
                Console.WriteLine("Holder: " + item);                    
            }
        }

        public void ListAccountNumber(){
            ArrayList<int> temp= new ArrayList<int>{ };

            foreach (var item in listAccount){
                temp.Add(item.Id);
            }
            arrayOrdenadoAccountNumber = temp.ToArray();
            arrayOrdenadoAccountNumber.QuickSort(0, arrayOrdenadoAccountNumber.Length - 1);          

            foreach (var item in arrayOrdenadoAccountNumber){
                Console.WriteLine("Account Number: " + item);               
            }
        }
 
        public void Consult_By_Account(int numAccount)
        {
            int count = 0;
            foreach (var item in listAccount)
            {
                if (item.Id == numAccount)
                {
                    Console.WriteLine("Query result per Account:");
                    Console.WriteLine("Number account: " + item.Id + ", Account Type: " + item.Type + ", First holder: " + item.Holder1.Name + ", Balance: " + item.Balance);
                    Console.WriteLine("");
                    count++;
                }
            }
            if (count == 0){
                Console.WriteLine("Query result per Account:");
                Console.WriteLine("Unregistered Account => " + numAccount);
            }
        }
        public void Consult_By_Client(string name){
            int count = 0;
            foreach (var item in listAccount)
            {
                if ((item.Holder1.Name).Equals(name)) {
                    Console.WriteLine("Query result per name:");        
                    Console.WriteLine("Number account: " + item.Id + ", Account Type: " + item.Type + ", First holder: " + item.Holder1.Name + ", Balance: " + item.Balance);
                    Console.WriteLine("");
                    count++;
                }
            }
            if(count == 0) {
                Console.WriteLine("Query result per name:");
                Console.WriteLine("Unregistered customer => " + name);
            }
        }
    }
}

