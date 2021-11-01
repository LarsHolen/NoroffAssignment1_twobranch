using NoroffAssignment1.System.Characters.Attributes;
using NoroffAssignment1.System.Enums;
using NoroffAssignment1.System.Equipment.Items;
using System;
using System.Collections.Generic;


namespace NoroffAssignment1.System.Characters
{
    public class EquipmentHandler
    {
        public event EventHandler<EventArgs> EquipmentChangeEvent;

        public List<WeaponType> UsableWeaponTypes = new();
        public List<ArmorType> UsableArmorTypes = new();
        public Dictionary<EquipmentSlots, Item> EquipmentSlotsOnCharacter;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="usableWeaponTypes"></param>
        /// <param name="usableArmorTypes"></param>
        /// <param name="equipmentSlotsOnCharacter"></param>
        public EquipmentHandler(List<WeaponType> usableWeaponTypes, List<ArmorType> usableArmorTypes, Dictionary<EquipmentSlots, Item> equipmentSlotsOnCharacter)
        {
            UsableArmorTypes = usableArmorTypes;
            UsableWeaponTypes = usableWeaponTypes;
            EquipmentSlotsOnCharacter = equipmentSlotsOnCharacter;
        }


        public static PrimaryAttributes PrimaryAttributesWithEquipment(PrimaryAttributes primaryAttributesBase, Dictionary<EquipmentSlots, Item> equipmentSlotsOnCharacter)
        {
            PrimaryAttributes primaryAttributesWithEquipment = primaryAttributesBase;
            foreach (KeyValuePair<EquipmentSlots, Item> pair in equipmentSlotsOnCharacter)
            {
                if (pair.Value != null) primaryAttributesWithEquipment += pair.Value.ItemBonusAttributes;

            }
            return primaryAttributesWithEquipment;
        }

        #region Equipping items
        /// <summary>
        /// Equip weapon or armor.  Check if class can use and is high enough level.  Will overwrite any equipped item 
        /// in that slot. On equip invoke an event, so DPS can be updated in character class and returns string on sucsess.  Throws exception on fail
        /// </summary>
        /// <param name="weapon"></param>
        public string EquipItem(Weapon weapon, int level)
        {
            // Test if this class can equip the weapon
            if (UsableWeaponTypes.Contains(weapon.WeaponType))
            {
                if (level >= weapon.RequiredLevel)
                {
                    // Equip weapon and recalculate character stats
                    EquipmentSlotsOnCharacter[EquipmentSlots.WEAPON] = weapon;
                    EquipmentChangeEvent?.Invoke(this, new EventArgs());
                    return "New weapon equipped!";
                }
                else
                {
                    throw new InvalidWeaponException("This character is too low level for this weapon.");
                }
            }
            else
            {
                // throws custom exception if one cant use the weapon
                throw new InvalidWeaponException("This class can not use this weapon.");
            }
        }

        public string EquipItem(Armor armor, int level)
        {
            if (UsableArmorTypes.Contains(armor.ArmorType))
            {
                if (level >= armor.RequiredLevel)
                {
                    EquipmentSlotsOnCharacter[armor.FitInEquipmentSlot] = armor;
                    EquipmentChangeEvent?.Invoke(this, new EventArgs());
                    return "New armor equipped!";
                }
                else
                {
                    throw new InvalidArmorException("This character is too low level to use this armor.");
                }
            }
            else
            {
                throw new InvalidArmorException("This class can not use this armor.");
            }
        }
        #endregion 

    }
}
