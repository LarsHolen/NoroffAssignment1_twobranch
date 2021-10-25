using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroffAssignment1.System.Characters.Attributes
{
    public struct SecondaryAttributes
    {
        public int Health { get; set; }
        public int ArmorRating { get; set; }
        public int ElementalResistance { get; set; }

        public SecondaryAttributes(PrimaryAttributes pa)
        {
            Health = pa.Vitality * 10;
            ArmorRating = pa.Strength + pa.Dexterity;
            ElementalResistance = pa.Intelligence;
        }


        /// <summary>
        /// Makes testing easier to test if two SecondaryAttributes has the same values
        /// </summary>
        /// <param name="sa"></param>
        /// <returns></returns>
        public bool Equals(SecondaryAttributes sa)
        {
            return this.GetType().Equals(sa.GetType()) &&
                Health == sa.Health &&
                ArmorRating == sa.ArmorRating &&
                ElementalResistance == sa.ElementalResistance;
                
        }
    }
}
