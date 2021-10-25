using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroffAssignment1.System.Equipment.Items
{
    interface IItem
    {
        /// <summary>
        /// Interface for adding both weapons and armor to a "bag" inventory system.  One would probably add weight, size and so on.
        /// </summary>
        public string Name { get; set; }
    }
}
