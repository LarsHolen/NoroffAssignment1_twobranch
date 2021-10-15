using NoroffAssignment1.Characters.Attributes;
using NoroffAssignment1.Characters.Items;
using System;

namespace NoroffAssignment1.Characters
{
    public class Ranger : Character
    {
        public Ranger(string n)
        {
            Name = n;
            StartPrimaryArrtibutes = new PrimaryAttributes { Strength = 1, Dexterity = 7, Intelligence = 1, Vitality = 8 };  
            LevelUpPrimaryAttributes = new PrimaryAttributes { Strength = 1, Dexterity = 5, Intelligence = 1, Vitality = 2 };
            BasePrimaryAttributes = Level * StartPrimaryArrtibutes;
        }

        public override void EquipItem(Item i)
        {
            Console.WriteLine("Equipping");
        }
    }
    

}
