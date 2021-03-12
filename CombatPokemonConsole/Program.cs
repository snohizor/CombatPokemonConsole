using System;
using System.Collections.Generic;

namespace CombatPokemonConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Instanciation Attacks
            Attack Charge = new Attack("Charge", 10);
            Attack Griffes = new Attack("Charge", 12);
            Attack FouetLianes = new Attack("Fouet lianes", 15);
            Attack PistoletAEau = new Attack("Pistolet à eau", 16);
            Attack Flammeche = new Attack("Flammeche", 17);

            //Instanciation Listes
            List<Attack> BulbizarreAttackList = new List<Attack> { Charge, FouetLianes };
            List<Attack> CarapuceAttackList = new List<Attack> { Charge, PistoletAEau };
            List<Attack> SalamecheAttackList = new List<Attack> { Griffes, Flammeche };

            //Instanciation Pokemons
            Pokemon Bulbizarre = new Pokemon("Bulbizarre", 100, 100, 50, BulbizarreAttackList);
            Pokemon Carapuce = new Pokemon("Carapuce", 90, 90, 60, CarapuceAttackList);
            Pokemon Salameche = new Pokemon("Salameche", 80, 80, 65, SalamecheAttackList);


            Game combat = new Game();

            combat.Fight(Bulbizarre, Salameche);
        }
    }
}
