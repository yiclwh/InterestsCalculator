using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestsCalculator
{
    public class Person : IInterestUnit
    {
        public Wallet[] Wallets { get; private set; }

        public Person(Wallet[] wallets)
        {
            Wallets = wallets;
        }

        // sum of all wallets interest
        public decimal Interest
        {
            get
            {
                return (from w in Wallets select w.Interest).Sum();
            }
        }
    }
}
