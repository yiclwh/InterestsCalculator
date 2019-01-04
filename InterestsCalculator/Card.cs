namespace InterestsCalculator
{
    public abstract class Card : IInterestUnit
    {
        public decimal Balance { get; set; }

        public Card(decimal balance)
        {
            this.Balance = balance;
        }

        public abstract decimal Interest { get; }
    }

    public class Visa : Card
    {
        public Visa(decimal b) : base(b) { }
        public override decimal Interest
        {
            get
            {
                return (decimal)0.1 * Balance;
            }
        }
    }

    public class MC : Card
    {
        public MC(decimal b) : base(b) { }
        public override decimal Interest
        {
            get
            {
                return (decimal)0.05 * Balance;
            }
        }
    }

    public class Discover : Card
    {
        public Discover(decimal b) : base(b) { }
        public override decimal Interest
        {
            get
            {
                return (decimal)0.01 * Balance;
            }
        }
    }
}
