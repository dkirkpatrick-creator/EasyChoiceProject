namespace EasyChoice.Models
{
    class Choice
    {
        public string Name { get; }
        // private double Weight;   <-- don't think we are using this

        public Choice(string name)
        {
            Name = name;
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
