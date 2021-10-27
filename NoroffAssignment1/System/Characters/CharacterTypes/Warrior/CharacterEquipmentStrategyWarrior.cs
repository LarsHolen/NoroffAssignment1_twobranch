using NoroffAssignment1.System.Enums;
using System.Collections.Generic;

namespace NoroffAssignment1.System.Characters.CharacterTypes.Warrior
{
    public class CharacterEquipmentStrategyWarrior : ICharacterEquipmentStrategy
    {

        #region Lists for what items one can use, Armor and Weapons types
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
