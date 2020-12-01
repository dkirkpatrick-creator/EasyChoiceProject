using System;

namespace EasyChoice.Models
{
    class Coin
    {
        public enum CoinValue { HEADS, TAILS };
        public CoinValue Value { get; set; }

        public Coin()
        {
            this.Flip();
        }

        // Call this method to flip the given instance of Coin (i.e. assign a value to the "Value" field)
        public void Flip()
        {
            Random rand = new Random();
            double randVar = rand.NextDouble();

            if (randVar < 0.5)
            {
                Value = CoinValue.HEADS;
            }
            else
            {
                Value = CoinValue.TAILS;
            }
        }

        public override string ToString()
        {
            string value;

            if (Value == CoinValue.HEADS)
            {
                value = "Heads";
            }
            else
            {
                value = "Tails";
            }

            return value;
        }
    }
}
