using System;
using System.Collections.Generic;

namespace CombatPokemonConsole
{
    public enum Type
    {
        Normal,
        Eau,
        Feu,
        Plante

    };

    public class _Type
    {
        public Type Type { get; set; }

        //Creation de la liste des Types dispo
        List<Type> TypesList = new List<Type>();

        public void PrintAllSuits()
        {
            foreach (Type type in (Type[])Enum.GetValues(typeof(Type)))
            {
                TypesList.Add(type);
            }
        }
    }

}
