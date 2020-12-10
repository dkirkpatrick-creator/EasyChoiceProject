// Authors: Christian Cox & Kyle Daniel Kirkpatrick

namespace EasyChoice.Models
{
    // This class creates a model for an "ElementSet" which the user can create
    class ElementSet
    {
        // The filepath to the file in which this ElementSet's "SetName"
        // property will be saved
        public string Filename { get; set; }

        // The name that the user has input for the ElementSet
        public string SetName { get; set; }
    }
}
