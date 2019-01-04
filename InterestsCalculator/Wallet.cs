using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestsCalculator
{
    public class Wallet : IInterestUnit
    {
        public Card[] Cards{ get; private set; }

        // sum of all cards' interest
        public decimal Interest
        {
            get
            {
                return (from c in Cards select c.Interest).Sum();
            }
        }

        public Wallet(Card[] cards)
        {
            Cards = cards;
        }
    }
}
