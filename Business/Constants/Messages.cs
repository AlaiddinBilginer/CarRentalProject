using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = "Ekleme işlemi başarılı";
        public static string AdditionFailed = "Ekleme işlemi başarısız";
        public static string AddedRental = "Araba kiralama işlemi başarılı";
        public static string AdditionFailedRental = "Araba kiralama işlemi başarısız";
        public static string FailedDelivery = "Araba teslimat işlemi başarısız";
        public static string DeliveredCar = "Araba teslimat işlemi başarılı";
        public static string FailedModelYear = "Geçersiz bir model yılı girdiniz";

        public static string CarImageLimitExceded = "Bir araba için en fazla 5 resim ekleyebilirsiniz";
        public static string CheckIfIsCarImage = "Arabaya ait resim bulunamadı";
        public static string CheckIfIsCarId = "Araba bulunamadı";
        public static string CheckIfImage = "Resim bulunamadı";

        public static string ImagesPath = "wwwroot\\CarImages\\";
    }
}
