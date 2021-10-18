using System;

namespace NoroffAssignment1.Characters.Items
{
    public class InvalidWeaponException : Exception
    {
        public InvalidWeaponException(string message) : base(message) { }
    }


}
