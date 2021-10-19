using NoroffAssignment1.Characters;
using NoroffAssignment1.Characters.Attributes;
using NoroffAssignment1.Characters.Items;
using System;
using System.Threading;

namespace NoroffAssignment1
{
    class Program
    {

        static void Main()
        {
        
            //Console.Clear();
            ItemTests items = new();
            bool loop = true;
            string input;
            Warrior war = new("Haladan");
            //war.LevelUp(3);
            //war.EquipItem(items.Axe);
            //war.EquipItem(items.PlateArmor);
            CharacterStatsDisplay characterSheet = new(war);

            
            while(loop)
            {
                Console.WriteLine(characterSheet.sheet.ToString());
                Console.WriteLine("Enter 'w' to equip a random weapon.");
                Console.WriteLine("Enter 'a' to equip some random armor.");
                Console.WriteLine("Enter 'l' to gain a level.");
                Console.WriteLine("Enter 'q' to quit.");
                Console.Write("Your command: ");
                input = Console.ReadLine();

                if (input == "l" || input == "L") war.LevelUp(1);
                if (input == "a" || input == "A") EquipRandomArmor(items, war);
                if (input == "w" || input == "W") EquipRandomWeapon(items, war);
                if (input == "q" || input == "Q") loop = false;


                Console.Clear();
                characterSheet.UpdateCharacterSheet();
            }
            
           
            
        }


        /// <summary>
        /// Extra testing and showing leveling and equipping items update stats
        /// </summary>
        /// <param name="items"></param>
        /// <param name="cha"></param>
        private static void EquipRandomWeapon(ItemTests items, Character cha)
        {
            Random rnd = new();
            string result;
            Weapon weapon = items.WeaponList[rnd.Next(0, items.WeaponList.Count)];
            try
            {
                result = cha.EquipItem(weapon);
            }
            catch (InvalidWeaponException ex)
            {
                result = ex.Message;
            }
            Console.WriteLine("You try to equip a " + weapon.Name);
            Console.WriteLine(result);
            Console.WriteLine("Press enter!");
            Console.ReadLine();
            
        }

        private static void EquipRandomArmor(ItemTests items, Character cha)
        {
            Random rnd = new();
            string result;
            Armor armor = items.ArmorList[rnd.Next(0, items.ArmorList.Count)];
            try
            {
                result = cha.EquipItem(armor);
            } catch(InvalidArmorException ex)
            {
                result = ex.Message;
            }
            Console.WriteLine("You try to equip a " + armor.Name);
            Console.WriteLine(result);
            Console.WriteLine("Press enter!");
            Console.ReadLine();
           
            

        }
    }
}
