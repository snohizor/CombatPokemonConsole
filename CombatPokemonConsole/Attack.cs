using System;
using System.Collections.Generic;

namespace CombatPokemonConsole
{

    public class Attack
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Element Type { get; set; }
        public int Damages { get; set; }

        public Attack(string name, Element type, int damages)
        {
            Name = name;
            Type = type;
            Damages = damages;
        }

        public Attack(List<string> lineFromCsv)
        {
            Id = int.Parse(lineFromCsv[0]);
            Name = lineFromCsv[1];
            Type = (Element)Enum.Parse(typeof(Element), lineFromCsv[3], true);
            Damages = int.Parse(lineFromCsv[4]);
        }
    }
}
