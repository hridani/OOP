using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Models
{
    public static class Validation
    {
        private const string textMessageFormat = "{0} must be positive.";
        private const string textMessageGreaderFormat = "{0} must not be greater than {1}.";
        public static void CheckForNegativeDecimal(decimal value, string argumentName)
        {
            if (value <= 0)
            {
                string textMessage = string.Format(textMessageFormat, argumentName);
                throw new ArgumentException(textMessage, argumentName);
            }
        }
        public static void CheckForNegativeInt(int value, string argumentName)
        {
            if (value <= 0)
            {
                string textMessage = string.Format(textMessageFormat, argumentName);
                throw new ArgumentException(textMessage, argumentName);
            }
        }
        public static void CheckForNullOrEmptyString(string value, string argumentName)
        {
            if (string.IsNullOrEmpty(value))
            {
                string textMessage = string.Format(textMessageFormat, argumentName);
                throw new ArgumentException(textMessage, argumentName);
            }
        }
        public static void CheckForValueIsGreaterRange(int value, int range, string argumentName)
        {
            if (value > range)
            {
                string textMessage = string.Format(textMessageGreaderFormat, argumentName,range);
                throw new ArgumentException(textMessage, argumentName);
            }
        }

    }
}
