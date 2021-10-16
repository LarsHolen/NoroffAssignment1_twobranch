using NoroffAssignment1.Characters;
using NoroffAssignment1.Characters.Attributes;
using NoroffAssignment1.Characters.Items;
using System;

namespace NoroffAssignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ItemTests items = new ItemTests();

            Warrior war = new Warrior("Haladan");
            war.LevelUp(3);
            war.EquipItem(items.Axe);
            war.EquipItem(items.PlateArmor);
            CharacterStatsDisplay characterSheet = new CharacterStatsDisplay(war);
            Console.WriteLine(characterSheet.sheet.ToString());
          
            
        }
    }
}
