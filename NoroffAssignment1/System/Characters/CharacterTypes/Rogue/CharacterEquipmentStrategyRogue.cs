using NoroffAssignment1.System.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroffAssignment1.System.Characters.CharacterTypes.Rogue
{

    public class CharacterEquipmentStrategyRogue : ICharacterEquipmentStrategy
    {

        #region Lists for what items one can use, Armor and Weapons types
        public List<WeaponType> SetUsableWeaponTypes()
        {
            List<WeaponType> returnList = new();
            returnList.Add(WeaponType.DAGGER);
            returnList.Add(WeaponType.SWORD);
            return returnList;
        }


        public List<ArmorType> SetUsableArmorTypes()
        {
            List<ArmorType> returnList = new();
            returnList.Add(ArmorType.ARMOR_LEATHER);
            returnList.Add(ArmorType.ARMOR_MAIL);
            return returnList;
        }
        #endregion
    }
}
