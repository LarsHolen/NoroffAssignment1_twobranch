using NoroffAssignment1.System.Characters.Attributes;
using NoroffAssignment1.System.Enums;
using NoroffAssignment1.System.Equipment.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroffAssignment1.System.Characters.CharacterTypes
{
    public interface ICharacterAttributeStrategyType
    {
        public PrimaryAttributes PrimaryAttributesAtLevelOne { get; init; }
        public PrimaryAttributes PrimaryAttributesLevelUpBonus { get; init; }

        public PrimaryAttributes SetPrimaryAttributesBase(int level);

        public int GetMainDpsStat(PrimaryAttributes primaryAttributesWithEquipment);

    }
}
