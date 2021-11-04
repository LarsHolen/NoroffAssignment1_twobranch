using NoroffAssignment1.System.Characters.Attributes;
using NoroffAssignment1.System.Enums;
using System;

namespace NoroffAssignment1.System.Equipment.Items
{
    public abstract class Item
    {
        // Name of the item
        public String Name { get; set; }
        // User must be this level or higher to use
        public int RequiredLevel { get; set; }
        // The slot the item fit in
        public EquipmentSlots FitInEquipmentSlot { get; set; }
        // PrimaryAttributes that the item adds to the users total
        public PrimaryAttributes ItemBonusAttributes { get; set; } = new PrimaryAttributes();
        
    }
}
