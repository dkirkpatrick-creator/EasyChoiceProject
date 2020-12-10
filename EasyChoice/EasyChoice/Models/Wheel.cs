// Authors: Christian Cox & Kyle Daniel Kirkpatrick

using System;
using System.Collections.Generic;

namespace EasyChoice.Models
{
    // This class creates a model for a "Wheel"
    class Wheel
    {
        // The Choices property holds a list of Choices from which the user would
        // like to randomly pick a Choice from
        public List<Choice> Choices { get; }

        // A constructor that takes a list of Choices as a parameter.
        // The constructor creates a new instance of Wheel with its "Choices"
        // property set to be the list of choices parameter
        public Wheel(List<Choice> choices)
        {
            Choices = new List<Choice>(choices);
        }

        // Returns one Choice within the list of choices that the Wheel holds
        public Choice Spin()
        {
            Random rand = new Random();

            // Generating a random index between [0, Choices.Count); this
            // way there is a chance to randomly pick any one of the elements
            // within the Wheel's list of Choices
            int randomVar = (int)Math.Floor(rand.NextDouble() * Choices.Count);

            return Choices[randomVar];
        }
    }
}
