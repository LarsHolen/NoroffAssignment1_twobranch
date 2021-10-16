using NoroffAssignment1.Characters.Attributes;
using NoroffAssignment1.Characters.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroffAssignment1.Characters
{
    public abstract class Character
    {
        public string Name { get; set; }
        public int Level { get; set; } = 1;
        public PrimaryAttributes BasePrimaryAttributes { get; set; }
        public PrimaryAttributes TotalPrimaryAttributes { get; set; }
        public SecondaryAttributes SecondaryAttributes { get; set; }
        public SecondaryAttributes SecondaryAttributesGetHurt { get; set; }
        public float Dps;
        public float DamagePrimaryStat;

        public PrimaryAttributes StartPrimaryArrtibutes { get; set; }
        public PrimaryAttributes LevelUpPrimaryAttributes { get; set; }

        public Dictionary<WeaponType, int> UsableWeaponTypes = new Dictionary<WeaponType, int>();
        public Dictionary<ArmourType, int> UsableArmorTypes = new Dictionary<ArmourType, int>();

        public Dictionary<EquipmentSlots, Item> EquippedItems { get; set; } = new Dictionary<EquipmentSlots, Item>();
        
        public Character()
        {
            EquippedItems.Add(EquipmentSlots.HEAD, null);
            EquippedItems.Add(EquipmentSlots.BODY, null);
            EquippedItems.Add(EquipmentSlots.LEGS, null);
            EquippedItems.Add(EquipmentSlots.WEAPON, null);

        }


        /// <summary>
        /// Adds int l to Level and increase the BasePrimaryAttributes
        /// (Level-1 because the first level increase the PrimaryAttributes by StartPrimaryAttributes)
        /// 0 or less is not leagal input and throws exception
        /// Calls SetTotalAttributes, to update TotalAttributes(Which in turn update SecondaryAttributes)
        /// </summary>
        /// <param name="l"></param>
        public void LevelUp(int l)
        {
            if(l > 0)
            {
                Level += l;
                BasePrimaryAttributes = StartPrimaryArrtibutes + ((Level-1) * LevelUpPrimaryAttributes);
                SetTotalAttributes();
            } else
            {
                throw new ArgumentException("Zero or negative input not legal");
            }
            
        }

        /// <summary>
        /// Updates TotalAttributes, by including PAs on items
        /// Calls SetSecondaryAttributes when done to update that
        /// </summary>
        public void SetTotalAttributes()
        {
            // Add up TotalAttribs from base and items
            TotalPrimaryAttributes = new PrimaryAttributes();
            TotalPrimaryAttributes += BasePrimaryAttributes;
            // Looping through EquippedItems and add bonusstats to TotalPrimaryAttributes
            
            foreach (KeyValuePair<EquipmentSlots, Item> pair in EquippedItems)
            {
                if(pair.Value != null) TotalPrimaryAttributes += pair.Value.ItemBonusAttributes;

            }
                       
            // Set SecondaryAttributes
            SetSecondaryAttributes();
            
        }
        
        /// <summary>
        /// Calculate SecondaryAttributes from TotalAttributes
        /// </summary>
        private void SetSecondaryAttributes()
        {
            if(SecondaryAttributes == null)
            {
                SecondaryAttributes = new SecondaryAttributes(TotalPrimaryAttributes);
            }
            else
            {
                SecondaryAttributes.Update(TotalPrimaryAttributes);
            }

            SetDPS();
        }

        private void SetDPS()
        {
            switch(this.GetType().Name)
            {
                case "Warrior":
                    DamagePrimaryStat = TotalPrimaryAttributes.Strength;
                    break;
                case "Mage":
                    DamagePrimaryStat = TotalPrimaryAttributes.Intelligence;
                    break;
                case "Ranger":
                    DamagePrimaryStat = TotalPrimaryAttributes.Dexterity;
                    break;
                case "Rogue":
                    DamagePrimaryStat = TotalPrimaryAttributes.Dexterity;
                    break;
                
                default:
                    throw new ArgumentException("Unable to find class damage Attribute");
            }
            float wepDmg = 1;
            if(EquippedItems[EquipmentSlots.WEAPON]!= null)
            {
                Weapon w = EquippedItems[EquipmentSlots.WEAPON] as Weapon;
                wepDmg = w.WeaponAttribute.BaseDamage * w.WeaponAttribute.AttacksPerSecond;
            }
            Dps = wepDmg * (1 + DamagePrimaryStat / 100);
        }


        /// <summary>
        /// Equip weapon or armor.  Check if class can use, and recalculate stats after equipping
        /// </summary>
        /// <param name="weapon"></param>
        public void EquipItem(Weapon weapon)
        {
           if(UsableWeaponTypes.ContainsKey(weapon.WeaponType))
            {
                EquippedItems[EquipmentSlots.WEAPON] = weapon;
                SetTotalAttributes();
            } else
            {
                throw new NotImplementedException();
            }
        }
        public void EquipItem(Armor armor)
        {
            if(UsableArmorTypes.ContainsKey(armor.ArmorType))
            {
                EquippedItems[armor.FitInEquipmentSlot] = armor;
                SetTotalAttributes();
            }
        }
    }
}
