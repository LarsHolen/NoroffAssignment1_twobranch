using System;
using Xunit;
using NoroffAssignment1.Characters.Attributes;

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
    }
}
