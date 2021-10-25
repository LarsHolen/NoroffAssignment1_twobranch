using NoroffAssignment1.Characters.Attributes;
using NoroffAssignment1.Characters.Items;
using System;
using System.Collections.Generic;


namespace NoroffAssignment1.Characters
{
    public abstract class Character
    {
        public string Name { get; set; }
        public int Level { get; set; } = 1;
        public PrimaryAttributes PrimaryAttributesBase { get; set; }
        public PrimaryAttributes PrimaryAttributesWithEquipment { get; set; }
        public SecondaryAttributes SecondaryAttributesTotal { get; set; }
        public double Dps;
        

        public PrimaryAttributes PrimaryAttributesAtLevelOne { get; set; }
        public PrimaryAttributes PrimaryAttributesLevelUpBonus { get; set; }

        public List<WeaponType> UsableWeaponTypes = new();
        public List<ArmorType> UsableArmorTypes = new();

        public Dictionary<EquipmentSlots, Item> EquipmentSlotsOnCharacter { get; set; } = new Dictionary<EquipmentSlots, Item>()
        {
            { EquipmentSlots.HEAD, null}, 
            { EquipmentSlots.BODY, null }, 
            { EquipmentSlots.LEGS, null }, 
            { EquipmentSlots.WEAPON, null } 
        };

        /// <summary>
        /// This abstract method will get the main statistic which is used for calculating
        /// damage.  Which statistic it is change from character class to character class.
        /// So, the method is implemented in each character subclass, Warror(Strength), 
        /// Mage(Intelligence), Rogue(Dexterity) and Ranger(Dexterity).
        /// </summary>
        /// <returns></returns>
        public abstract int GetMainStat();
        
        /// <summary>
        /// Adds int l to Level and increase the PrimaryAttributesBase
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
                PrimaryAttributesBase = PrimaryAttributesAtLevelOne + ((Level-1) * PrimaryAttributesLevelUpBonus);
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
            PrimaryAttributesWithEquipment = new PrimaryAttributes();
            PrimaryAttributesWithEquipment += PrimaryAttributesBase;
            // Looping through EquippedItems and add bonusstats to PrimaryAttributesWithEquipment
            
            foreach (KeyValuePair<EquipmentSlots, Item> pair in EquipmentSlotsOnCharacter)
            {
                if(pair.Value != null) PrimaryAttributesWithEquipment += pair.Value.ItemBonusAttributes;

            }
                       
            // Set SecondaryAttributes
            CalculateSecondaryAttributes();
            
        }
        
        /// <summary>
        /// Calculate SecondaryAttributes from TotalAttributes
        /// </summary>
        private void CalculateSecondaryAttributes()
        {
            if(SecondaryAttributesTotal == null)
            {
                SecondaryAttributesTotal = new SecondaryAttributes(PrimaryAttributesWithEquipment);
            }
            else
            {
                SecondaryAttributesTotal.Update(PrimaryAttributesWithEquipment);
            }

            CalculateDPS();
        }

        /// <summary>
        /// To set the DPS, we get information about the class.  That tell us what attribute we
        /// will use to calculate the DPS
        /// </summary>
        private void CalculateDPS()
        {
           
            // Set unarmed dps to 1
            double weaponDmg = 1;

            // If weapon is in Equipmentslot.WEAPON, calculate weapon dps
            if(EquipmentSlotsOnCharacter[EquipmentSlots.WEAPON]!= null)
            {
                Weapon w = EquipmentSlotsOnCharacter[EquipmentSlots.WEAPON] as Weapon;
                weaponDmg = w.WeaponAttribute.BaseDamage * w.WeaponAttribute.AttacksPerSecond;
            }
            // Calculate dps with the boost from PrimaryAttribute damage stat.
            Dps = weaponDmg * (1.0 + GetMainStat() / 100.0);
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
           if(UsableWeaponTypes.Contains(weapon.WeaponType))
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
            if(UsableArmorTypes.Contains(armor.ArmorType))
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
