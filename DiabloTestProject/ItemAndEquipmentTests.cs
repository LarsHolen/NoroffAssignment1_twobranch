using NoroffAssignment1.Characters;
using NoroffAssignment1.Characters.Attributes;
using NoroffAssignment1.Characters.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Warrior war = new Warrior("Haladan");
            Weapon testAxe = new Weapon()
            {
                Name = "Axe of Misery",
                RequiredLevel = 2,
                FitInEquipmentSlot = EquipmentSlots.WEAPON,
                WeaponType = WeaponType.AXE,
                WeaponAttribute = new WeaponAttributes() { BaseDamage = 7, AttacksPerSecond = 1.1f }
            };
            string expected = "This character is too low level for this weapon.";
            // Act
            Action act = () => war.EquipItem(testAxe);
            // Assert
            InvalidWeaponException exception = Assert.Throws<InvalidWeaponException>(act);
            Assert.Equal(expected, exception.Message);
        }
        #endregion

        #region Equipping too high level armor throws InvaligArmorException 
        [Fact]
        public void EquippingTooHighLevelArmorThrowsException()
        {
            // Arrange
            Warrior war = new Warrior("Haladan");
            Armor testPlateBody = new Armor()
            {
                Name = "Armor of god",
                RequiredLevel = 2,
                FitInEquipmentSlot = EquipmentSlots.BODY,
                ArmorType = ArmorType.ARMOR_PLATE,
                ItemBonusAttributes = new PrimaryAttributes() { Vitality = 2, Strength = 1 }
            };
            string expected = "This character is too low level to use this armor.";
            // Act
            Action act = () => war.EquipItem(testPlateBody);
            // Assert
            InvalidArmorException exception = Assert.Throws<InvalidArmorException>(act);
            Assert.Equal(expected, exception.Message);
        }
        #endregion

        #region Equipping wrong weapon type throws InvalidWeaponException 
        [Fact]
        public void EquippingWrongWeaponTypeThrowsException()
        {
            // Arrange
            Warrior war = new Warrior("Haladan");
            Weapon testBow = new Weapon()
            {
                Name = "Bow of the destroyer",
                RequiredLevel = 1,
                FitInEquipmentSlot = EquipmentSlots.WEAPON,
                WeaponType = WeaponType.BOW,
                WeaponAttribute = new WeaponAttributes() { BaseDamage = 12, AttacksPerSecond = 0.8f }
            };
            string expected = "This class can not use this weapon.";
            // Act
            Action act = () => war.EquipItem(testBow);
            // Assert
            InvalidWeaponException exception = Assert.Throws<InvalidWeaponException>(act);
            Assert.Equal(expected, exception.Message);
        }
        #endregion

        #region Equipping wrong type armor throws InvaligArmorException 
        [Fact]
        public void EquippingWrongTypeArmorThrowsException()
        {
            // Arrange
            Warrior war = new Warrior("Haladan");
            Armor testClothHead = new Armor()
            {
                Name = "Wool cap",
                RequiredLevel = 1,
                FitInEquipmentSlot = EquipmentSlots.HEAD,
                ArmorType = ArmorType.ARMOR_CLOTH,
                ItemBonusAttributes = new PrimaryAttributes() { Vitality = 1, Intelligence = 5 }
            };
            string expected = "This class can not use this armor.";
            // Act
            Action act = () => war.EquipItem(testClothHead);
            // Assert
            InvalidArmorException exception = Assert.Throws<InvalidArmorException>(act);
            Assert.Equal(expected, exception.Message);
        }
        #endregion



        #region PrimaryAttributes 
        [Fact]
        public void PrimaryAttributes_addition()
        {
            // Arrange

            // Act

            // Assert
            //Assert.Equal(expectedAttribute, actual);

        }
        #endregion
    }
}
