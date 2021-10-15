using NoroffAssignment1.Characters.Attributes;
using NoroffAssignment1.Characters.Items;
using System;

namespace NoroffAssignment1.Characters
{
    public class Warrior : Character
    {
        
        public Warrior(string n)
        {
            Name = n;
            StartPrimaryArrtibutes = new PrimaryAttributes { Strength = 5, Dexterity = 2, Intelligence = 1, Vitality = 10 };
            LevelUpPrimaryAttributes = new PrimaryAttributes { Strength = 3, Dexterity = 2, Intelligence = 1, Vitality = 5 };
            BasePrimaryAttributes = Level * StartPrimaryArrtibutes;
        }
        public override void EquipItem(Item i)
        {
            Console.WriteLine(  "Equipping"); 
        }

        
    }
}
