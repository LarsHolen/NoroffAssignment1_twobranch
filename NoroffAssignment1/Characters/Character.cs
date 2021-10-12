using NoroffAssignment1.Characters.Attributes;
using NoroffAssignment1.Characters.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroffAssignment1.Characters
{
    abstract class Character
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public PrimaryAttributes BasePrimaryAttributes { get; set; }
        public PrimaryAttributes TotalPrimaryAttributes { get; set; }
        public SecondaryAttributes SecondaryAttributes { get; set; }

        public abstract void LevelUp();
        public abstract void EquipItem(Item i);
    }
}
