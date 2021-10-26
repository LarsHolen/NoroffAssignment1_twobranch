using NoroffAssignment1.System.Characters.Attributes;
using NoroffAssignment1.System.Enums;
using NoroffAssignment1.System.Equipment.Items;
using System.Collections.Generic;


namespace NoroffAssignment1.System.Characters.CharacterTypes
{
    public class CharacterAttributeStrategyWarrior : ICharacterAttributeStrategyType
    {
        

        public PrimaryAttributes PrimaryAttributesAtLevelOne { get; init; } = new PrimaryAttributes(5, 2, 1, 10);
        public PrimaryAttributes PrimaryAttributesLevelUpBonus { get; init; } = new PrimaryAttributes(3, 2, 1, 5);


        public PrimaryAttributes SetPrimaryAttributesBase(int level)
        {
            return PrimaryAttributesAtLevelOne + (level - 1) * PrimaryAttributesLevelUpBonus;
        }

        public int GetMainDpsStat(PrimaryAttributes primaryAttributesWithEquipment) => primaryAttributesWithEquipment.Strength;

      
       
        

        public PrimaryAttributes PrimaryAttributesWithEquipment(PrimaryAttributes primaryAttributesBase, Dictionary<EquipmentSlots, Item> equipmentSlotsOnCharacter)
        {
            PrimaryAttributes primaryAttributesWithEquipment = primaryAttributesBase;
            foreach (KeyValuePair<EquipmentSlots, Item> pair in equipmentSlotsOnCharacter)
            {
                if (pair.Value != null) primaryAttributesWithEquipment += pair.Value.ItemBonusAttributes;

            }
            return primaryAttributesWithEquipment;
        }

        #region Lists for what items to use, Armor and Weapons types
        public List<WeaponType> SetUsableWeaponTypes()
        {
            List<WeaponType> returnList = new();
            returnList.Add(WeaponType.AXE);
            returnList.Add(WeaponType.HAMMER);
            returnList.Add(WeaponType.SWORD);
            return returnList;
        }


        public List<ArmorType> SetUsableArmorTypes()
        {
            List<ArmorType> returnList = new();
            returnList.Add(ArmorType.ARMOR_PLATE);
            returnList.Add(ArmorType.ARMOR_MAIL);
            return returnList;
        }
        #endregion
    }
}
