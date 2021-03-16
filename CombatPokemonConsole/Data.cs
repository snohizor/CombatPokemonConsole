using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatPokemonConsole
{
    public static class Data
    {
        public static List<Pokemon> Pokemons = new List<Pokemon>();
        public static List<Attack> Attacks = new List<Attack>();
        public static int[,] Affinities;

        

        static Data()
        {
            int nbAffinities = Enum.GetNames(typeof(Element)).Length;
            Affinities = new int[nbAffinities, nbAffinities];
            LoadPokemons(LoadCSV("./csv/pokemondatabase.csv"));
            LoadAttacks(LoadCSV("./csv/attacksdatabase.csv"));
        }

        public static List<List<string>> LoadCSV(string path)
        {
            using (var reader = new StreamReader(path))
            {
                List<List<string>> linesStrings = new List<List<string>>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',').ToList();

                    linesStrings.Add(values);
                }
                return linesStrings;
            }
        }

        static void LoadPokemons(List<List<string>> pokestrings)
        {
            foreach (List<string> line in pokestrings)
            {
                Pokemons.Add(new Pokemon(line));
            }
        }

        static void LoadAttacks(List<List<string>> attackstrings)
        {
            foreach (List<string> line in attackstrings)
            {
                Attacks.Add(new Attack(line));
            }
        }

        static void LoadAffinities(List<List<string>> affinitiesstrings)
        {
            int lineIndex = 0;
            foreach (List<string> line in affinitiesstrings)
            {
                for (int i = 0; i < affinitiesstrings.Count; i++)
                {
                    Affinities[lineIndex, i] = int.TryParse(line[i], out var nb) ? nb : 100;
                }
                lineIndex++;
            }
        }
    }
}
