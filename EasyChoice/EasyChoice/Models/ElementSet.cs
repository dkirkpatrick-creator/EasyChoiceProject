using System;
using System.Collections.Generic;
using System.Text;

namespace EasyChoice.Models
{
    class ElementSet
    {
        public string Filename { get; set; }
        public string SetName { get; set; }
        public string ChoicesFilename { get; set; } // think that this is the way
        public List<Choice> Choices { get; set; }
    }
}
