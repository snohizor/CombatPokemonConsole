using System;

namespace CombatPokemonConsole
{
    class Game
    {

        public void Fight(Pokemon player, Pokemon opponent)
        {
            Console.WriteLine(opponent.Name + " veut se battre, cette grosse pute.");

            while (player.Hp > 0 && opponent.Hp > 0)
            {
                Console.WriteLine(player.DisplayPokemon());
                Console.WriteLine(opponent.DisplayPokemon());

                Console.WriteLine("...");
                Console.ReadLine();

                player.ChooseAndUseAttack(opponent);

                if (player.Hp > 0 && opponent.Hp > 0)
                {
                    opponent.UseRandomAttack(player);

                    Console.WriteLine("...");
                    Console.ReadLine();
                }
            }

            if (player.Hp <= 0)
                Console.WriteLine(player.Name + " est KO, zebi");
            else if (opponent.Hp <= 0)
                Console.WriteLine(opponent.Name + " est KO, t'as dead ça chacal");




        }
    }
}
