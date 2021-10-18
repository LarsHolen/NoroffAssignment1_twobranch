using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroffAssignment1.Characters.Attributes
{
    public class SecondaryAttributes
    {
        public int Health { get; set; }
        public int ArmorRating { get; set; }
        public int ElementalResistance { get; set; }

        public SecondaryAttributes(PrimaryAttributes pa)
        {
            Update(pa);
        }

        public void Update(PrimaryAttributes pa)
        {
            Health = pa.Vitality * 10;
            ArmorRating = pa.Strength + pa.Dexterity;
            ElementalResistance = pa.Intelligence;
        }
    }
}
