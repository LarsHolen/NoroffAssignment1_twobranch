using NoroffAssignment1.Characters.Attributes;
using System;

namespace NoroffAssignment1.Characters.Items
{
    public class ItemTests
    {
        public Weapon Axe { get; set; } = new Weapon() 
        {
            Name = "Common axe", 
            RequiredLevel = 1,
            FitInEquipmentSlot = EquipmentSlots.WEAPON,
            WeaponType = WeaponType.AXE,
            WeaponAttribute = new WeaponAttributes() { BaseDamage = 7, AttacksPerSecond = 1.1f}
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
    }
}
