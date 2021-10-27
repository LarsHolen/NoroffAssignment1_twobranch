using NoroffAssignment1.System.Characters.Attributes;
using NoroffAssignment1.System.Enums;
using NoroffAssignment1.System.Equipment.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroffAssignment1.System.Characters.CharacterTypes.Ranger
{
    class CharacterAttributeStrategyRanger : ICharacterAttributeStrategyType
    {
        public PrimaryAttributes PrimaryAttributesAtLevelOne { get; init; } = new PrimaryAttributes(1, 7, 1, 8);
        public PrimaryAttributes PrimaryAttributesLevelUpBonus { get; init; } = new PrimaryAttributes(1, 5, 1, 2);
        public string ClassString { get; init; } = "Ranger";


        public PrimaryAttributes SetPrimaryAttributesBase(int level)
        {
            return PrimaryAttributesAtLevelOne + (level - 1) * PrimaryAttributesLevelUpBonus;
        }

        public int GetMainDpsStat(PrimaryAttributes primaryAttributesWithEquipment) => primaryAttributesWithEquipment.Dexterity;

    }
}
