using System;

namespace NoroffAssignment1.System.Equipment.Items
{
    public class InvalidWeaponException : Exception
    {
        public InvalidWeaponException(string message) : base(message) { }
    }


}
