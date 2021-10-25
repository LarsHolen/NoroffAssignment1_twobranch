using NoroffAssignment1.System.Characters.Attributes;
using NoroffAssignment1.System.Enums;
using System;

namespace NoroffAssignment1.System.Characters
{
    public class Ranger : Character, ICharacter
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
