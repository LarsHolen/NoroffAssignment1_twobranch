using NoroffAssignment1.System.Characters.Attributes;
using NoroffAssignment1.System.Enums;
using System;
using System.Collections.Generic;

namespace NoroffAssignment1.System.Equipment.Items
{
    public class ItemTests
    {
        /// <summary>
        /// A test class, holding two lists of armor and weapon items.
        /// </summary>

        public List<Weapon> WeaponList = new();
        public List<Armor> ArmorList = new();
        public Weapon Axe { get; set; } = new Weapon() 
        {
            Name = "Common axe", 
            RequiredLevel = 1,
            FitInEquipmentSlot = EquipmentSlots.WEAPON,
            WeaponType = WeaponType.AXE,
            WeaponAttribute = new WeaponAttributes() { BaseDamage = 7, AttacksPerSecond = 1.1f}
        };
        
        public Weapon Sword { get; set; } = new Weapon()
        {
            Name = "Sword of truth",
            RequiredLevel = 2,
            FitInEquipmentSlot = EquipmentSlots.WEAPON,
            WeaponType = WeaponType.SWORD,
            WeaponAttribute = new WeaponAttributes() { BaseDamage = 17, AttacksPerSecond = 2.1f }
        };
        public Weapon Dagger { get; set; } = new Weapon()
        {
            Name = "Dagger of the backstabber",
            RequiredLevel = 1,
            FitInEquipmentSlot = EquipmentSlots.WEAPON,
            WeaponType = WeaponType.DAGGER,
            WeaponAttribute = new WeaponAttributes() { BaseDamage = 27, AttacksPerSecond = 0.8f }
        };
        public Weapon Wand { get; set; } = new Weapon()
        {
            Name = "Wand of prismatic spray",
            RequiredLevel = 1,
            FitInEquipmentSlot = EquipmentSlots.WEAPON,
            WeaponType = WeaponType.WAND,
            WeaponAttribute = new WeaponAttributes() { BaseDamage = 70, AttacksPerSecond = 0.1f }
        };

        public Weapon Bow { get; set; } = new Weapon()
        {
            Name = "Common bow",
            RequiredLevel = 1,
            FitInEquipmentSlot = EquipmentSlots.WEAPON,
            WeaponType = WeaponType.BOW,
            WeaponAttribute = new WeaponAttributes() { BaseDamage = 12, AttacksPerSecond = 0.8f }
        };
        public Armor PlateArmor { get; set; } = new Armor()
        {
            Name = "Common Plate body armor",
            RequiredLevel = 1,
            FitInEquipmentSlot = EquipmentSlots.BODY,
            ArmorType = ArmorType.ARMOR_PLATE,
            ItemBonusAttributes = new PrimaryAttributes() { Vitality = 2, Strength = 1 }
        };
        public Armor ClothHead { get; set; } = new Armor()
        {
            Name = "Common cloth head armor",
            RequiredLevel = 1,
            FitInEquipmentSlot = EquipmentSlots.HEAD,
            ArmorType = ArmorType.ARMOR_CLOTH,
            ItemBonusAttributes = new PrimaryAttributes() { Vitality = 2, Strength = 1 }
        };

        public Armor ClothBody{ get; set; } = new Armor()
        {
            Name = "Brittanys wedding dress",
            RequiredLevel = 2,
            FitInEquipmentSlot = EquipmentSlots.BODY,
            ArmorType = ArmorType.ARMOR_CLOTH,
            ItemBonusAttributes = new PrimaryAttributes() { Vitality = 4, Strength = 30 }
        };
        public Armor ClothLegs { get; set; } = new Armor()
        {
            Name = "A pair of wool pants.",
            RequiredLevel = 1,
            FitInEquipmentSlot = EquipmentSlots.LEGS,
            ArmorType = ArmorType.ARMOR_CLOTH,
            ItemBonusAttributes = new PrimaryAttributes() { Intelligence = 1 }
        };

        public Armor PlateHelm { get; set; } = new Armor()
        {
            Name = "Steel bucket",
            RequiredLevel = 1,
            FitInEquipmentSlot = EquipmentSlots.HEAD,
            ArmorType = ArmorType.ARMOR_PLATE,
            ItemBonusAttributes = new PrimaryAttributes() { Vitality = 4, Strength = 3 }
        };
        public Armor PlateLegs { get; set; } = new Armor()
        {
            Name = "Steel pipe leggings",
            RequiredLevel = 2,
            FitInEquipmentSlot = EquipmentSlots.LEGS,
            ArmorType = ArmorType.ARMOR_PLATE,
            ItemBonusAttributes = new PrimaryAttributes() { Vitality = 14, Strength = 13 }
        };


        public Armor MailHead { get; set; } = new Armor()
        {
            Name = "Banded helm",
            RequiredLevel = 1,
            FitInEquipmentSlot = EquipmentSlots.HEAD,
            ArmorType = ArmorType.ARMOR_MAIL,
            ItemBonusAttributes = new PrimaryAttributes() { Vitality = 2, Strength = 1 }
        };

        public Armor MailBody { get; set; } = new Armor()
        {
            Name = "Steel chain net",
            RequiredLevel = 1,
            FitInEquipmentSlot = EquipmentSlots.BODY,
            ArmorType = ArmorType.ARMOR_MAIL,
            ItemBonusAttributes = new PrimaryAttributes() { Vitality = 40, Strength = 3 }
        };
        public Armor MailLegs { get; set; } = new Armor()
        {
            Name = "Steel ring pants",
            RequiredLevel = 2,
            FitInEquipmentSlot = EquipmentSlots.LEGS,
            ArmorType = ArmorType.ARMOR_MAIL,
            ItemBonusAttributes = new PrimaryAttributes() { Dexterity = 15 }
        };

        public Armor LeatherHead { get; set; } = new Armor()
        {
            Name = "Rudolf skin helm",
            RequiredLevel = 1,
            FitInEquipmentSlot = EquipmentSlots.HEAD,
            ArmorType = ArmorType.ARMOR_LEATHER,
            ItemBonusAttributes = new PrimaryAttributes() { Vitality = 2, Dexterity = 10 }
        };

        public Armor LeatherBody { get; set; } = new Armor()
        {
            Name = "Human skin breastplate",
            RequiredLevel = 1,
            FitInEquipmentSlot = EquipmentSlots.BODY,
            ArmorType = ArmorType.ARMOR_LEATHER,
            ItemBonusAttributes = new PrimaryAttributes() { Vitality = 40, Strength = 30 }
        };
        public Armor LeatherLegs { get; set; } = new Armor()
        {
            Name = "Frog skin pants",
            RequiredLevel = 2,
            FitInEquipmentSlot = EquipmentSlots.LEGS,
            ArmorType = ArmorType.ARMOR_LEATHER,
            ItemBonusAttributes = new PrimaryAttributes() { Dexterity = 55 }
        };

        public ItemTests()
        {
            WeaponList.Add(Bow);
            WeaponList.Add(Wand);
            WeaponList.Add(Dagger);
            WeaponList.Add(Sword);
            WeaponList.Add(Axe);

            ArmorList.Add(PlateArmor);
            ArmorList.Add(PlateHelm);
            ArmorList.Add(PlateLegs);
            ArmorList.Add(ClothHead);
            ArmorList.Add(ClothLegs);
            ArmorList.Add(ClothBody);
            ArmorList.Add(MailHead);
            ArmorList.Add(MailLegs);
            ArmorList.Add(MailBody);
            ArmorList.Add(LeatherHead);
            ArmorList.Add(LeatherLegs);
            ArmorList.Add(LeatherBody);

        }
    }
}
