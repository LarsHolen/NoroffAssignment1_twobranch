using NoroffAssignment1.Characters.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroffAssignment1.Characters.Items
{
    public abstract class Item
    {
        public String Name { get; set; }
        public int RequiredLevel { get; set; }
        public PlayerClasses CanBeUsedBy { get; set; }
        public EquipmentSlots FitInEquipmentSlot { get; set; }
        public PrimaryAttributes ItemBonusAttributes { get; set; }
    }
}
