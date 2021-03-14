using System;
using System.Collections.Generic;

namespace CombatPokemonConsole
{
    class Game
    {
        public Pokemon GetChosenPokemonForFight(Boolean player, List<Pokemon> pokelist)
        {
            if(player)
                Console.WriteLine("Quel pokemon choisissez-vous ?\n");

            if(!player)
                Console.WriteLine("Contre qui voulez-vous vous castagne ?\n");

            foreach (Pokemon pokemon in pokelist)
            {
                Console.WriteLine(pokemon.DisplayPokemonAndAttacks());
            }
            return pokelist[Convert.ToInt32(Console.ReadLine())];
        }

        public void Fight(Pokemon player, Pokemon opponent)
        {
            Console.WriteLine(opponent.Name + " veut se battre, cette grosse pute.\n");
            Console.WriteLine(player.DisplayPokemonAndAttacks());
            Console.WriteLine(opponent.DisplayPokemonAndHp());
            int NbRounds = 1;

            while (player.Hp > 0 && opponent.Hp > 0)
            {
                Console.WriteLine("Round " + NbRounds + "\n");
                if(NbRounds == 1 && opponent.Speed > player.Speed)
                {
                    opponent.UseRandomAttack(player);

                    Console.WriteLine(DisplayBothPokemonAndHp(player, opponent));

                    Console.WriteLine("...");
                    Console.ReadLine();
                }

                if (player.Hp > 0 && opponent.Hp > 0)
                {
                    player.ChooseAndUseAttack(opponent);

                    Console.WriteLine(DisplayBothPokemonAndHp(player, opponent));

                    Console.WriteLine("...");
                    Console.ReadLine();
                }     

                if (player.Hp > 0 && opponent.Hp > 0)
                {
                    opponent.UseRandomAttack(player);

                    Console.WriteLine(DisplayBothPokemonAndHp(player, opponent));

                    Console.WriteLine("...");
                    Console.ReadLine();
                }
                NbRounds++;
            }

            if (player.Hp <= 0)
                Console.WriteLine(player.Name + " est KO, zebi");
            else if (opponent.Hp <= 0)
                Console.WriteLine(opponent.Name + " est KO, t'as dead ça chacal");
        }

        public string DisplayBothPokemonAndHp(Pokemon player, Pokemon opponent)
        {
            string msg = player.Name + " " + player.Hp + "/" + player.HpMax + " vs " +
                opponent.Name + " " + opponent.Hp + "/" + opponent.HpMax;
            return msg;
        }
    }

    
}
