using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroffAssignment1.Characters
{
    public class CharacterStatsDisplay
    {
        public StringBuilder sheet = new StringBuilder();
        private Character character;
        public CharacterStatsDisplay(Character c)
        {
            character = c;
            UpdateCharacterSheet();
        }

        private void UpdateCharacterSheet()
        {
            sheet.AppendLine("-------Character Sheet--------");
            sheet.AppendLine();
            sheet.AppendLine("Name: " + character.Name );
            sheet.AppendLine("Level: " + character.Level);
            sheet.AppendLine("Strength: " + character.TotalPrimaryAttributes.Strength.ToString());
            sheet.AppendLine("Vitality: " + character.TotalPrimaryAttributes.Vitality.ToString());
            sheet.AppendLine("Dexterity: " + character.TotalPrimaryAttributes.Dexterity.ToString());
            sheet.AppendLine("Intelligence: " + character.TotalPrimaryAttributes.Intelligence.ToString());
            sheet.AppendLine();
            sheet.AppendLine("Health: " + character.SecondaryAttributes.Health.ToString());
            sheet.AppendLine("Armor Rating: " + character.SecondaryAttributes.ArmorRating.ToString());
            sheet.AppendLine("Elemental Resistance: " + character.SecondaryAttributes.ElementalResistance.ToString());

            sheet.AppendLine("Damage Per Second: " + character.Dps);

        }
    }
}
