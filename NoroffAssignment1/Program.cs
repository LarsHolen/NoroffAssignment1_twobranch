using NoroffAssignment1.System;
using NoroffAssignment1.System.Characters;
using NoroffAssignment1.System.Enums;
using NoroffAssignment1.System.Equipment.Items;
using System;


namespace NoroffAssignment1
{

    class Program
    {

        static void Main()
        {
            /*
            Shows a charactersheet and let the user try to equip random armor/weapons, 
            and level up the character.    
            */
            
            bool loop = true;
            string input;
           
            // Using the factory to create a character
            Character war = CharacterFactory.MakeCharacter(CharacterType.WARRIOR, "Haladan");

            // Using CharacterStatsDisplay to show character stats on console.  Using a new class rather than overriding ToString
            CharacterStatsDisplay characterSheet = new(war);
          
            // Adding a little interactivity to show that leveling and gearing up works
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
                if (input == "a" || input == "A") EquipRandomArmor(war);
                if (input == "w" || input == "W") EquipRandomWeapon(war);
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
        private static void EquipRandomWeapon(Character cha)
        {
            string result;
            Weapon weapon = ItemFactory.GetRandomWeapon();
            try
            {
                result = cha.EquipmentHandler.EquipItem(weapon, cha.Level);
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

        private static void EquipRandomArmor(Character cha)
        {
            string result;
            Armor armor = ItemFactory.GetRandomArmor();
            try
            {
                result = cha.EquipmentHandler.EquipItem(armor, cha.Level);
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
