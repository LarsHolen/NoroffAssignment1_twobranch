using NoroffAssignment1.System.Enums;


namespace NoroffAssignment1.System.Equipment.Items
{
    public class Weapon : Item
    {
        public WeaponType WeaponType { get; set; }
        public double DPS { get; set; }
        public WeaponAttributes WeaponAttribute { get; set; }

    }
}
