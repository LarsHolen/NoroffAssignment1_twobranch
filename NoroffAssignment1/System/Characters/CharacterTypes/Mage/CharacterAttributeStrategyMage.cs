using NoroffAssignment1.System.Characters.Attributes;
using NoroffAssignment1.System.Enums;
using NoroffAssignment1.System.Equipment.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroffAssignment1.System.Characters.CharacterTypes.Mage
{
    class CharacterAttributeStrategyMage : ICharacterAttributeStrategyType
    {

        public PrimaryAttributes PrimaryAttributesAtLevelOne { get; init; } = new PrimaryAttributes(1, 1, 8, 5);
        public PrimaryAttributes PrimaryAttributesLevelUpBonus { get; init; } = new PrimaryAttributes(1, 1, 5, 3);
        public string ClassString { get; init; } = "Mage";

        public PrimaryAttributes SetPrimaryAttributesBase(int level)
        {
            Console.WriteLine(PrimaryAttributesAtLevelOne + ((level - 1) * PrimaryAttributesLevelUpBonus));
            return PrimaryAttributesAtLevelOne + ((level-1) * PrimaryAttributesLevelUpBonus);
        }

        public int GetMainDpsStat(PrimaryAttributes primaryAttributesWithEquipment) => primaryAttributesWithEquipment.Intelligence;

    }
}
