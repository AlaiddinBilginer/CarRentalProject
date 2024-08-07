using Core.Entities.Concrete;
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
        public static string AuthorizationDenied = "Yetkiniz bulunmamaktadır";
        public static string UserRegistered = "Kayıt olma işlemi başarılı";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatalı";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Token oluşturuldu";

        public static string RentalDateCannotBeforeToday = "Kira tarihi bugünden önce olamaz";
        public static string ReturnDateCannotBeEarlierThanRentDate = "Teslim tarihi kiralama tarihinden önce olamaz";
        public static string ThisCarIsAlreadyRentedInSelectedDateRange = "Bu araba için kiralama işlemi başarısız. Araba zaten kiralandı.";
        public static string ReturnDateCannotBeLeftBlankAsThisCarWasAlsoRentedAtALaterDate = "Bu araç için iade tarihi boş bırakılamaz çünkü bu araç için gelecekte kiralama var";
        public static string ThisCarHasNotBeenReturnedYet = "Bu araba henüz iade edilmemiştir";
        public static string ColorExist = "Renk zaten mevcut";
        public static string BrandExist = "Marka zaten mevcut";
    }
}
