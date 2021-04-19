using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Helpers
{
    public static class ModelValidatorHelper
    {
        public static List<string> NumberPrefixes = new List<string> { "50", "51", "55", "70", "77", "99" };
        
        public static bool ValidatePhone(string phone)
        {
            if (phone.Length != 13)
                return false;
           
            if (!phone.StartsWith("+994"))
                return false;

            string numberPrefix = phone.Substring(4, 2);
            
            if (!NumberPrefixes.Contains(numberPrefix))
                return false;

            for(int i= 6; i<phone.Length; i++)
            {
                if (char.IsDigit(phone[i]))
                    continue;

                return false;

            }

            return true;
        }
    }
}
