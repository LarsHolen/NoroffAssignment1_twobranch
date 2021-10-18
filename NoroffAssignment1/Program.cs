using NoroffAssignment1.Characters;
using NoroffAssignment1.Characters.Attributes;
using NoroffAssignment1.Characters.Items;
using System;

namespace NoroffAssignment1
{
    class Program
    {
        static void Main()
        {
            //Console.Clear();
            ItemTests items = new();

            Warrior war = new("Haladan");
            war.LevelUp(3);
            war.EquipItem(items.Axe);
            war.EquipItem(items.PlateArmor);
            CharacterStatsDisplay characterSheet = new(war);
            Console.WriteLine(characterSheet.sheet.ToString());
          
            
        }
    }
}
