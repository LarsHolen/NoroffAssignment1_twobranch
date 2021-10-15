using NoroffAssignment1.Characters.Attributes;
using NoroffAssignment1.Characters.Items;
using System;

namespace NoroffAssignment1.Characters
{
    public class Rogue : Character
    {
        public Rogue(string n)
        {
            Name = n;
            StartPrimaryArrtibutes = new PrimaryAttributes { Strength = 2, Dexterity = 6, Intelligence = 1, Vitality = 8 };   
            LevelUpPrimaryAttributes = new PrimaryAttributes { Strength = 1, Dexterity = 4, Intelligence = 1, Vitality = 3 };
            BasePrimaryAttributes = Level * StartPrimaryArrtibutes;
        }


        public override void EquipItem(Item i)
        {
            Console.WriteLine("Equipping");
        }
    }
}
