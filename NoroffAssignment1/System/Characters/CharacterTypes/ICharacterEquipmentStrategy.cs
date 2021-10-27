using NoroffAssignment1.System.Enums;
using NoroffAssignment1.System.Equipment.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroffAssignment1.System.Characters.CharacterTypes
{
    public interface ICharacterEquipmentStrategy
    {
        public List<WeaponType> SetUsableWeaponTypes();
        public List<ArmorType> SetUsableArmorTypes();
    }
}
