﻿using NoroffAssignment1.System;
using NoroffAssignment1.System.Characters;
using NoroffAssignment1.System.Characters.Attributes;
using NoroffAssignment1.System.Enums;
using NoroffAssignment1.System.Equipment.Items;
using Xunit;

namespace DiabloTestProject
{
    public class ItemAndEquipmentTests
    {
        #region Equipping a too high level weapon throws InvalidWeaponException 
        [Fact]
        public void EquippingTooHighLevelWeaponThrowsException()
        {
            // Arrange
            Character war = CharacterFactory.MakeCharacter(CharacterType.WARRIOR, "Haladan");
            Weapon testAxe = new()
            {
                Name = "Axe of Misery",
                RequiredLevel = 2,
                FitInEquipmentSlot = EquipmentSlots.WEAPON,
                WeaponType = WeaponType.AXE,
                WeaponAttribute = new WeaponAttributes() { BaseDamage = 7, AttacksPerSecond = 1.1 }
                
            };
            string expected = "This character is too low level for this weapon.";
       
            // Act
            void act() => war.EquipmentHandler.EquipItem(testAxe, war.Level);
            InvalidWeaponException exception = Assert.Throws<InvalidWeaponException>(act);

            // Assert
            Assert.Equal(expected, exception.Message);
        }
        #endregion

        #region Equipping too high level armor throws InvaligArmorException 
        [Fact]
        public void EquippingTooHighLevelArmorThrowsException()
        {
            // Arrange
            Character war = CharacterFactory.MakeCharacter(CharacterType.WARRIOR, "Haladan");
            Armor testPlateBody = new()
            {
                Name = "Armor of god",
                RequiredLevel = 2,
                FitInEquipmentSlot = EquipmentSlots.BODY,
                ArmorType = ArmorType.ARMOR_PLATE,
                ItemBonusAttributes = new PrimaryAttributes() { Vitality = 2, Strength = 1 }
            };
            string expected = "This character is too low level to use this armor.";

            // Act
            void act() => war.EquipmentHandler.EquipItem(testPlateBody, war.Level);
            InvalidArmorException exception = Assert.Throws<InvalidArmorException>(act);

            // Assert
            Assert.Equal(expected, exception.Message);
        }
        #endregion

        #region Equipping wrong weapon type throws InvalidWeaponException 
        [Fact]
        public void EquippingWrongWeaponTypeThrowsException()
        {
            // Arrange
            Character war = CharacterFactory.MakeCharacter(CharacterType.WARRIOR, "Haladan");
            Weapon testBow = new()
            {
                Name = "Bow of the destroyer",
                RequiredLevel = 1,
                FitInEquipmentSlot = EquipmentSlots.WEAPON,
                WeaponType = WeaponType.BOW,
                WeaponAttribute = new WeaponAttributes() { BaseDamage = 12, AttacksPerSecond = 0.8 }
            };
            string expected = "This class can not use this weapon.";

            // Act
            void act() => war.EquipmentHandler.EquipItem(testBow, war.Level);
            InvalidWeaponException exception = Assert.Throws<InvalidWeaponException>(act);

            // Assert
            Assert.Equal(expected, exception.Message);
        }
        #endregion

        #region Equipping wrong type armor throws InvaligArmorException 
        [Fact]
        public void EquippingWrongTypeArmorThrowsException()
        {
            // Arrange
            Character war = CharacterFactory.MakeCharacter(CharacterType.WARRIOR, "Haladan");
            Armor testClothHead = new()
            {
                Name = "Wool cap",
                RequiredLevel = 1,
                FitInEquipmentSlot = EquipmentSlots.HEAD,
                ArmorType = ArmorType.ARMOR_CLOTH,
                ItemBonusAttributes = new PrimaryAttributes() { Vitality = 1, Intelligence = 5 }
            };
            string expected = "This class can not use this armor.";

            // Act
            void act() => war.EquipmentHandler.EquipItem(testClothHead, war.Level);
            InvalidArmorException exception = Assert.Throws<InvalidArmorException>(act);

            // Assert
            Assert.Equal(expected, exception.Message);
        }
        #endregion

