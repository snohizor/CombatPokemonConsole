namespace CombatPokemonConsole
{

    class Attack
    {
        public string Name { get; set; }
        public Type Type { get; set; }
        public int Damages { get; set; }

        public Attack(string name, Type type, int damages)
        {
            Name = name;
            Type = type;
            Damages = damages;
        }
    }
}
