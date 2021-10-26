using NoroffAssignment1.System.Characters.CharacterTypes;
using NoroffAssignment1.System.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroffAssignment1.System.Characters
{
    public class CharacterFactory
    {
        public static Character MakeCharacter(CharacterType charType, string name)
        {
            Character character = charType switch
            {
                CharacterType.WARRIOR => new Character(name, new CharacterAttributeStrategyWarrior(), charType),
                CharacterType.MAGE => new Character(name, new CharacterAttributeStrategyMage(), charType),
                CharacterType.ROGUE => new Character(name, new CharacterAttributeStrategyRogue(), charType),
                CharacterType.RANGER => new Character(name, new CharacterAttributeStrategyRanger(), charType),
                _ => null,
            };
            return character;

        }
    }
}
