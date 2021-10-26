using NoroffAssignment1.System.Characters.Attributes;
using NoroffAssignment1.System.Characters.CharacterTypes;
using NoroffAssignment1.System.Enums;
using NoroffAssignment1.System.Equipment.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoroffAssignment1.System.Characters
{
    public class Character : ICharacter
    {
        public string Name { get; init; }
        public int Level { get; private set; } = 1;
        public CharacterType CharacterType { get; init; }

        public ICharacterAttributeStrategyType CharacterAttributeStrategy;

        public PrimaryAttributes PrimaryAttributesBase { get; set; }
        public PrimaryAttributes PrimaryAttributesWithEquipment { get; set; }
        public SecondaryAttributes SecondaryAttributesTotal { get; set; }
        public double Dps { get; set; }
     

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
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        public Character(string name, ICharacterAttributeStrategyType characterType, CharacterType type)
        {
            Name = name;
            CharacterType = type;
            CharacterAttributeStrategy = characterType;
            PrimaryAttributesBase = CharacterAttributeStrategy.SetPrimaryAttributesBase(Level);
            PrimaryAttributesWithEquipment = CharacterAttributeStrategy.PrimaryAttributesWithEquipment(PrimaryAttributesBase, EquipmentSlotsOnCharacter);
            UsableWeaponTypes = CharacterAttributeStrategy.SetUsableWeaponTypes();
            UsableArmorTypes = CharacterAttributeStrategy.SetUsableArmorTypes();
            CalculateDPS();
        }



        #region Methods for level up and updating stats

        /// <summary>
        /// Adds int l to Level and increase the PrimaryAttributesBase
        /// 0 or less is not leagal input and throws exception
        /// Calls CalculateStats, to update everything that is influenced by the change in lvl)
        /// </summary>
        /// <param name="l"></param>
        public void LevelUp(int level)
        {
            if(level > 0)
            {
                Level += level;
                PrimaryAttributesBase = CharacterAttributeStrategy.SetPrimaryAttributesBase(Level);
                CalculateStats();
            } else
            {
                throw new ArgumentException("Zero or negative input not legal");
            }
            
        }

        /// <summary>
        /// Updates PrimaryAttributesWithEquipment, and update SecondaryAttributes
        /// Keeping this in a separate method, because its called both from LevelUp and EquipItem
        /// Then calls CalculateDPS()
        /// </summary>
        public void CalculateStats()
        {
            PrimaryAttributesWithEquipment = CharacterAttributeStrategy.PrimaryAttributesWithEquipment(PrimaryAttributesBase, EquipmentSlotsOnCharacter);
            SecondaryAttributesTotal = new SecondaryAttributes(PrimaryAttributesWithEquipment);
            CalculateDPS();
        }
        
       

        /// <summary>
        /// To set the DPS, we set unarmed weapondmg.  Test if we have weapon.  Get 
        /// main dps attribute through the strategy.
        /// </summary>
        private void CalculateDPS()
        {
            // Set unarmed weapondamage to 1, in case the character does not equit a weapon
            // Dps for 1 weapondamage is 1, so no need to calculate dps for it.
            double weaponDmg = 1;

            // If weapon is in Equipmentslot.WEAPON, calculate weapon dps
            if(EquipmentSlotsOnCharacter[EquipmentSlots.WEAPON]!= null)
            {
                Weapon w = EquipmentSlotsOnCharacter[EquipmentSlots.WEAPON] as Weapon;
                weaponDmg = w.WeaponAttribute.BaseDamage * w.WeaponAttribute.AttacksPerSecond;
            }
            // Calculate dps with the boost from PrimaryAttribute damage stat.
            Dps = weaponDmg * (1.0 + CharacterAttributeStrategy.GetMainDpsStat(PrimaryAttributesWithEquipment)/ 100.0);
        }
        #endregion

        #region Equipping items
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
        #endregion

        
    }
}
