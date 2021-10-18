using NoroffAssignment1.Characters.Attributes;
using NoroffAssignment1.Characters.Items;
using System;

namespace NoroffAssignment1.Characters
{
    public class Warrior : Character
    {
        
        public Warrior(string n)
        {
            // Setting name
            Name = n;
            // Setting hardcoded start stats and usable weapons and armor
            StartPrimaryArrtibutes = new PrimaryAttributes { Strength = 5, Dexterity = 2, Intelligence = 1, Vitality = 10 };
            LevelUpPrimaryAttributes = new PrimaryAttributes { Strength = 3, Dexterity = 2, Intelligence = 1, Vitality = 5 };
            BasePrimaryAttributes = Level * StartPrimaryArrtibutes;
            SetTotalAttributes();

            UsableArmorTypes.Add(ArmorType.ARMOR_PLATE, 0);
            UsableArmorTypes.Add(ArmorType.ARMOR_MAIL, 0);


            UsableWeaponTypes.Add(WeaponType.AXE, 0);
            UsableWeaponTypes.Add(WeaponType.HAMMER, 0);
            UsableWeaponTypes.Add(WeaponType.SWORD, 0);

            
            // Adding test items
            EquippedItems[EquipmentSlots.BODY] = new Armor()
            {
                Name = "Common plate body armor",
                RequiredLevel = 1,
                FitInEquipmentSlot = EquipmentSlots.BODY,
                ArmorType = ArmorType.ARMOR_PLATE,
                ItemBonusAttributes = new PrimaryAttributes() {Vitality = 2, Strength = 1 }
            };
            
        }
        
        
    }
}
