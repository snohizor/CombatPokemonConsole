using System;
using System.Collections.Generic;
using System.Text;

namespace CombatPokemonConsole
{

    class Attack
    {
        public string Name { get; set; }
        public int Damages { get; set; }

        public Attack(string name, int damages)
        {
            Name = name;
            Damages = damages;
        }

    }
}
