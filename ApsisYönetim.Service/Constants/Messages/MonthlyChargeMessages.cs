using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsisYönetim.Service.Constants.Messages
{
    public class MonthlyChargeMessages
    {
        public static string SuccessfullyAdded = " fatura başarılı bir şekilde eklenmiştir";
        public static string AddedFailed = " fatura eklenirken bir sorun oluştu";
        public static string DeletedSuccessfully = " fatura başarıyla silindi";

        public static string FailDeleted = " fatura silme işlemi gerçekleştirilemedi !!!";
        public static string NotFound = " böyle bir fatura bulunamadı !";
        public static string FailUpdated = " fatura güncellenemedi ";
        internal static string SuccessfullyUpdated = "fatura başarılı bir şekilde güncellenmiştir";
    }
}
