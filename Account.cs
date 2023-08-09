using ExceptionAccount.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ExceptionAccount.Entities
{
    internal class Account
    {
        public int Number { get; set; } //numero da conta
        public string Holder { get; set; } //titular da conta
        public double Balance { get; set; } //total da conta
        public double WithdrawLimit { get; set; } //limite de saque

        public Account()
        {
        }

        public Account(int number, string holder, double balance, double withdrawLimit)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
            WithdrawLimit = withdrawLimit;
        }

        //método: deposito
        //amount: quantia
        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public void WithDraw(double amount)
        {
            if (amount > WithdrawLimit)
            {
                throw new DomainException("The amount exceds withdraw limit");
            }
            if (amount > Balance)
            {
                throw new DomainException("Not enough balance");
                //nao há saldo suficiente
            }
            Balance -= amount;
        }

        
        public override string ToString()
        {
            return "New balance: " + Balance.ToString("F2", CultureInfo.InvariantCulture);
                
        }
    }
}
