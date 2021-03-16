using System;
using System.Collections.Generic;
using System.IO;

namespace CombatPokemonConsole
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
    
            //Instanciation Attacks
            Attack Charge = new Attack("Charge", Element.Normal, 10);
            Attack Griffes = new Attack("Griffes", Element.Normal, 12);
            Attack FouetLianes = new Attack("Fouet lianes", Element.Plante, 15);
            Attack PistoletAEau = new Attack("Pistolet à eau", Element.Eau, 16);
            Attack Flammeche = new Attack("Flammeche", Element.Feu, 17);

            //Instanciation Listes
            List<Attack> BulbizarreAttackList = new List<Attack> { Charge, FouetLianes };
            List<Attack> CarapuceAttackList = new List<Attack> { Charge, PistoletAEau };
            List<Attack> SalamecheAttackList = new List<Attack> { Griffes, Flammeche };

            //START GAME
            Console.WriteLine("Nombre de pokezgegs dans la liste : " + Data.Pokemons.Count);

            Console.WriteLine("ici est écrit bulbizarre en anglais : " + Data.Pokemons[0].Name);

            Game combat = new Game();
            Pokemon pokemon = combat.GetChosenPokemonForFight(true, Data.Pokemons);
            Pokemon opponent = combat.GetChosenPokemonForFight(false, Data.Pokemons);
            combat.Fight(pokemon, opponent);
            
        }
    }
}
