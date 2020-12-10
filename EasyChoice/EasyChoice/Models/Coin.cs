// Authors: Christian Cox & Kyle Daniel Kirkpatrick

using System;

namespace EasyChoice.Models
{
    // This class creates a model for a "Coin"
    class Coin
    {
        // CoinValue holds the values that the coin can land on: "HEADS" and "TAILS"
        public enum CoinValue { HEADS, TAILS };

        // After a Coin has been flipped, the Value property will hold the value
        // (either "HEADS" or "TAILS") that the Coin has "landed upon"
        public CoinValue Value { get; set; }

        // The default contstructor for Coin; creates an instance of Coin and
        // then calls the "Flip()" method to assign a value to the Value property
        public Coin()
        {
            this.Flip();
        }

        // This method "flips" the given instance of Coin
        // (i.e. randomly assign a value of "HEADS" or "TAILS" to the "Value" field)
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

        // An override of the ToString() method so that if an instance
        // of Coin is written into a string, it will be converted by
        // returning the Coin's "Value" property converted into a string
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
