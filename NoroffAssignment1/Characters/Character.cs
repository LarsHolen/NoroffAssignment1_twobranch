using NoroffAssignment1.Characters.Attributes;
using NoroffAssignment1.Characters.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroffAssignment1.Characters
{
    public abstract class Character
    {
        public string Name { get; set; }
        public int Level { get; set; } = 1;
        public PrimaryAttributes BasePrimaryAttributes { get; set; }
        public PrimaryAttributes TotalPrimaryAttributes { get; set; }
        public SecondaryAttributes SecondaryAttributes { get; set; }
        public double Dps;
        public double PrimaryStatForDamage;

        public PrimaryAttributes LevelOnePrimaryAttributes { get; set; }
        public PrimaryAttributes LevelUpBonusPrimaryAttributes { get; set; }

        public Dictionary<WeaponType, int> UsableWeaponTypes = new();
        public Dictionary<ArmorType, int> UsableArmorTypes = new();

        public Dictionary<EquipmentSlots, Item> EquipmentSlotsOnCharacter { get; set; } = new Dictionary<EquipmentSlots, Item>()
        {
            { EquipmentSlots.HEAD, null}, 
            { EquipmentSlots.BODY, null }, 
            { EquipmentSlots.LEGS, null }, 
            { EquipmentSlots.WEAPON, null } 
        };
        
        
        /// <summary>
        /// Adds int l to Level and increase the BasePrimaryAttributes
        /// (Level-1 because the first level increase the PrimaryAttributes by StartPrimaryAttributes)
        /// 0 or less is not leagal input and throws exception
        /// Calls SetTotalAttributes, to update everything that is influenced by the change in lvl)
        /// </summary>
        /// <param name="l"></param>
        public void LevelUp(int level)
        {
            if(level > 0)
            {
                Level += level;
                BasePrimaryAttributes = LevelOnePrimaryAttributes + ((Level-1) * LevelUpBonusPrimaryAttributes);
                CalculateStats();
            } else
            {
                throw new ArgumentException("Zero or negative input not legal");
            }
            
        }

        /// <summary>
        /// Updates TotalAttributes, by including PAs on items
        /// Calls SetSecondaryAttributes when done to update that
        /// </summary>
        public void CalculateStats()
        {
            // Zero out the TotalAttributes and start adding from the new base base and items
            TotalPrimaryAttributes = new PrimaryAttributes();
            TotalPrimaryAttributes += BasePrimaryAttributes;
            // Looping through EquippedItems and add bonusstats to TotalPrimaryAttributes
            
            foreach (KeyValuePair<EquipmentSlots, Item> pair in EquipmentSlotsOnCharacter)
            {
                if(pair.Value != null) TotalPrimaryAttributes += pair.Value.ItemBonusAttributes;

            }
                       
            // Set SecondaryAttributes
            CalculateSecondaryAttributes();
            
        }
        
        /// <summary>
        /// Calculate SecondaryAttributes from TotalAttributes
        /// </summary>
        private void CalculateSecondaryAttributes()
        {
            if(SecondaryAttributes == null)
            {
                SecondaryAttributes = new SecondaryAttributes(TotalPrimaryAttributes);
            }
            else
            {
                SecondaryAttributes.Update(TotalPrimaryAttributes);
            }

            CalculateDPS();
        }

        /// <summary>
        /// To set the DPS, we get information about the class.  That tell us what attribute we
        /// will use to calculate the DPS
        /// </summary>
        private void CalculateDPS()
        {
            PrimaryStatForDamage = this.GetType().Name switch
            {
                "Warrior" => TotalPrimaryAttributes.Strength,
                "Mage" => TotalPrimaryAttributes.Intelligence,
                "Ranger" => TotalPrimaryAttributes.Dexterity,
                "Rogue" => TotalPrimaryAttributes.Dexterity,
                _ => throw new ArgumentException("Unable to find class damage Attribute"),// This should not happen, if we do not add more rpg classes
            };
            // Set unarmed dps to 1
            double weaponDmg = 1;

            // If weapon is in Equipmentslot.WEAPON, calculate weapon dps
            if(EquipmentSlotsOnCharacter[EquipmentSlots.WEAPON]!= null)
            {
                Weapon w = EquipmentSlotsOnCharacter[EquipmentSlots.WEAPON] as Weapon;
                weaponDmg = w.WeaponAttribute.BaseDamage * w.WeaponAttribute.AttacksPerSecond;
            }
            // Calculate dps with the boost from PrimaryAttribute damage stat.
            Dps = weaponDmg * (1.0 + PrimaryStatForDamage / 100.0);
        }


        /// <summary>
        /// Equip weapon or armor.  Check if class can use and is high enough level,
        /// and recalculate stats after equipping.  Will overwrite any equipped item 
        /// in that slot.  Returns string on sucsess.  Throws exception on fail
        /// </summary>
        /// <param name="weapon"></param>
        public string EquipItem(Weapon weapon)
        {
           // Test if this class can equip the weapon
           if(UsableWeaponTypes.ContainsKey(weapon.WeaponType))
            {
                if(Level >= weapon.RequiredLevel)
                {
                    // Equip weapon and recalculate character stats
                    EquipmentSlotsOnCharacter[EquipmentSlots.WEAPON] = weapon;
                    CalculateStats();
                    return "New weapon equipped!";
                } else
                {
                    throw new InvalidWeaponException("This character is too low level for this weapon.");
                }
                
            } else
            {
                // throws custom exception if one cant use the weapon
                throw new InvalidWeaponException("This class can not use this weapon.");
            }
        }

        public string EquipItem(Armor armor)
        {
            if(UsableArmorTypes.ContainsKey(armor.ArmorType))
            {
                if(Level >= armor.RequiredLevel)
                {
                    EquipmentSlotsOnCharacter[armor.FitInEquipmentSlot] = armor;
                    CalculateStats();
                    return "New armor equipped!";
                } else
                {
                    throw new InvalidArmorException("This character is too low level to use this armor.");
                }
                
            }
            else 
            {
                throw new InvalidArmorException("This class can not use this armor.");
            }
        }
    }
}
