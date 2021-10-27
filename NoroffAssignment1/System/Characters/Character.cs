using NoroffAssignment1.System.Characters.Attributes;
using NoroffAssignment1.System.Characters.CharacterTypes;
using NoroffAssignment1.System.Enums;
using NoroffAssignment1.System.Equipment.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoroffAssignment1.System.Characters
{
    public class Character 
    {
        public string Name { get; init; }
        public int Level { get; private set; } = 1;
        public string ClassString { get; init; }


        public ICharacterAttributeStrategyType CharacterAttributeStrategy;
        public ICharacterEquipmentStrategy CharacterEquipmentStrategy;

        public PrimaryAttributes PrimaryAttributesBase { get; set; }
        public PrimaryAttributes PrimaryAttributesWithEquipment { get; set; }
        public SecondaryAttributes SecondaryAttributesTotal { get; set; }
        public double Dps { get; set; }

        public EquipmentHandler EquipmentHandler;

        public Dictionary<EquipmentSlots, Item> EquipmentSlotsOnCharacter = new()
        {
            { EquipmentSlots.HEAD, null },
            { EquipmentSlots.BODY, null },
            { EquipmentSlots.LEGS, null },
            { EquipmentSlots.WEAPON, null }
        };


        public List<WeaponType> UsableWeaponTypes = new();
        public List<ArmorType> UsableArmorTypes = new();


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="characterType"></param>
        public Character(string name, ICharacterAttributeStrategyType characterAttributeStrategy, ICharacterEquipmentStrategy characterEquipmentStrategy , CharacterType characterType)
        {
            Name = name;

            ClassString = characterType switch
            {
                CharacterType.WARRIOR => ("Warrior"),
                CharacterType.MAGE => ("Mage"),
                CharacterType.ROGUE => ("Rogue"),
                CharacterType.RANGER => ("Ranger"),
                _ => null,
            };

            CharacterAttributeStrategy = characterAttributeStrategy;
            CharacterEquipmentStrategy = characterEquipmentStrategy;
            PrimaryAttributesBase = CharacterAttributeStrategy.SetPrimaryAttributesBase(Level);
           // UsableWeaponTypes = CharacterEquipmentStrategy.SetUsableWeaponTypes();
           // UsableArmorTypes = CharacterEquipmentStrategy.SetUsableArmorTypes();
            EquipmentHandler = new EquipmentHandler(CharacterEquipmentStrategy.SetUsableWeaponTypes(), CharacterEquipmentStrategy.SetUsableArmorTypes(), EquipmentSlotsOnCharacter);
            EquipmentHandler.EquipmentChangeEvent += HandleEquipmentChange;
            PrimaryAttributesWithEquipment = EquipmentHandler.PrimaryAttributesWithEquipment(PrimaryAttributesBase, EquipmentHandler.EquipmentSlotsOnCharacter);
            CalculateDPS();
        }

        



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
            PrimaryAttributesWithEquipment = EquipmentHandler.PrimaryAttributesWithEquipment(PrimaryAttributesBase, EquipmentHandler.EquipmentSlotsOnCharacter);
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
            if(EquipmentHandler.EquipmentSlotsOnCharacter[EquipmentSlots.WEAPON]!= null)
            {
                Weapon w = EquipmentHandler.EquipmentSlotsOnCharacter[EquipmentSlots.WEAPON] as Weapon;
                weaponDmg = w.WeaponAttribute.BaseDamage * w.WeaponAttribute.AttacksPerSecond;
            }
            // Calculate dps with the boost from PrimaryAttribute damage stat.
            Dps = weaponDmg * (1.0 + CharacterAttributeStrategy.GetMainDpsStat(PrimaryAttributesWithEquipment)/ 100.0);
        }

        /// <summary>
        /// Handle an event from EquipmentHandler, so stats are updated after equipment change.
        /// </summary>
        private void HandleEquipmentChange(object sender, EventArgs e)
        {
            CalculateStats();
        }


    }
}
