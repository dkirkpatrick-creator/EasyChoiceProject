using System;
using System.Collections.Generic;

namespace EasyChoice.Models
{
    class Wheel
    {
        public List<Choice> Choices { get; }
        
        public Wheel(List<Choice> choices)
        {
            Choices = new List<Choice>(choices);
        }

        // Returns one choice within the given list of choices that the wheel holds
        public Choice Spin()
        {
            Random rand = new Random();
            int randomVar = (int)Math.Floor(rand.NextDouble() * Choices.Count);

            return Choices[randomVar];
        }
    }
}
