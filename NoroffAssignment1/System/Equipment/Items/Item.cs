using NoroffAssignment1.System.Characters.Attributes;
using NoroffAssignment1.System.Enums;
using System;

namespace NoroffAssignment1.System.Equipment.Items
{
    public abstract class Item
    {
        public String Name { get; set; }
        public int RequiredLevel { get; set; }
        public EquipmentSlots FitInEquipmentSlot { get; set; }
        public PrimaryAttributes ItemBonusAttributes { get; set; } = new PrimaryAttributes();
        
    }
}
