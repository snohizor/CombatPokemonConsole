using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CombatPokemonConsole
{
    public class Pokemon
    {   
        public int Id { get; set; }
        public string Name { get; set; }
        public Element Type1 { get; set; }
        public Element? Type2 { get; set; }
        public int Hp { get; set; }
        public int HpMax { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int SpAtk { get; set; }
        public int SpDef { get; set; }
        public int Speed { get; set; }
        public List<Attack> AttackList { get; set; }
        public string MoveName1 { get; set; }
        public string MoveName2 { get; set; }
        public string MoveName3 { get; set; }
        public string MoveName4 { get; set; }
        public State State { get; set; }

        public Pokemon(List<string> lineFromCsv)
        { 
            List<Attack> attacks = new List<Attack>();
            Id = int.Parse(lineFromCsv[0]);
            Name = lineFromCsv[1];
            Type1 = (Element) Enum.Parse(typeof(Element), lineFromCsv[2]);
            Type2 = Enum.TryParse(lineFromCsv[3], out Element type) ? type : null;
            Hp = int.Parse(lineFromCsv[4]);
            HpMax = int.Parse(lineFromCsv[4]);
            Atk = int.Parse(lineFromCsv[5]);
            Def = int.Parse(lineFromCsv[6]);
            SpAtk = int.Parse(lineFromCsv[7]);
            SpDef = int.Parse(lineFromCsv[8]);
            Speed = int.Parse(lineFromCsv[9]);
            AttackList = attacks;
            MoveName1 = lineFromCsv[10];
            MoveName2 = lineFromCsv[11];
            MoveName3 = lineFromCsv[12];
            MoveName4 = lineFromCsv[13];
            State = State.None;
        }

  
        //Tableau Forces/Faiblesses Types
        //17 types -> Normal - Feu - Eau - Plante - Electrik - Glace - Combat - Poison - Sol - Vol - Psy - Insecte - Roche - Spectre - Dragon - Ténèbres - Acier
        int[,] affinitiesOld =
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
            if(affinitiesOld[(int)target.Type1, (int)attack.Type] > 100)
            {
                Console.WriteLine("C'est super efficace !\n");
            }
            if(affinitiesOld[(int)target.Type1, (int)attack.Type] < 100)
            {
                Console.WriteLine("Ce n'est pas très efficace...\n");
            }
            target.Hp = target.Hp - ((attack.Damages * affinitiesOld[(int)target.Type1, (int)attack.Type]) / 100);
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
