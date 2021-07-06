using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsisYönetim.Service.Constants.Messages
{
    public static class ApartmentMessages
    {
        public static string AlreadyExist = " böyle bir daire zaten vardır.";
        public static string SuccessfullyAdded = " daire başarılı bir şekilde eklenmiştir";
        public static string AddedFailed = " daire eklenirken bir sorun oluştu";
        public static string DeletedSuccessfully = " apartman başarıyla silindi";
        public static string FailDeleted = " apartman silme işlemi gerçekleştirilemedi !!!";
        public static string NotFound = " böyle bir daire bulunamadı !!!";
    }
}
