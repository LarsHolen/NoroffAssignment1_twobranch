using NoroffAssignment1.System.Characters.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoroffAssignment1.System.Characters
{
    interface ICharacter
    {
        /// <summary>
        /// Interface to make it possible to gather muultiple characters of different subclass in one list and iterate
        /// over them.  Basic combat could be calculated from SecondaryAttributes and Dps depending on futher development
        /// of the game design.
        /// </summary>
        SecondaryAttributes SecondaryAttributesTotal { get; set; }
        double Dps { get; set; }
    }
}
