using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroffAssignment1.System.Characters.Attributes
{
    public struct PrimaryAttributes
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        public int Vitality { get; set; }
 
        public PrimaryAttributes(int str = 0, int dex = 0, int inte = 0, int vit = 0)
        {
            Strength = str;
            Dexterity = dex;
            Intelligence = inte;
            Vitality = vit;
        }
        
        /// <summary>
        /// Overloads the + operator to easily increase attributes
        /// </summary>
        /// <param name="pa1"></param>
        /// <param name="pa2"></param>
        /// <returns>an instance of PrimaryAttributes that has values equal to the sum of pa1 and pa2's attributes</returns>
        public static PrimaryAttributes operator +(PrimaryAttributes pa1, PrimaryAttributes pa2)
        {
            return new PrimaryAttributes()
            {
                Dexterity = pa1.Dexterity + pa2.Dexterity,
                Strength = pa1.Strength + pa2.Strength,
                Vitality = pa1.Vitality + pa2.Vitality,
                Intelligence = pa1.Intelligence + pa2.Intelligence
            };
        }

        /// <summary>
        /// Makes testing easier.  Test if type and all stats are equal to parameter pa
        /// </summary>
        /// <param name="pa"></param>
        /// <returns></returns>
        public bool Equals(PrimaryAttributes pa)
        {
            return this.GetType().Equals(pa.GetType()) &&
                Dexterity == pa.Dexterity && 
                Strength == pa.Strength && 
                Vitality == pa.Vitality && 
                Intelligence == pa.Intelligence;
        }
       
        /// <summary>
        /// Makes leveling up easier.  One can multiply each stat in PrimaryAttributes
        /// (BasePA_Stats + levelingPA_Stats * level in Character class)
        /// </summary>
        /// <param name="i"></param>
        /// <param name="pa1"></param>
        /// <returns></returns>
        public static PrimaryAttributes operator *(int i, PrimaryAttributes pa1)
        {
            return new PrimaryAttributes()
            {
                Dexterity = i * pa1.Dexterity,
                Strength = i * pa1.Strength,
                Vitality = i * pa1.Vitality,
                Intelligence = i * pa1.Intelligence
            };
        }

    }
}
