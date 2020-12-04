namespace EasyChoice.Models
{
    class Choice
    {
        public string Name { get; set; }
        public string Filename { get; set; }
        public string ElementSetName { get; set; } // the elementSet to which this choice belongs to
        // private double Weight;   <-- don't think we are using this

        public Choice() { }

        public Choice(string elementSetName)
        {
            ElementSetName = elementSetName;
        }

        public Choice(Choice otherChoice)
        {
            Name = otherChoice.Name;
            // Weight = otherChoice.Weight;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
