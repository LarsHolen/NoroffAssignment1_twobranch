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
        #region Character creation
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

        #region Classes are created with correct PrimaryAttributes
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
    }
}
