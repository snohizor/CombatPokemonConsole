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
            Attack Charge = new Attack("Charge", Type.Normal, 10);
            Attack Griffes = new Attack("Griffes", Type.Normal, 12);
            Attack FouetLianes = new Attack("Fouet lianes", Type.Plante, 15);
            Attack PistoletAEau = new Attack("Pistolet à eau", Type.Eau, 16);
            Attack Flammeche = new Attack("Flammeche", Type.Feu, 17);

            //Instanciation Listes
            List<Attack> BulbizarreAttackList = new List<Attack> { Charge, FouetLianes };
            List<Attack> CarapuceAttackList = new List<Attack> { Charge, PistoletAEau };
            List<Attack> SalamecheAttackList = new List<Attack> { Griffes, Flammeche };

            //Instanciation Pokemons
            Pokemon Bulbizarre = new Pokemon("Bulbizarre", Type.Plante, 100, 50, BulbizarreAttackList);
            Pokemon Carapuce = new Pokemon("Carapuce", Type.Eau, 90, 60, CarapuceAttackList);
            Pokemon Salameche = new Pokemon("Salameche", Type.Feu, 80, 65, SalamecheAttackList);

            //Création de la liste des pokemon
            List<Pokemon> pokelist = new List<Pokemon>()
            {
                Bulbizarre,
                Carapuce,
                Salameche
            };


            //START GAME

            Game combat = new Game();
            Pokemon pokemon = combat.GetChosenPokemonForFight(true, pokelist);
            Pokemon opponent = combat.GetChosenPokemonForFight(false, pokelist);
            combat.Fight(pokemon, opponent);
        }
    }
}
