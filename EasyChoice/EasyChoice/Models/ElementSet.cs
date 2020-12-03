using System;
using System.Collections.Generic;
using System.Text;

namespace EasyChoice.Models
{
    class ElementSet
    {
        public string Filename { get; set; }
        public string SetName { get; set; }
        public List<Choice> Choices { get; set; }

        // TODO: make it so that you can save an element set, make the SpinWheel page, base it around the Notes project
    }
}
