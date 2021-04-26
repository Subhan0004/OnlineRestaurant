using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Helpers
{
    public static class UIMessages
    {
        public static string DeleteSureMessage = "Are you sure you want to delete";
        public static string ErrorMessage = "Telefon nümrəsi düzgün formatda deyil. Düzgün format:++99450XXXXXXX. (Dəstəklənən prefikslər: 50,51,55,70,77,99)";
        public const string ValidationCommonMessage = "Validasiya xətası";
        public const string OperationSuccessMessage = "Əməliyyat uğurla tamamlandı";
        public static string GetRequiredMessage(string propName)
        {
            return $"{propName} mütləq daxil edilməlidir!";
        }

        public static string GetLenghtMessage(string propName, int lenght)
        {
            return $"{propName} {lenght} simvoldan uzun ola bilməz!";
        }
    }
}
