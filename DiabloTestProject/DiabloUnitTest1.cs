using System;
using Xunit;
using NoroffAssignment1.Characters.Attributes;
using NoroffAssignment1.Characters;

namespace DiabloTestProject
{
    public class DiabloUnitTest1
    {
        #region PrimaryAttributes 
        [Fact]
        public void PrimaryAttributes_addition()
        {
            // Arrange
            int Attribute = 10;
            
            PrimaryAttributes pa1 = new PrimaryAttributes() { Strength = Attribute, Intelligence = Attribute, Vitality = Attribute, Dexterity = Attribute };
            PrimaryAttributes pa2 = new PrimaryAttributes() { Strength = Attribute, Intelligence = Attribute, Vitality = Attribute, Dexterity = Attribute };
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
            Warrior war = new Warrior("Haladan");

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
            //Act
            Warrior war = new Warrior("Haladan");
            war.LevelUp(1);
            //Assert
            Assert.Equal(expectedNewLevel, war.Level);

        }
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WarriorClass_LevelUp_zeroOrLess(int value)
        {
            //arrange
            Warrior war = new Warrior("Haladan");
            string expected = "Zero or negative input not legal";
            //act
            Action act = () => war.LevelUp(value);
            //assert
            ArgumentException exception = Assert.Throws<ArgumentException>(act);
            //The thrown exception can be used for even more detailed assertions.
            Assert.Equal(expected, exception.Message);
        }

        #endregion

        #region 4) Classes are created with correct PrimaryAttributes
        [Fact]
        public void CreateWarriorWithCorrectBasePrimaryAttributes()
        {
            // Arrange
            int expectedWarriorStrength = 5;
            int expectedWarriorVitality = 10;
            int expectedWarriorDexterity = 2;
            int expectedWarriorIntelligence = 1;
            //Act
            Warrior war = new Warrior("Haladan");

            //Assert
            Assert.Equal(expectedWarriorVitality, war.BasePrimaryAttributes.Vitality);
            Assert.Equal(expectedWarriorStrength, war.BasePrimaryAttributes.Strength);
            Assert.Equal(expectedWarriorDexterity, war.BasePrimaryAttributes.Dexterity);
            Assert.Equal(expectedWarriorIntelligence, war.BasePrimaryAttributes.Intelligence);
            

        }
        [Fact]
        public void CreateMageWithCorrectBasePrimaryAttributes()
        {
            // Arrange
            int expectedMageStrength = 1;
            int expectedMageVitality = 5;
            int expectedMageDexterity = 1;
            int expectedMageIntelligence = 8;
            //Act
            Mage mag = new Mage("Binkol");

            //Assert
            Assert.Equal(expectedMageVitality, mag.BasePrimaryAttributes.Vitality);
            Assert.Equal(expectedMageStrength, mag.BasePrimaryAttributes.Strength);
            Assert.Equal(expectedMageDexterity, mag.BasePrimaryAttributes.Dexterity);
            Assert.Equal(expectedMageIntelligence, mag.BasePrimaryAttributes.Intelligence);


        }
        [Fact]
        public void CreateRangerWithCorrectBasePrimaryAttributes()
        {
            // Arrange
            int expectedRangerStrength = 1;
            int expectedRangerVitality = 8;
            int expectedRangerDexterity = 7;
            int expectedRangerIntelligence = 1;
            //Act
            Ranger ran = new Ranger("Sinolas");

            //Assert
            Assert.Equal(expectedRangerVitality, ran.BasePrimaryAttributes.Vitality);
            Assert.Equal(expectedRangerStrength, ran.BasePrimaryAttributes.Strength);
            Assert.Equal(expectedRangerDexterity, ran.BasePrimaryAttributes.Dexterity);
            Assert.Equal(expectedRangerIntelligence, ran.BasePrimaryAttributes.Intelligence);
        }
        [Fact]
        public void CreateRogueWithCorrectBasePrimaryAttributes()
        {
            // Arrange
            int expectedRogueStrength = 2;
            int expectedRogueVitality = 8;
            int expectedRogueDexterity = 6;
            int expectedRogueIntelligence = 1;
            //Act
            Rogue rog = new Rogue("Robin");

            //Assert
            Assert.Equal(expectedRogueVitality, rog.BasePrimaryAttributes.Vitality);
            Assert.Equal(expectedRogueStrength, rog.BasePrimaryAttributes.Strength);
            Assert.Equal(expectedRogueDexterity, rog.BasePrimaryAttributes.Dexterity);
            Assert.Equal(expectedRogueIntelligence, rog.BasePrimaryAttributes.Intelligence);
        }
        #endregion

