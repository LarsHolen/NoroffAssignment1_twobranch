using NoroffAssignment1.System.Characters.Attributes;
using NoroffAssignment1.System.Enums;
using System;

namespace NoroffAssignment1.System.Characters
{
    public class Warrior : Character, ICharacter
    {
        
        public Warrior(string n)
        {
            // Setting name
            Name = n;
            // Setting hardcoded start stats and usable weapons and armor
            PrimaryAttributesAtLevelOne = new PrimaryAttributes { Strength = 5, Dexterity = 2, Intelligence = 1, Vitality = 10 };
            PrimaryAttributesLevelUpBonus = new PrimaryAttributes { Strength = 3, Dexterity = 2, Intelligence = 1, Vitality = 5 };
            PrimaryAttributesBase = Level * PrimaryAttributesAtLevelOne;
            CalculateStats();

            UsableArmorTypes.Add (ArmorType.ARMOR_PLATE);
            UsableArmorTypes.Add(ArmorType.ARMOR_MAIL);


            UsableWeaponTypes.Add(WeaponType.AXE);
            UsableWeaponTypes.Add(WeaponType.HAMMER);
            UsableWeaponTypes.Add(WeaponType.SWORD);

           

        }
        public override int GetMainStat()
        {
            return PrimaryAttributesWithEquipment.Strength;
        }


    }
}
