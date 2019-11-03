using GZAAT.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GZAAT.DAL
{
    public class SMSHelper
    {
        public static void SaveSMS(DateTime date, IEnumerable<string> mobileList, string message)
        {
            using (var ctx = new DBEntities())
            {
                DictionaryHelper.SaveMobiles(mobileList.Select(x => new DD_Mobile { Mobile = x }));
                var mobileDictionary = DictionaryHelper.GetMobileDictionary(mobileList);


                var sms = ctx.T_SMS.Create();
                sms.Date = date;
                sms.Message = message;

                foreach (var mobile in mobileDictionary.Values)
                {
                    var d = new T_SMSDetail();
                    d.MobileID = mobile;
                    d.StatusID = (int)SMSStatus.Pending;
                    d.TryCount = 0;
                    sms.T_SMSDetail.Add(d);
                }
                ctx.T_SMS.Add(sms);
                ctx.SaveChanges();
            }
        }
    }
}
