using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bankomat
{
    class AccountProfile
    {
        static void Main(string[] args);
        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

   
        //insättning
        public double Deposit(double amount)
    {
        if (amount > 0.0)
        {
            dBalance += amount;
        }
        return dBalance;
    }

    //uttag
    public double Withdraw(double amount)
    {
        if (dBalance >= amount)
        {
            dBalance -= amount;
        }

        return dBalance;
    }

  }    

}

        
