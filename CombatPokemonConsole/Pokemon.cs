using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CombatPokemonConsole
{
    class Pokemon
    {
        public string Name { get; set; }
        public Type Type { get; set; }
        public int HpMax { get; set; }
        public int Hp { get; set; }
        public int Speed { get; set; }
        public List<Attack> AttackList { get; set; }

        public Pokemon(string name, Type type, int hpMax, int hp, int speed, List<Attack> attackList)
        {
            Name = name;
            Type = type;
            HpMax = hpMax;
            Hp = hp;
            Speed = speed;
            AttackList = attackList;
        }

        //Tableau Forces/Faiblesses Types
        //Normal - Eau - Feu - Plante
        int[,] forceWeak =
        {
                { 100, 100, 100, 100 },
                { 100, 50, 50, 200},
                { 100, 200, 50, 50},
                { 100, 50, 200, 50},
        };

        
	

        //Fighting
        //public Attack GetChosenAttack()
        //{
        //    Console.WriteLine("Que doit faire " + this.Name + " ?\n");
        //    return this.AttackList.ElementAt(Convert.ToInt32(Console.ReadLine()));
        //}

        private void ApplyDamages(Pokemon target, Attack attack)
        {
            target.Hp = target.Hp - ((attack.Damages * forceWeak[attack.Type, target.Type]) / 100);
        }

        public void ChooseAndUseAttack(Pokemon opponent)
        {
            Console.WriteLine("Que doit faire " + this.Name + " ?\n");
            Attack attack = this.AttackList.ElementAt(Convert.ToInt32(Console.ReadLine()) - 1);
            Console.WriteLine(this.Name + " lance " + attack.Name + " !\n");
            ApplyDamages(opponent, attack);
        }

        public void UseRandomAttack(Pokemon opponent)
        {
            Random rnd = new Random();
            int random = rnd.Next(this.AttackList.Count);
            Console.WriteLine(this.Name + " lance " + this.AttackList[random].Name + " !\n");
            ApplyDamages(opponent, this.AttackList[random]);
        }

        //Display
        public string DisplayPokemon()
        {
            string PokemonStats = this.Name + " " + this.Hp + "/" + this.HpMax + "\n" +
                this.GetPokemonAttacks();

            return PokemonStats;
        }

        public string GetPokemonAttacks()
        {
            string PokemonAttackList = "";
            int AttackNumber = 1;
            foreach (Attack attack in this.AttackList)
            {
                PokemonAttackList = PokemonAttackList + AttackNumber + "." + attack.Name + "\n";
                AttackNumber++;
            }
            return PokemonAttackList;
        }

    }
}
