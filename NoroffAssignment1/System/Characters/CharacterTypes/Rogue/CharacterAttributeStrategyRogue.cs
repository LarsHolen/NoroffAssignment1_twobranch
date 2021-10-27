using NoroffAssignment1.System.Characters.Attributes;
using NoroffAssignment1.System.Enums;
using NoroffAssignment1.System.Equipment.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroffAssignment1.System.Characters.CharacterTypes.Rogue
{
    class CharacterAttributeStrategyRogue : ICharacterAttributeStrategyType
    {
        public PrimaryAttributes PrimaryAttributesAtLevelOne { get; init; } = new PrimaryAttributes(2, 6, 1, 8);
        public PrimaryAttributes PrimaryAttributesLevelUpBonus { get; init; } = new PrimaryAttributes(1, 4, 1, 3);
        public string ClassString { get; init; } = "Rogue";


        public PrimaryAttributes SetPrimaryAttributesBase(int level)
        {
            return PrimaryAttributesAtLevelOne + (level - 1) * PrimaryAttributesLevelUpBonus;
        }

        public int GetMainDpsStat(PrimaryAttributes primaryAttributesWithEquipment) => primaryAttributesWithEquipment.Dexterity;

    }
}
