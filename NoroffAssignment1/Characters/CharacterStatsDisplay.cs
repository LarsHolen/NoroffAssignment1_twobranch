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
        public Character character;
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
            sheet.AppendLine("Strength: " + character.PrimaryAttributesWithEquipment.Strength.ToString());
            sheet.AppendLine("Vitality: " + character.PrimaryAttributesWithEquipment.Vitality.ToString());
            sheet.AppendLine("Dexterity: " + character.PrimaryAttributesWithEquipment.Dexterity.ToString());
            sheet.AppendLine("Intelligence: " + character.PrimaryAttributesWithEquipment.Intelligence.ToString());
            sheet.AppendLine();
            sheet.AppendLine("Health: " + character.SecondaryAttributesTotal.Health.ToString());
            sheet.AppendLine("Armor Rating: " + character.SecondaryAttributesTotal.ArmorRating.ToString());
            sheet.AppendLine("Elemental Resistance: " + character.SecondaryAttributesTotal.ElementalResistance.ToString());

            sheet.AppendLine("Damage Per Second: " + character.Dps);

            // Showing the inventory:

            // Weapon
            if(character.EquipmentSlotsOnCharacter[EquipmentSlots.WEAPON] != null)
            {
                sheet.AppendLine("\n\nWeapon: " + character.EquipmentSlotsOnCharacter[EquipmentSlots.WEAPON].Name);
            }
            else
            {
                sheet.AppendLine("\n\nWeapon: Nothing, you have to fight with your bare hands!");
            }

            // Head
            if (character.EquipmentSlotsOnCharacter[EquipmentSlots.HEAD] != null)
            {
                sheet.AppendLine("Head: " + character.EquipmentSlotsOnCharacter[EquipmentSlots.HEAD].Name);

            }
            else
            {
                sheet.AppendLine("Head: A few strands of hair won't protect much! ");
            }
            // Body
            if (character.EquipmentSlotsOnCharacter[EquipmentSlots.BODY] != null)
            {
                sheet.AppendLine("Body: " + character.EquipmentSlotsOnCharacter[EquipmentSlots.BODY].Name);

            }
            else
            {
                sheet.AppendLine("Body: Naked, as a new born babe!");
            }
            // Legs
            if (character.EquipmentSlotsOnCharacter[EquipmentSlots.LEGS] != null)
            {
                sheet.AppendLine("Legs: " + character.EquipmentSlotsOnCharacter[EquipmentSlots.LEGS].Name);

            }
            else
            {
                sheet.AppendLine("Legs: Guess who skipped leg day!");
            }
        }
    }
}
