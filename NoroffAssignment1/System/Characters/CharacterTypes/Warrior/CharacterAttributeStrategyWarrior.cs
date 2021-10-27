using NoroffAssignment1.System.Characters.Attributes;
using NoroffAssignment1.System.Enums;
using NoroffAssignment1.System.Equipment.Items;
using System.Collections.Generic;


namespace NoroffAssignment1.System.Characters.CharacterTypes.Warrior
{
    public class CharacterAttributeStrategyWarrior : ICharacterAttributeStrategyType
    {
        

        public PrimaryAttributes PrimaryAttributesAtLevelOne { get; init; } = new PrimaryAttributes(5, 2, 1, 10);
        public PrimaryAttributes PrimaryAttributesLevelUpBonus { get; init; } = new PrimaryAttributes(3, 2, 1, 5);
        public string ClassString { get; init; } = "Warrior";

        public PrimaryAttributes SetPrimaryAttributesBase(int level)
        {
            return PrimaryAttributesAtLevelOne + (level - 1) * PrimaryAttributesLevelUpBonus;
        }

        public int GetMainDpsStat(PrimaryAttributes primaryAttributesWithEquipment) => primaryAttributesWithEquipment.Strength;

    }
}