        #region 5) Classes level up to level 2 with correct increase in PrimaryAttributes
        [Fact]
        public void LevelWarriorWithCorrectBasePrimaryAttributes()
        {
            // Arrange
            int expectedWarriorStrength = 8;
            int expectedWarriorVitality = 15;
            int expectedWarriorDexterity = 4;
            int expectedWarriorIntelligence = 2;
            //Act
            Warrior war = new Warrior("Haladan");
            war.LevelUp(1);
            //Assert
            Assert.Equal(expectedWarriorVitality, war.BasePrimaryAttributes.Vitality);
            Assert.Equal(expectedWarriorStrength, war.BasePrimaryAttributes.Strength);
            Assert.Equal(expectedWarriorDexterity, war.BasePrimaryAttributes.Dexterity);
            Assert.Equal(expectedWarriorIntelligence, war.BasePrimaryAttributes.Intelligence);


        }
        [Fact]
        public void LevelMageWithCorrectBasePrimaryAttributes()
        {
            // Arrange
            int expectedMageStrength = 2;
            int expectedMageVitality = 8;
            int expectedMageDexterity = 2;
            int expectedMageIntelligence = 13;
            //Act
            Mage mag = new Mage("Binkol");
            mag.LevelUp(1);
            //Assert
            Assert.Equal(expectedMageVitality, mag.BasePrimaryAttributes.Vitality);
            Assert.Equal(expectedMageStrength, mag.BasePrimaryAttributes.Strength);
            Assert.Equal(expectedMageDexterity, mag.BasePrimaryAttributes.Dexterity);
            Assert.Equal(expectedMageIntelligence, mag.BasePrimaryAttributes.Intelligence);


        }
        [Fact]
        public void LevelRangerWithCorrectBasePrimaryAttributes()
        {
            // Arrange
            int expectedRangerStrength = 2;
            int expectedRangerVitality = 10;
            int expectedRangerDexterity = 12;
            int expectedRangerIntelligence = 2;
            //Act
            Ranger ran = new Ranger("Sinolas");
            ran.LevelUp(1);
            //Assert
            Assert.Equal(expectedRangerVitality, ran.BasePrimaryAttributes.Vitality);
            Assert.Equal(expectedRangerStrength, ran.BasePrimaryAttributes.Strength);
            Assert.Equal(expectedRangerDexterity, ran.BasePrimaryAttributes.Dexterity);
            Assert.Equal(expectedRangerIntelligence, ran.BasePrimaryAttributes.Intelligence);
        }
        [Fact]
        public void LevelRogueWithCorrectBasePrimaryAttributes()
        {
            // Arrange
            int expectedRogueStrength = 3;
            int expectedRogueVitality = 11;
            int expectedRogueDexterity = 10;
            int expectedRogueIntelligence = 2;
            //Act
            Rogue rog = new Rogue("Robin");
            rog.LevelUp(1);
            //Assert
            Assert.Equal(expectedRogueVitality, rog.BasePrimaryAttributes.Vitality);
            Assert.Equal(expectedRogueStrength, rog.BasePrimaryAttributes.Strength);
            Assert.Equal(expectedRogueDexterity, rog.BasePrimaryAttributes.Dexterity);
            Assert.Equal(expectedRogueIntelligence, rog.BasePrimaryAttributes.Intelligence);
        }
        #endregion
    }
}
