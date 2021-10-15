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

        public void LevelUp(int l)
        {
            Level += l;
            BasePrimaryAttributes = StartPrimaryArrtibutes + (Level * LevelUpPrimaryAttributes);
        }
        public abstract void EquipItem(Item i);
    }
}
