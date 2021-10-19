using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroffAssignment1.Characters
{
    public class CharacterStatsDisplay
    {
        public StringBuilder sheet = new();
        private Character character;
        public CharacterStatsDisplay(Character c)
        {
            character = c;
            UpdateCharacterSheet();
        }


        /// <summary>
        /// Making a charactersheet with stringbuilder to be able to show the character information
        /// </summary>
        public void UpdateCharacterSheet()
        {
            sheet.Clear();
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

            // Showing the inventory:

            // Weapon
            if(character.EquippedItems[EquipmentSlots.WEAPON] != null)
            {
                sheet.AppendLine("\n\nWeapon: " + character.EquippedItems[EquipmentSlots.WEAPON].Name);
            }
            else
            {
                sheet.AppendLine("\n\nWeapon: Nothing, you have to fight with your bare hands!");
            }

            // Head
            if (character.EquippedItems[EquipmentSlots.HEAD] != null)
            {
                sheet.AppendLine("Head: " + character.EquippedItems[EquipmentSlots.HEAD].Name);

            }
            else
            {
                sheet.AppendLine("Head: A few strands of hair won't protect much! ");
            }
            // Body
            if (character.EquippedItems[EquipmentSlots.BODY] != null)
            {
                sheet.AppendLine("Body: " + character.EquippedItems[EquipmentSlots.BODY].Name);

            }
            else
            {
                sheet.AppendLine("Body: Naked, as a new born babe!");
            }
            // Legs
            if (character.EquippedItems[EquipmentSlots.LEGS] != null)
            {
                sheet.AppendLine("Legs: " + character.EquippedItems[EquipmentSlots.LEGS].Name);

            }
            else
            {
                sheet.AppendLine("Legs: Guess who skipped leg day!");
            }
        }
    }
}