        #region Equipping weapon return string "New weapon equipped!"
        [Fact]
        public void EquippingWeaponReturnString()
        {
            // Arrange
            Character war = CharacterFactory.MakeCharacter(CharacterType.WARRIOR, "Haladan");
            Weapon testAxe = new()
            {
                Name = "Axe of Demogorgon",
                RequiredLevel = 1,
                FitInEquipmentSlot = EquipmentSlots.WEAPON,
                WeaponType = WeaponType.AXE,
                WeaponAttribute = new WeaponAttributes() { BaseDamage = 7, AttacksPerSecond = 1.1f }
            };
            string expected = "New weapon equipped!";

            // Act
            string actual = war.EquipmentHandler.EquipItem(testAxe, war.Level);
            
            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region Equipping armor return string "New armor equipped!"
        [Fact]
        public void EquippingArmorReturnString()
        {
            // Arrange
            Character war = CharacterFactory.MakeCharacter(CharacterType.WARRIOR, "Haladan");
            Armor testArmor = new()
            {
                Name = "Armor of Rallos Zek",
                RequiredLevel = 1,
                FitInEquipmentSlot = EquipmentSlots.BODY,
                ArmorType = ArmorType.ARMOR_PLATE,
                ItemBonusAttributes = new PrimaryAttributes() { Vitality = 12, Strength = 21 }
            };
            string expected = "New armor equipped!";

            // Act
            string actual = war.EquipmentHandler.EquipItem(testArmor, war.Level);

            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region Calculate DPS for naked, unarmed warrior 
        [Fact]
        public void CalculateDPSForNewNakedAndUnarmedWarrior()
        {
            // Arrange
            double expected = 1.0 * (1.0 + (5.0 / 100.0));

            // Act
            Character war = CharacterFactory.MakeCharacter(CharacterType.WARRIOR, "Haladan");

            // Assert
            Assert.Equal(expected, war.Dps);
        }
        #endregion

        #region Calculate DPS for naked, armed warrior 
        [Fact]
        public void CalculateDPSForNewNakedButArmedWithAxeWarrior()
        {
            // Arrange
            double expected = (7.0 * 1.1) * (1.0 + (5.0 / 100.0));
            Character war = CharacterFactory.MakeCharacter(CharacterType.WARRIOR, "Haladan");
            Weapon testAxe = new()
            {
                Name = "Axe of Mayhem",
                RequiredLevel = 1,
                FitInEquipmentSlot = EquipmentSlots.WEAPON,
                WeaponType = WeaponType.AXE,
                WeaponAttribute = new WeaponAttributes() { BaseDamage = 7, AttacksPerSecond = 1.1 }
            };

            // Act
            war.EquipmentHandler.EquipItem(testAxe, war.Level);
           

            // Assert
            Assert.Equal(expected, war.Dps);
        }
        #endregion

        #region Calculate DPS for armored and  armed warrior 
        [Fact]
        public void CalculateDPSForNewArmoredAndArmedWithAxeWarrior()
        {
            // Arrange
            double expected = (7.0 * 1.1) * (1.0 + ((5.0 + 1.0) / 100.0));
            Character war = CharacterFactory.MakeCharacter(CharacterType.WARRIOR, "Haladan");
            Weapon testAxe = new()
            {
                Name = "Axe of Mayhem",
                RequiredLevel = 1,
                FitInEquipmentSlot = EquipmentSlots.WEAPON,
                WeaponType = WeaponType.AXE,
                WeaponAttribute = new WeaponAttributes() { BaseDamage = 7, AttacksPerSecond = 1.1 }
            };
            Armor testPlateBody = new()
            {
                Name = "Armor of god",
                RequiredLevel = 1,
                FitInEquipmentSlot = EquipmentSlots.BODY,
                ArmorType = ArmorType.ARMOR_PLATE,
                ItemBonusAttributes = new PrimaryAttributes() { Vitality = 2, Strength = 1 }
            };

            // Act
            war.EquipmentHandler.EquipItem(testAxe, war.Level);
            war.EquipmentHandler.EquipItem(testPlateBody, war.Level);

            // Assert
            Assert.Equal(expected, war.Dps);
        }
        #endregion
    }
}
