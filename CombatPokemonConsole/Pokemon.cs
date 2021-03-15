using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CombatPokemonConsole
{
    class Pokemon
    {
        
        public int id { get; set; }
        public string Name { get; set; }
        public Type Type1 { get; set; }
        public Type Type2 { get; set; }
        public int TotalStats { get; set; }
        public int Hp { get; set; }
        public int HpMax { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int SpAtk { get; set; }
        public int SpDef { get; set; }
        public int Speed { get; set; }
        public bool Legendary { get; set; }
        public List<Attack> AttackList { get; set; }

        public Pokemon(int id, string name, Type type1, Type type2, int totalStats, int hp, int atk, int def, int spAtk, int spDef, int speed, bool legendary, List<Attack> attackList)
        {
            this.id = id;
            Name = name;
            Type1 = type1;
            Type2 = type2;
            TotalStats = totalStats;
            Hp = hp;
            HpMax = hp;
            Atk = atk;
            Def = def;
            SpAtk = spAtk;
            SpDef = spDef;
            Speed = speed;
            Legendary = legendary;
            AttackList = attackList;
        }

  
        //Tableau Forces/Faiblesses Types
        //17 types -> Normal - Feu - Eau - Plante - Electrik - Glace - Combat - Poison - Sol - Vol - Psy - Insecte - Roche - Spectre - Dragon - Ténèbres - Acier
        int[,] forceWeak =
        {
                { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100},
                { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100},
                { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100},
                { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100},
                { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100},
                { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100},
                { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100},
                { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100},
                { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100},
                { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100},
                { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100},
                { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100},
                { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100},
                { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100},
                { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100},
                { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100},
                { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100}
        };


        


        //Fighting
        private void ApplyDamages(Pokemon target, Attack attack)
        {
            if(forceWeak[(int)target.Type1, (int)attack.Type] > 100)
            {
                Console.WriteLine("C'est super efficace !\n");
            }
            if(forceWeak[(int)target.Type1, (int)attack.Type] < 100)
            {
                Console.WriteLine("Ce n'est pas très efficace...\n");
            }
            target.Hp = target.Hp - ((attack.Damages * forceWeak[(int)target.Type1, (int)attack.Type]) / 100);
        }

        
        public void ChooseAndUseAttack(Pokemon opponent)
        {
            Console.WriteLine("Que doit faire " + this.Name + " ?\n");
            Console.WriteLine(this.GetPokemonAttacks());
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
        public string DisplayPokemonAndAttacks()
        {
            string PokemonStats = this.Name + " " + this.Hp + "/" + this.HpMax + "\n" +
                this.GetPokemonAttacks();
            return PokemonStats;
        }

        public string DisplayPokemonAndHp()
        {
            string PokemonHp = this.Name + " " + this.Hp + "/" + this.HpMax + "\n";
            return PokemonHp;
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
