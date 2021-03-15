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
            Attack Charge = new Attack("Charge", Type.Normal, 10);
            Attack Griffes = new Attack("Griffes", Type.Normal, 12);
            Attack FouetLianes = new Attack("Fouet lianes", Type.Plante, 15);
            Attack PistoletAEau = new Attack("Pistolet à eau", Type.Eau, 16);
            Attack Flammeche = new Attack("Flammeche", Type.Feu, 17);

            //Instanciation Listes
            List<Attack> BulbizarreAttackList = new List<Attack> { Charge, FouetLianes };
            List<Attack> CarapuceAttackList = new List<Attack> { Charge, PistoletAEau };
            List<Attack> SalamecheAttackList = new List<Attack> { Griffes, Flammeche };

            //START GAME
            List<string> tempList = LoadCSV(@"D:\Temp\Pokemon\pokemondatabase.csv");
            List<Pokemon> pokelist = GetPokelistFromStringlist(tempList, BulbizarreAttackList);

            int NbPokemonInList = (tempList.Count / 12);
            Console.WriteLine("Nombre de pokezgegs dans la liste : " + NbPokemonInList);

            Console.WriteLine(GetPokelistFromStringlist(tempList, BulbizarreAttackList)[133].Name);

            Console.WriteLine(GetPokelistFromStringlist(tempList, BulbizarreAttackList)[0].AttackList[0].Name);

            Game combat = new Game();
            Pokemon pokemon = combat.GetChosenPokemonForFight(true, pokelist);
            Pokemon opponent = combat.GetChosenPokemonForFight(false, pokelist);
            combat.Fight(pokemon, opponent);
            
        }

        public static List<string> LoadCSV(string path)
        {
            using (var reader = new StreamReader(path))
            {
                List<string> stringList = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    
                    for (int i = 0; i < values.Length; i++)
                    {
                        stringList.Add(values[i]);
                    }
                }
                return stringList;
            }    
        }


        //public static List<Pokemon> GetPokelistFromStringlist(List<string> stringList, List<List<Attack>> pokeAtkList)
        public static List<Pokemon> GetPokelistFromStringlist(List<string> stringList, List<Attack> pokeAtkList)
        {
            //12 valeurs par ligne
            List<Pokemon> Pokelist = new List<Pokemon>();
            List<Attack> atklist = new List<Attack>();
            int NbOfPokemonInPokelist = 0;
            int NbOfPokemonInCSVList = (stringList.Count / 12);

            for (int i = 0; i < NbOfPokemonInCSVList; i++)
            {
                int id = Int32.Parse(stringList[0 + (Pokelist.Count*12)]);
                string name = stringList[1 + (Pokelist.Count * 12)];
                Enum.TryParse(stringList[2 + (Pokelist.Count * 12)], out Type type1);
                Enum.TryParse(stringList[3 + (Pokelist.Count * 12)], out Type type2);
                int totalStats = Int32.Parse(stringList[4 + (Pokelist.Count * 12)]);
                int hp = Int32.Parse(stringList[5 + (Pokelist.Count * 12)]);
                int atk = Int32.Parse(stringList[6 + (Pokelist.Count * 12)]);
                int def = Int32.Parse(stringList[7 + (Pokelist.Count * 12)]);
                int spAtk = Int32.Parse(stringList[8 + (Pokelist.Count * 12)]);
                int spDef = Int32.Parse(stringList[9 + (Pokelist.Count * 12)]);
                int speed = Int32.Parse(stringList[10 + (Pokelist.Count * 12)]);
                bool legendary = bool.Parse(stringList[11 + (Pokelist.Count * 12)]);

                Pokelist.Add(new Pokemon(id, name, type1, type2, totalStats, hp, atk, def, spAtk, spDef, speed, legendary, pokeAtkList));
                NbOfPokemonInPokelist++;
            }

            return Pokelist;
        }

    }
}
