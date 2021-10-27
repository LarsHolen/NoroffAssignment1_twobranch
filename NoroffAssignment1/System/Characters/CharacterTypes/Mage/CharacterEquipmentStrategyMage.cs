using NoroffAssignment1.System.Enums;
using System.Collections.Generic;


namespace NoroffAssignment1.System.Characters.CharacterTypes.Mage
{
    public class CharacterEquipmentStrategyMage : ICharacterEquipmentStrategy
    {
        #region Lists for what items one can use, Armor and Weapons types
        public List<WeaponType> SetUsableWeaponTypes()
        {
            List<WeaponType> returnList = new();
            returnList.Add(WeaponType.WAND);
            returnList.Add(WeaponType.STAFF);
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
