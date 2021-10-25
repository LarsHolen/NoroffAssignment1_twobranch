using System;

namespace NoroffAssignment1.System.Equipment.Items
{
    public class InvalidArmorException : Exception
    {
        public InvalidArmorException(string message) : base(message) { }
    }


}
