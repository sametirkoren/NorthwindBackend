using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constans
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Başarıyla Eklendi";
        public static string ProductUpdated = "Ürün Başarıyla Güncellendi";
        public static string ProductDeleted = "Ürün Başarıyla Silindi";

        public static string UserNotFound = "Kullanıcı bulunamadı";

        public static string PasswordError = "Şifre Hatalı";

        public static string SuccessfulLogin = "Sisteme Giriş Başarılı";

        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";

        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";

        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";

        public static string AuthorizationDenied = "Yetkiniz Yok";
    }
}
