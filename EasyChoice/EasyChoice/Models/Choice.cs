// Authors: Christian Cox & Kyle Daniel Kirkpatrick

namespace EasyChoice.Models
{
    // This class creates a model for a "Choice" which the user can create
    class Choice
    {
        // The name that the user has input for the Choice
        public string Name { get; set; }

        // The filepath to the file in which this Choice's "Name" property will be saved
        public string Filename { get; set; }

        // The SetName of the ElementSet to which this Choice is attached to
        public string ElementSetName { get; set; }

        /**
         * NOTE: This field/property is not in use; could use it in a future release
         * 
         * // The Weight of a choice allows a user to tweak the probability of a Wheel
         * // landing on it
         * private double Weight { get; set; }
         */

        // A default constructor that creates an instance of Choice
        public Choice() { }

        // A constructor that takes an ElementSet's "SetName", a string, as a
        // parameter. The constructor creates a new instance of Choice with its
        // "ElementSetName" property set to the string parameter
        public Choice(string elementSetName)
        {
            ElementSetName = elementSetName;
        }

        // A constructor that takes a Choice as a parameter. The constructor
        // creates a new instance of Choice with its "Name" property set to
        // the "Name" property of the Choice in the parameter
        public Choice(Choice otherChoice)
        {
            Name = otherChoice.Name;
        }

        // An override of the ToString() method so that if an instance
        // of Choice is written into a string, it will be converted by
        // returning the Choice's "Name" property
        public override string ToString()
        {
            return Name;
        }
    }
}
