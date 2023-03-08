using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string UnitPriceİnvalid = "ürün degeri eklenmemiş";
        public static string ProductAdded = "ürün eklendi";
        public static string ProductNameInvalid = "ürün ismi geçersiz";
        internal static string ProductsListed = "ürünler listelendi";
        public static string MaintenanceTime = "sistem bakimda";
        public static string ProductCountOfCategoryError = "kategori sayısı asıldı";
        public static string ProductNameAlreadyExists = "bu isimde zaten başka bir ürün var";
        public static string CategoryLimitExceded = "kategori limiti aşılmıştır";
        internal static string AuthorizationDenied = "reddedildi";
    }
}