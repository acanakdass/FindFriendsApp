using System;
using System.Runtime.Serialization;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = "Eklendi";
        public static string Updated = "Güncellendi";
        public static string Deleted = "Silindi";
        public static string Listed = "Listelendi";
        public static string NotFound = "Bulunamadı";

        public static string ImageUploaded = "Dosya başarıyla eklendi";
        public static string ImageUploadError="Dosya yüklenirken bir sorun oluştu";

        public static string NameInvalid = "İsim geçersiz";
        public static string CarImagesCountMaxedOut = "Araçların en fazla 5 adet fotoğrafı olabilir";

        public static string FriendRequestSent = "Arkadaşlık isteği gönderildi";
        public static string FriendRequestAccepted = "Arkadaşlık isteği kabul edildi";
        public static string FriendRequestAlreadySent = "Arkadaşlık isteği zaten gönderilmiş";


        public static string AuthorizationDenied= "Authorization Denied";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
        public static string carIsNotAvailableBetweenSelectedDates="Araç seçili tarihler arasında uygun değil";
        public static string RentOperationSucceed="Kiralama işlemi başarılı";
    }
}
