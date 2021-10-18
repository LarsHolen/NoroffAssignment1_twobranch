using System;

namespace NoroffAssignment1.Characters.Items
{
    public class InvalidArmorException : Exception
    {
        public InvalidArmorException(string message) : base(message) { }
    }


}
