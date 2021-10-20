using NoroffAssignment1.Characters.Attributes;
using NoroffAssignment1.Characters.Items;
using System;

namespace NoroffAssignment1.Characters
{
    public class Ranger : Character
    {
        public Ranger(string n)
        {
            // Setting name
            Name = n;
            // Setting hardcoded start stats and usable weapons and armor
            LevelOnePrimaryAttributes = new PrimaryAttributes { Strength = 1, Dexterity = 7, Intelligence = 1, Vitality = 8 };
            LevelUpBonusPrimaryAttributes = new PrimaryAttributes { Strength = 1, Dexterity = 5, Intelligence = 1, Vitality = 2 };
            BasePrimaryAttributes = Level * LevelOnePrimaryAttributes;

            UsableArmorTypes.Add(ArmorType.ARMOR_LEATHER, 0);
            UsableArmorTypes.Add(ArmorType.ARMOR_MAIL, 0);

            UsableWeaponTypes.Add(WeaponType.BOW, 0);
        }

        public override int GetMainStat()
        {
            return TotalPrimaryAttributes.Dexterity;
        }


    }
    

}
