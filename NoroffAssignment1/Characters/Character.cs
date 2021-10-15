using NoroffAssignment1.Characters.Attributes;
using NoroffAssignment1.Characters.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroffAssignment1.Characters
{
    public abstract class Character
    {
        public string Name { get; set; }
        public int Level { get; set; } = 1;
        public PrimaryAttributes BasePrimaryAttributes { get; set; }
        public PrimaryAttributes TotalPrimaryAttributes { get; set; }
        public SecondaryAttributes SecondaryAttributes { get; set; }

        public PrimaryAttributes StartPrimaryArrtibutes { get; set; }
        public PrimaryAttributes LevelUpPrimaryAttributes { get; set; }

        /// <summary>
        /// Adds int l to Level and increase the BasePrimaryAttributes
        /// (Level-1 because the first level increase the PrimaryAttributes by StartPrimaryAttributes)
        /// 0 or less is not leagal input and throws exception
        /// </summary>
        /// <param name="l"></param>
        public void LevelUp(int l)
        {
            if(l > 0)
            {
                Level += l;
                BasePrimaryAttributes = StartPrimaryArrtibutes + ((Level-1) * LevelUpPrimaryAttributes);
            } else
            {
                throw new ArgumentException("Zero or negative input not legal");
            }
            
        }
        public abstract void EquipItem(Item i);
    }
}
