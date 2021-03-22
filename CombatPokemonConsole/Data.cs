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
        public static List<Attack> Attacks = new List<Attack>();
        public static List<Pokemon> Pokemons = new List<Pokemon>();
        public static int[,] Affinities;

        

        static Data()
        {
            int nbAffinities = (Enum.GetNames(typeof(Element)).Length - 1);
            Affinities = new int[nbAffinities, nbAffinities];
            LoadAttacks(LoadCSV("./csv/attacksdatabase.csv"));
            LoadPokemons(LoadCSV("./csv/pokemondatabase.csv"));
            DistributeAttacks(Pokemons, Attacks);   
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

        static void DistributeAttacks(List<Pokemon> pokelist, List<Attack> attacklist)
        {
            foreach (Pokemon pokemon in pokelist)
            {
                Attack[] pokeAttacks =
                {
                    GetAttackFromString(attacklist, pokemon.MoveName1),
                    GetAttackFromString(attacklist, pokemon.MoveName2),
                    GetAttackFromString(attacklist, pokemon.MoveName3),
                    GetAttackFromString(attacklist, pokemon.MoveName4)
                };
                pokemon.AttackList.AddRange(pokeAttacks);
            }
        }

        static Attack GetAttackFromString(List<Attack> attacklist, string attackName)
        {
            Attack error = new Attack("errorAttack", Element.Normal, 420);
            foreach (Attack attack in attacklist)
            {
                if (attackName == attack.Name)
                {
                    return attack;
                }
            }
            return error;
        }
    }
}
