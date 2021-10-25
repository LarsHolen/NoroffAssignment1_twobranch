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
            PrimaryAttributesAtLevelOne = new PrimaryAttributes { Strength = 1, Dexterity = 1, Intelligence = 8, Vitality = 5 };
            PrimaryAttributesLevelUpBonus = new PrimaryAttributes { Strength = 1, Dexterity = 1, Intelligence = 5, Vitality = 3 };
            PrimaryAttributesBase = Level * PrimaryAttributesAtLevelOne;


            UsableArmorTypes.Add(ArmorType.ARMOR_CLOTH);

            UsableWeaponTypes.Add(WeaponType.STAFF);
            UsableWeaponTypes.Add(WeaponType.WAND);
        }

        public override int GetMainStat()
        {
            return PrimaryAttributesWithEquipment.Intelligence;
        }

    }
}
