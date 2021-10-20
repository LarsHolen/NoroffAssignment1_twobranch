using NoroffAssignment1.Characters.Attributes;
using NoroffAssignment1.Characters.Items;
using System;

namespace NoroffAssignment1.Characters
{
    public class Rogue : Character
    {
        public Rogue(string n)
        {
            // Setting name
            Name = n;
            // Setting hardcoded start stats and usable weapons and armor
            LevelOnePrimaryAttributes = new PrimaryAttributes { Strength = 2, Dexterity = 6, Intelligence = 1, Vitality = 8 };
            LevelUpBonusPrimaryAttributes = new PrimaryAttributes { Strength = 1, Dexterity = 4, Intelligence = 1, Vitality = 3 };
            BasePrimaryAttributes = Level * LevelOnePrimaryAttributes;


            UsableArmorTypes.Add(ArmorType.ARMOR_LEATHER, 0);
            UsableArmorTypes.Add(ArmorType.ARMOR_MAIL, 0);

            UsableWeaponTypes.Add(WeaponType.DAGGER, 0);
            UsableWeaponTypes.Add(WeaponType.SWORD, 0);
        }

        public override int GetMainStat()
        {
            return TotalPrimaryAttributes.Dexterity;
        }


    }
}
