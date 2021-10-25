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
            PrimaryAttributesAtLevelOne = new PrimaryAttributes { Strength = 1, Dexterity = 7, Intelligence = 1, Vitality = 8 };
            PrimaryAttributesLevelUpBonus = new PrimaryAttributes { Strength = 1, Dexterity = 5, Intelligence = 1, Vitality = 2 };
            PrimaryAttributesBase = Level * PrimaryAttributesAtLevelOne;

            UsableArmorTypes.Add(ArmorType.ARMOR_LEATHER);
            UsableArmorTypes.Add(ArmorType.ARMOR_MAIL);

            UsableWeaponTypes.Add(WeaponType.BOW);
        }

        public override int GetMainStat()
        {
            return PrimaryAttributesWithEquipment.Dexterity;
        }


    }
    

}
