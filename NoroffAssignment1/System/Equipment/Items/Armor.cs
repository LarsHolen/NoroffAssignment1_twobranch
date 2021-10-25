

using NoroffAssignment1.System.Enums;

namespace NoroffAssignment1.System.Equipment.Items
{
    public class Armor : Item, IItem
    {
        public ArmorType ArmorType { get; set; }
    }
}
