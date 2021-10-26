using NoroffAssignment1.System.Characters.Attributes;
using NoroffAssignment1.System.Enums;
using NoroffAssignment1.System.Equipment.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroffAssignment1.System.Characters.CharacterTypes
{
    class CharacterAttributeStrategyMage : ICharacterAttributeStrategyType
    {

        public PrimaryAttributes PrimaryAttributesAtLevelOne { get; init; } = new PrimaryAttributes(1, 1, 8, 5);
        public PrimaryAttributes PrimaryAttributesLevelUpBonus { get; init; } = new PrimaryAttributes(1, 1, 5, 3);
        public string ClassString { get; init; } = "Mage";

        public PrimaryAttributes SetPrimaryAttributesBase(int level)
        {
            Console.WriteLine(PrimaryAttributesAtLevelOne + ((level - 1) * PrimaryAttributesLevelUpBonus));
            return PrimaryAttributesAtLevelOne + ((level-1) * PrimaryAttributesLevelUpBonus);
        }

        public int GetMainDpsStat(PrimaryAttributes primaryAttributesWithEquipment) => primaryAttributesWithEquipment.Intelligence;


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
            returnList.Add(WeaponType.STAFF);
            returnList.Add(WeaponType.WAND);
            return returnList;
        }

        public List<ArmorType> SetUsableArmorTypes()
        {
            List<ArmorType> returnList = new();
            returnList.Add(ArmorType.ARMOR_CLOTH);
            return returnList;
        }
        #endregion
    }
}
