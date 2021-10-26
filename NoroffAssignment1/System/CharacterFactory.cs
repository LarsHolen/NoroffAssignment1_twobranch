using NoroffAssignment1.System.Characters;
using NoroffAssignment1.System.Characters.CharacterTypes;
using NoroffAssignment1.System.Enums;

namespace NoroffAssignment1.System
{
    public class CharacterFactory
    {
        /// <summary>
        /// Static factory class.  Instansiate characters of class and with "name" at level 1
        /// </summary>
        /// <param name="charType" CharacterType enum ></param>
        /// <param name="name" string ></param>
        /// <returns></returns>
        public static Character MakeCharacter(CharacterType charType, string name)
        {
            Character character = charType switch
            {
                CharacterType.WARRIOR => new Character(name, new CharacterAttributeStrategyWarrior()),
                CharacterType.MAGE => new Character(name, new CharacterAttributeStrategyMage()),
                CharacterType.ROGUE => new Character(name, new CharacterAttributeStrategyRogue()),
                CharacterType.RANGER => new Character(name, new CharacterAttributeStrategyRanger()),
                _ => null,
            };
            return character;

        }
    }
}
