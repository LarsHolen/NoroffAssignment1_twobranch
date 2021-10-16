using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroffAssignment1.Characters.Items
{
    public class Weapon : Item
    {
        public WeaponType WeaponType { get; set; }
        public int DPS { get; set; }
        public WeaponAttributes WeaponAttribute { get; set; }

    }
}
