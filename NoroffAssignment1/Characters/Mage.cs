using NoroffAssignment1.Characters.Attributes;
using NoroffAssignment1.Characters.Items;
using System;

namespace NoroffAssignment1.Characters
{
    public class Mage : Character
    {

        public Mage(string n)
        {
            Name = n;
            StartPrimaryArrtibutes = new PrimaryAttributes { Strength = 1, Dexterity = 1, Intelligence = 8, Vitality = 5 };
            LevelUpPrimaryAttributes = new PrimaryAttributes { Strength = 1, Dexterity = 1, Intelligence = 5, Vitality = 3 };
            BasePrimaryAttributes = Level * StartPrimaryArrtibutes;
        }
        public override void EquipItem(Item i)
        {
            Console.WriteLine("Equipping");
        }


    }
}
