using System;

namespace Codenation.Challenge
{
    public class State
    {
        public State(string name, string acronym, decimal territorialExtension)
        {
            this.Name = name;
            this.Acronym = acronym;
            this.TerritorialExtension = territorialExtension;
        }

        public string Name { get; set; }

        public string Acronym { get; set; }

        public decimal TerritorialExtension { get; set; }

    }

}
