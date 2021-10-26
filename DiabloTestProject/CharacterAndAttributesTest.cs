using System;
using Xunit;
using NoroffAssignment1.System.Characters.Attributes;
using NoroffAssignment1.System.Characters;
using NoroffAssignment1.System.Enums;
using NoroffAssignment1.System;

namespace DiabloTestProject
{
    public class CharacterAndAttributesTest
    {
        #region PrimaryAttributes 
        [Fact]
        public void PrimaryAttributes_addition()
        {
            // Arrange
            int Attribute = 10;
            PrimaryAttributes pa1 = new() { Strength = Attribute, Intelligence = Attribute, Vitality = Attribute, Dexterity = Attribute };
            PrimaryAttributes pa2 = new() { Strength = Attribute, Intelligence = Attribute, Vitality = Attribute, Dexterity = Attribute };
            int expectedAttribute = pa1.Strength + pa2.Strength;

            // Act
            PrimaryAttributes pa3 = pa1 + pa2;
            int actual = pa3.Strength;

            // Assert
            Assert.Equal(expectedAttribute, actual);
        }
        #endregion

        #region  1) Character creation, character is level 1
        [Fact]
        public void CreationOfWarriorClass_LevelIsOne()
        {
            // Arrange
            int expectedLevel = 1;

            //Act
            Character war = CharacterFactory.MakeCharacter(CharacterType.WARRIOR, "Haladan");

            //Assert
            Assert.Equal(expectedLevel, war.Level);
        }
        #endregion

        #region 2) and 3) Character gain one level at lvl one, new level is two.  ArgumentException with input 0 or less
        [Fact]
        public void WarriorClass_LevelUp_from_levelOne_to_levelTwo()
        {
            // Arrange
            int expectedNewLevel = 2;
            Character war = CharacterFactory.MakeCharacter(CharacterType.WARRIOR, "Haladan");

            //Act
            war.LevelUp(1);

            //Assert
            Assert.Equal(expectedNewLevel, war.Level);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WarriorClass_LevelUp_zeroOrLess(int value)
        {
            // Arrange
            Character war = CharacterFactory.MakeCharacter(CharacterType.WARRIOR, "Haladan");
            string expected = "Zero or negative input not legal";

            // Act
            void act() => war.LevelUp(value);
            ArgumentException exception = Assert.Throws<ArgumentException>(act);

            // Assert
            Assert.Equal(expected, exception.Message);
        }

        #endregion

        #region 4) Classes are created with correct PrimaryAttributes
        [Fact]
        public void CreateWarriorWithCorrectBasePrimaryAttributes()
        {
            // Arrange
            PrimaryAttributes expected = new() { Intelligence = 1, Dexterity = 2, Strength = 5, Vitality = 10 };

            //Act
            Character war = CharacterFactory.MakeCharacter(CharacterType.WARRIOR, "Haladan");

            //Assert
            Assert.True(expected.Equals(war.PrimaryAttributesBase));
        }

        [Fact]
        public void CreateMageWithCorrectBasePrimaryAttributes()
        {
            // Arrange
            PrimaryAttributes expected = new() { Vitality = 5, Strength = 1, Dexterity = 1, Intelligence = 8 };

            //Act
            Character mag = CharacterFactory.MakeCharacter(CharacterType.MAGE, "Binkol");

            //Assert
            Assert.True(expected.Equals(mag.PrimaryAttributesBase));
        }

        [Fact]
        public void CreateRangerWithCorrectBasePrimaryAttributes()
        {
            // Arrange
            PrimaryAttributes expected = new() { Intelligence = 1, Dexterity = 7, Strength = 1, Vitality = 8 };

            //Act
            Character ran = CharacterFactory.MakeCharacter(CharacterType.RANGER, "Sinolas");

            //Assert
            Assert.True(expected.Equals(ran.PrimaryAttributesBase));
        }

        [Fact]
        public void CreateRogueWithCorrectBasePrimaryAttributes()
        {
            // Arrange
            PrimaryAttributes expected = new() { Vitality = 8, Strength = 2, Dexterity = 6, Intelligence = 1 };

            //Act
            Character rog = CharacterFactory.MakeCharacter(CharacterType.ROGUE, "Zindy");

            //Assert
            Assert.True(expected.Equals(rog.PrimaryAttributesBase));
        }
        #endregion

        #region 5) Classes level up to level 2 with correct increase in PrimaryAttributes
        [Fact]
        public void LevelWarriorWithCorrectBasePrimaryAttributes()
        {
            // Arrange
            PrimaryAttributes expected = new() { Dexterity = 4, Intelligence = 2, Strength = 8, Vitality = 15 };
            Character war = CharacterFactory.MakeCharacter(CharacterType.WARRIOR, "Haladan");

            //Act
            war.LevelUp(1);

            //Assert
            Assert.True(expected.Equals(war.PrimaryAttributesBase));
        }
        [Fact]
        public void LevelMageWithCorrectBasePrimaryAttributes()
        {
            // Arrange
            PrimaryAttributes expected = new() { Vitality = 8, Strength = 2, Dexterity = 2, Intelligence = 13 };
            Character mag = CharacterFactory.MakeCharacter(CharacterType.MAGE, "Binkol");

            //Act
            mag.LevelUp(1);

            //Assert
            Assert.True(expected.Equals(mag.PrimaryAttributesBase));
        }
        [Fact]
        public void LevelRangerWithCorrectBasePrimaryAttributes()
        {
            // Arrange
            PrimaryAttributes expected = new() { Dexterity = 12, Intelligence = 2, Strength = 2, Vitality = 10 };
            Character ran = CharacterFactory.MakeCharacter(CharacterType.RANGER, "Sinolas");

            //Act
            ran.LevelUp(1);

            //Assert
            Assert.True(expected.Equals(ran.PrimaryAttributesBase));
        }
        [Fact]
        public void LevelRogueWithCorrectBasePrimaryAttributes()
        {
            // Arrange           
            PrimaryAttributes expected = new() { Dexterity = 10, Intelligence = 2, Strength = 3, Vitality = 11 };
            Character rog = CharacterFactory.MakeCharacter(CharacterType.ROGUE, "Zindy");

            //Act
            rog.LevelUp(1);

            //Assert
            Assert.True(expected.Equals(rog.PrimaryAttributesBase));
        }
        #endregion

        #region Calculate Secondary stats from a levelled up character(warrior)
        [Fact]
        public void CalculatingSecondaryAttributesFromALevelledWarrior()
        {
            // Arrange
            SecondaryAttributes expected = new(new PrimaryAttributes() { Strength = 0, Vitality = 0, Intelligence = 0, Dexterity = 0 });
            expected.Health = 150;
            expected.ArmorRating = 12;
            expected.ElementalResistance = 2;

            // Act
            Character war = CharacterFactory.MakeCharacter(CharacterType.WARRIOR, "Haladan");
            war.LevelUp(1);

            // Assert
            Assert.True(expected.Equals(war.SecondaryAttributesTotal));
        }
        #endregion
    }
}
