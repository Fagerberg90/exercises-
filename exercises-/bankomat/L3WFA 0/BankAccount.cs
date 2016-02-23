using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L3WFA_1
{
    class BankAccount
    {
        private double dBalance;
        private int AccountNumber;
        private double rate = 0.23;
        private static int NextAccountNumber = 1234;

        public void InitBankAccount()
        {
            AccountNumber = ++NextAccountNumber;
            dBalance = 0.0;
        }

        //saldo
        public double Balance()
        {
            return dBalance;
        }

        //hämta kontonummer
        public int GetAccountNumber()
        {
            return AccountNumber;
        }

        //ändra kontonummer
        public void SetAccountNumber(int accountNumber)
        {
            this.AccountNumber = accountNumber;
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

        public override string ToString()
        {
            return string.Format("#{0}\nSaldo: {1:C}", GetAccountNumber(),
                                                            Balance());;
        }
    }
}
