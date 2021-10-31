using NoroffAssignment1.System.Characters.Attributes;
using NoroffAssignment1.System.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NoroffAssignment1.System.Equipment.Items
{
    public static class ItemFactory
    {
        /// <summary>
        /// This returns Armor according to parameters
        /// </summary>
        /// <param name="name"></param>
        /// <param name="requiredLevel"></param>
        /// <param name="armorType"></param>
        /// <param name="itemBonusAttributes"></param>
        /// <param name="fitInEquipmentSlots"></param>
        /// <returns></returns>
        public static Armor MakeArmor(string name, int requiredLevel, ArmorType armorType, PrimaryAttributes itemBonusAttributes, EquipmentSlots fitInEquipmentSlots)
        {
            Armor armor = new()
            {
                Name = name,
                RequiredLevel = requiredLevel,
                ArmorType = armorType,
                ItemBonusAttributes = itemBonusAttributes,
                FitInEquipmentSlot = fitInEquipmentSlots
            };
            return armor;
        }
       
        /// <summary>
        /// This returns a weapon according to the parameters 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="requiredLevel"></param>
        /// <param name="weaponType"></param>
        /// <param name="itemBonusAttributes"></param>
        /// <param name="weaponAttribute"></param>
        /// <returns></returns>
        public static Weapon MakeWeapon(string name, int requiredLevel, WeaponType weaponType, PrimaryAttributes itemBonusAttributes, WeaponAttributes weaponAttribute)
        {
            Weapon weapon = new()
            {
                Name = name,
                RequiredLevel = requiredLevel,
                WeaponType = weaponType,
                ItemBonusAttributes = itemBonusAttributes,
                FitInEquipmentSlot = EquipmentSlots.WEAPON,
                WeaponAttribute = weaponAttribute
                
            };
            return weapon;
        }

        /// <summary>
        /// This returns a randomly generated weapon 
        /// </summary>
        /// <returns>Weapon</returns>        
        public static Weapon GetRandomWeapon()
        {
            Random random = new();

            // lvl Keeping it narrow
            int requiredLevel = random.Next(1,2);

            // random weapontype:      
            Array values = Enum.GetValues(typeof(WeaponType));
            string name = "";
            WeaponType weaponType = (WeaponType)values.GetValue(random.Next(values.Length));

            // itembonus PA
            PrimaryAttributes itembonus = new() {
                Dexterity = random.Next(1, 10),
                Strength = random.Next(1, 10),
                Intelligence = random.Next(1, 10),
                Vitality = random.Next(1, 10)
            };

            //FitInSlot allways Weaponslot

            //Weapon attribute
            WeaponAttributes weaponAttributes = new() { AttacksPerSecond = random.NextDouble() * 5, BaseDamage = random.NextDouble() * 30 };
            
            // name genarator depending on stats

            // Name part depending on vitality
            switch(itembonus.Vitality)
            {
                case int vit when vit >= 9:
                    name += "Giant sized,";
                    break;
                case int vit when vit > 7:
                    name += "Large sized,";
                    break;
                case int vit when vit > 4:
                    name += "Normal sized,";
                    break;
                case int vit when vit > 2:
                    name += "Small sized,";
                    break;
                case int vit when vit <= 2:
                    name += "Tiny sized,";
                    break;
                default:
                    break;
            }

            // Name part depending on Strength
            switch (itembonus.Strength)
            {
                case int vit when vit >= 9:
                    name += " Powerful";
                    break;
                case int vit when vit > 7:
                    name += " Athletic";
                    break;
                case int vit when vit > 4:
                    name += " Fit";
                    break;
                case int vit when vit > 2:
                    name += " Weak";
                    break;
                case int vit when vit <= 2:
                    name += " Feeble";
                    break;
                default:
                    break;
            }

            // Name part depending on Intelligence
            switch (itembonus.Intelligence)
            {
                case int vit when vit >= 9:
                    name += " and Genious";
                    break;
                case int vit when vit > 7:
                    name += " and wise";
                    break;
                case int vit when vit > 4:
                    name += " and Intelligent";
                    break;
                case int vit when vit > 2:
                    name += " and the Silly";
                    break;
                case int vit when vit <= 2:
                    name += " and the Idiotic";
                    break;
                default:
                    break;
            }

            // Name part depending on Type
            switch (weaponType)
            {
                case WeaponType.AXE:
                    name += " Axe";
                    break;
                case WeaponType.BOW:
                    name += " Bow";
                    break;
                case WeaponType.DAGGER:
                    name += " Dagger";
                    break;
                case WeaponType.HAMMER:
                    name += " Hammer";
                    break;
                case WeaponType.STAFF:
                    name += " Staff";
                    break;
                case WeaponType.SWORD:
                    name += " Sword";
                    break;
                case WeaponType.WAND:
                    name += " Wand";
                    break;
                default:
                    break;
            }

            // Name part depending on Dexterity
            switch (itembonus.Dexterity)
            {
                case int vit when vit >= 9:
                    name += "  of the Quick";
                    break;
                case int vit when vit > 7:
                    name += " of the Able";
                    break;
                case int vit when vit > 4:
                    name += " of the Capable";
                    break;
                case int vit when vit > 2:
                    name += " of the slow";
                    break;
                case int vit when vit <= 2:
                    name += " of the Unhurried";
                    break;
                default:
                    break;
            }


            return MakeWeapon(name, requiredLevel, weaponType, itembonus, weaponAttributes);
        }

        /// <summary>
        /// Returns a randomly generated armor 
        /// </summary>
        /// <returns>Armor</returns>
        public static Armor GetRandomArmor()
        {
            Random random = new();
            string name = "";
            // Required level randomizer, 1-2 for testing
            int requiredLevel = random.Next(1, 2);

            // random armortype:      
            Array values = Enum.GetValues(typeof(ArmorType));
            ArmorType armorType = (ArmorType)values.GetValue(random.Next(values.Length));

            // itembonus PA
            PrimaryAttributes itembonusAttributes = new()
            {
                Dexterity = random.Next(1, 10),
                Strength = random.Next(1, 10),
                Intelligence = random.Next(1, 10),
                Vitality = random.Next(1, 10)
            };

            // random slot:      
            values = Enum.GetValues(typeof(EquipmentSlots));
            EquipmentSlots fitInEquipmentSlots = (EquipmentSlots)values.GetValue(random.Next(values.Length));
            if (fitInEquipmentSlots == EquipmentSlots.WEAPON) fitInEquipmentSlots = EquipmentSlots.BODY;

            // Name part depending on Slot
            switch (fitInEquipmentSlots)
            {
                case EquipmentSlots.HEAD:
                    if (armorType == ArmorType.ARMOR_PLATE) name += "Helmet";
                    if (armorType == ArmorType.ARMOR_CLOTH) name += "Pointy hat";
                    if (armorType == ArmorType.ARMOR_MAIL) name += "Chain hood";
                    if (armorType == ArmorType.ARMOR_LEATHER) name += "Leather cap";
                    break;
                case EquipmentSlots.BODY:
                    if(armorType == ArmorType.ARMOR_PLATE) name += "Breastplate";
                    if (armorType == ArmorType.ARMOR_CLOTH) name += "Cloth dress";
                    if (armorType == ArmorType.ARMOR_MAIL) name += "Chainmail";
                    if(armorType == ArmorType.ARMOR_LEATHER) name += "Leather Torso";
                    break;
                case EquipmentSlots.LEGS:
                    if (armorType == ArmorType.ARMOR_PLATE) name += "Steel Greaves";
                    if (armorType == ArmorType.ARMOR_CLOTH) name += "Cloth stockings";
                    if (armorType == ArmorType.ARMOR_MAIL) name += "Chainmail pants";
                    if (armorType == ArmorType.ARMOR_LEATHER) name += "Leather Greaves";
                    break;
                default:
                    break;
            }

            // Shorten down name, by selecting the higher stat
            Dictionary<string, int> paPairs = new(){ };
            paPairs.Add("Strength", itembonusAttributes.Strength);
            paPairs.Add("Vitality", itembonusAttributes.Vitality);
            paPairs.Add("Dexterity", itembonusAttributes.Dexterity);
            paPairs.Add("Intelligence", itembonusAttributes.Intelligence);

            string maxAttrib = paPairs.FirstOrDefault(x => x.Value == paPairs.Values.Max()).Key;

            switch (maxAttrib)
            {
                case "Strength":
                    if (itembonusAttributes.Strength > 7)
                    {
                        name += " of the Strong";
                    }
                    else if (itembonusAttributes.Strength < 3)
                    {
                        name += " of the Feeble";
                    } else
                    {
                        name += " of the Common";
                    }
                    break;
                case "Dexterity":
                    if (itembonusAttributes.Dexterity > 7)
                    {
                        name += " of the Nimble";
                    }
                    else if (itembonusAttributes.Dexterity < 3)
                    {
                        name += " of the Slow";
                    }
                    else
                    {
                        name += " of the Common";
                    }
                    break;
                case "Vitality":
                    if (itembonusAttributes.Vitality > 7)
                    {
                        name += " of the Beefy";
                    }
                    else if (itembonusAttributes.Vitality < 3)
                    {
                        name +=  "of the Sickly";
                    }
                    else
                    {
                        name += " of the Common";
                    }
                    break;
                case "Intelligence":
                    if (itembonusAttributes.Intelligence > 7)
                    {
                        name += " of the Genious";
                    }

                    else if (itembonusAttributes.Intelligence < 3)
                    {
                        name += " of the Idiotic";
                    }
                    else
                    {
                        name += " of the Common";
                    }
                    break;
                default:
                    break;
            }

            return MakeArmor(name, requiredLevel, armorType, itembonusAttributes, fitInEquipmentSlots);
        }

    }






}
