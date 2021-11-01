using NoroffAssignment1.System.Characters.Attributes;
using NoroffAssignment1.System.Characters.CharacterTypes;
using NoroffAssignment1.System.Enums;
using NoroffAssignment1.System.Equipment.Items;
using System;
using System.Collections.Generic;

namespace NoroffAssignment1.System.Characters
{
    public class Character 
    {
        // Name of character
        public string Name { get; init; }
        // Level of character
        public int Level { get; private set; } = 1;
        // Characters playerclass in a string
        public string ClassString { get; init; }

        // Strategies for Attributes and equipment
        public ICharacterAttributeStrategyType CharacterAttributeStrategy;
        public ICharacterEquipmentStrategy CharacterEquipmentStrategy;

        // Characters PrimaryAttributes without and item bonuses
        public PrimaryAttributes PrimaryAttributesBase { get; set; }
        // Characters PrimaryAttributes including bonuses from items
        public PrimaryAttributes PrimaryAttributesWithEquipment { get; set; }
        // Characters SecondaryAttributes calculated from primaryAttributes including item bonuses
        public SecondaryAttributes SecondaryAttributesTotal { get; set; }

        // Characters damage pr second with current PrimaryAttributes including item bonuses and weapon damege/spped
        public double Dps { get; set; }

        // Class that handle equipping items
        public EquipmentHandler EquipmentHandler;

        // Characters item slots.  All slots empty/null at start
        public Dictionary<EquipmentSlots, Item> EquipmentSlotsOnCharacter = new()
        {
            { EquipmentSlots.HEAD, null },
            { EquipmentSlots.BODY, null },
            { EquipmentSlots.LEGS, null },
            { EquipmentSlots.WEAPON, null }
        };

        // Lists for that items this character can use
        public List<WeaponType> UsableWeaponTypes = new();
        public List<ArmorType> UsableArmorTypes = new();


        /// <summary>
        /// Constructor.  Require a name, the two strategies and the charactertype
        /// </summary>
        /// <param name="name"></param>
        /// <param name="characterAttributeStrategy"></param>
        /// <param name="characterEquipmentStrategy"></param>
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

            EquipmentHandler = new EquipmentHandler(CharacterEquipmentStrategy.SetUsableWeaponTypes(), CharacterEquipmentStrategy.SetUsableArmorTypes(), EquipmentSlotsOnCharacter);
            EquipmentHandler.EquipmentChangeEvent += HandleEquipmentChange;

            PrimaryAttributesBase = CharacterAttributeStrategy.SetPrimaryAttributesBase(Level);
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
            // Unarmed weaponDps is 1, so we set it to 1 before checking if character is armed
            double weaponDps = 1;

            // If weapon is in Equipmentslot.WEAPON, calculate weapon dps
            if(EquipmentHandler.EquipmentSlotsOnCharacter[EquipmentSlots.WEAPON]!= null)
            {
                Weapon w = EquipmentHandler.EquipmentSlotsOnCharacter[EquipmentSlots.WEAPON] as Weapon;
                weaponDps = w.WeaponAttribute.BaseDamage * w.WeaponAttribute.AttacksPerSecond;
            }
            // Calculate dps with the boost from PrimaryAttribute damage stat.
            Dps = weaponDps * (1.0 + CharacterAttributeStrategy.GetMainDpsStat(PrimaryAttributesWithEquipment)/ 100.0);
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
