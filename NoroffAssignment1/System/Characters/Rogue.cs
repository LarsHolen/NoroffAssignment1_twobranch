using NoroffAssignment1.System.Characters.Attributes;
using NoroffAssignment1.System.Enums;
using System;

namespace NoroffAssignment1.System.Characters
{
    public class Rogue : Character
    {
        public Rogue(string n)
        {
            // Setting name
            Name = n;
            // Setting hardcoded start stats and usable weapons and armor
            PrimaryAttributesAtLevelOne = new PrimaryAttributes { Strength = 2, Dexterity = 6, Intelligence = 1, Vitality = 8 };
            PrimaryAttributesLevelUpBonus = new PrimaryAttributes { Strength = 1, Dexterity = 4, Intelligence = 1, Vitality = 3 };
            PrimaryAttributesBase = Level * PrimaryAttributesAtLevelOne;


            UsableArmorTypes.Add(ArmorType.ARMOR_LEATHER);
            UsableArmorTypes.Add(ArmorType.ARMOR_MAIL);

            UsableWeaponTypes.Add(WeaponType.DAGGER);
            UsableWeaponTypes.Add(WeaponType.SWORD);
        }

        public override int GetMainStat()
        {
            return PrimaryAttributesWithEquipment.Dexterity;
        }


    }
}
