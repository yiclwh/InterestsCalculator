using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using InterestsCalculator;

namespace InterestsCalculator.UnitTests
{
    [TestFixture]
    public class InterestsCalculator_VerifyResults
    {
        private Person person1;
        private Person person2;
        private Person person3;
        private Person person4;

        [SetUp]
        protected void Setup()
        {
            //1 person has 1 wallet and 3 cards (1 Visa, 1 MC 1 Discover) – Each Card has a balance of $100
            person1 = new Person(new Wallet[] { new Wallet(new Card[]{ new Visa(100), new MC(100), new Discover(100)})});
            //1 person has 2 wallets Wallet 1 has a Visa and Discover , wallet 2 a MC -each card has $100 balance
            person2 = new Person(new Wallet[] { new Wallet(new Card[] { new Visa(100), new Discover(100) }), new Wallet(new Card[] { new MC(100) }) });
            //2 people have 1 wallet each,  person 1 has 1 wallet , with 2 cards MC and visa person 2
            //has 1 wallet – 1 visa and 1 MC - each card has $100 balance
            person3 = new Person(new Wallet[] { new Wallet(new Card[] { new MC(100), new Visa(100)}) });
            person4 = new Person(new Wallet[] { new Wallet(new Card[] { new Visa(100), new MC(100)}) });
        }

        [Test]
        public void InterestShouldMatchForPerson1()
        {
            Assert.AreEqual(person1.Interest, 16);
            decimal[] expected = { 10, 5, 1};
            int itr = 0;
            foreach(Wallet w in person1.Wallets)
            {
                foreach (Card c in w.Cards)
                {
                    Assert.AreEqual(c.Interest, expected[itr]);
                    itr += 1;
                }
            }
        }

        [Test]
        public void InterestShouldMatchForPerson2()
        {
            Assert.AreEqual(person2.Interest, 16);
            decimal[] expected = { 11, 5 };
            int itr = 0;
            foreach (Wallet w in person2.Wallets)
            {
                Assert.AreEqual(w.Interest, expected[itr]);
                itr += 1;
            }
        }

        [Test]
        public void InterestShouldMatchForPerson3AndPerson4()
        {
            Assert.AreEqual(person3.Interest, 15);
            Assert.AreEqual(person3.Interest, 15);
            decimal[] expected = { 15, 15 };
            int itr = 0;
            foreach (Wallet w in person3.Wallets)
            {
                Assert.AreEqual(w.Interest, expected[itr]);
                itr += 1;
            }
            foreach (Wallet w in person4.Wallets)
            {
                Assert.AreEqual(w.Interest, expected[itr]);
                itr += 1;
            }
        }
    }
}
