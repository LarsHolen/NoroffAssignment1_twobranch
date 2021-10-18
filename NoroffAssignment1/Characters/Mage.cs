using NoroffAssignment1.Characters.Attributes;
using NoroffAssignment1.Characters.Items;
using System;

namespace NoroffAssignment1.Characters
{
    public class Mage : Character
    {

        public Mage(string n)
        {
            // Setting character name
            Name = n;
            // Setting hardcoded start stats and usable weapons and armor
            StartPrimaryArrtibutes = new PrimaryAttributes { Strength = 1, Dexterity = 1, Intelligence = 8, Vitality = 5 };
            LevelUpPrimaryAttributes = new PrimaryAttributes { Strength = 1, Dexterity = 1, Intelligence = 5, Vitality = 3 };
            BasePrimaryAttributes = Level * StartPrimaryArrtibutes;


            UsableArmorTypes.Add(ArmorType.ARMOR_CLOTH, 0);

            UsableWeaponTypes.Add(WeaponType.STAFF, 0);
            UsableWeaponTypes.Add(WeaponType.WAND, 0);
        }
        


    }
}
