using GZAAT.Model;
using System;
using System.Linq;
using Zek.Scheduler;
using Zek.Utils;
using Zek.Configuration;
using Zek.Service.SMS;
using Zek.Extensions;
using System.Net.NetworkInformation;

namespace GZAAT.Scheduler
{
    public class Schedule : BaseScheduler
    {
        internal static string MobileProvider => AppConfigHelper.GetString("MobileProvider");

        internal static string MagtiUserName => AppConfigHelper.GetString("MagtiUserName");

        internal static string MagtiPassword => AppConfigHelper.GetString("MagtiPassword");

        internal static string MagtiClientID => AppConfigHelper.GetString("MagtiClientID");
        internal static string MagtiIP => AppConfigHelper.GetString("MagtiIP");


        internal static void Ping()
        {
            try
            {
                var ping = new Ping();

                switch (MobileProvider.ToLowerInvariant())
                {
                    case "magti":
                        ping.Send(MagtiIP);
                        break;
                }
            }
            catch { }


        }

        public void RunStaticSms()
        {
            if (!Check()) return;


            using (var ctx = new DBEntities())
            {


                var result = ctx.SP_SMS_GetForSend().ToList();
                Ping();
                EventLogHelper.WriteEntry($"Static SMS {result.Count} Started");
                var count = 0;
                foreach (var item in result)
                {
                    var url = string.Empty;
                    var response = string.Empty;
                    var statusID = SMSStatus.None;
                    try
                    {
                        switch (MobileProvider.ToLowerInvariant())
                        {
                            case "magti":
                                url = MagtiHttpToSMS.GetFormatedURL(MagtiUserName, MagtiPassword, MagtiClientID, item.Mobile, item.Message);
                                response = HttpToSMSBase.SendWebRequest(url);
                                if (response.StartsWith(MagtiHttpToSMS.SmscReturnCodes.Successfull))
                                {
                                    count++;
                                    statusID = SMSStatus.Sent;
                                }
                                else
                                    statusID = SMSStatus.Error;

                                ctx.SP_SMS_Save(item.ID, item.MobileID, (byte)statusID);
                                ctx.SP_T_SMSDetailLog_Save(item.ID, item.MobileID, url, response.SafeSubstring(0, 25), string.Empty);
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        if (statusID == SMSStatus.None)//თუ მანამდე მოხდა შეცდომა ვიდრე ჩაწერდა ლოგს ასეთ შემთხვევაში უნდა გაიზარდოს +1 -ით
                            ctx.SP_SMS_Save(item.ID, item.MobileID, (byte)SMSStatus.Error);
                        ctx.SP_T_SMSDetailLog_Save(item.ID, item.MobileID, url, response.SafeSubstring(0, 25), ex.ToString());
                    }
                }
                EventLogHelper.WriteEntry($"Static SMS {count}/{result.Count} Completed");
            }
        }
        public void RunDebtSms()
        {
            if (!Check()) return;


            using (var ctx = new DBEntities())
            {
                var result = ctx.SP_Debt_GetForSend().ToList();
                Ping();
                EventLogHelper.WriteEntry($"Debt SMS {result.Count} Started");
                var count = 0;
                foreach (var item in result)
                {
                    var url = string.Empty;
                    var response = string.Empty;
                    var statusID = SMSStatus.None;
                    try
                    {
                        switch (MobileProvider.ToLowerInvariant())
                        {
                            case "magti":
                                url = MagtiHttpToSMS.GetFormatedURL(MagtiUserName, MagtiPassword, MagtiClientID, item.Mobile, item.Message);
                                response = HttpToSMSBase.SendWebRequest(url);
                                if (response.StartsWith(MagtiHttpToSMS.SmscReturnCodes.Successfull))
                                {
                                    count++;
                                    statusID = SMSStatus.Sent;
                                }
                                else
                                    statusID = SMSStatus.Error;

                                ctx.SP_Debt_Save(item.ID, item.MobileID, (byte)statusID);
                                ctx.SP_T_DebtDetailLog_Save(item.ID, item.MobileID, url, response.SafeSubstring(0, 25), string.Empty);
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        if (statusID == SMSStatus.None)//თუ მანამდე მოხდა შეცდომა ვიდრე ჩაწერდა ლოგს ასეთ შემთხვევაში უნდა გაიზარდოს +1 -ით
                            ctx.SP_Debt_Save(item.ID, item.MobileID, (byte)SMSStatus.Error);
                        ctx.SP_T_DebtDetailLog_Save(item.ID, item.MobileID, url, response.SafeSubstring(0, 25), ex.ToString());
                    }
                }
                EventLogHelper.WriteEntry($"Debt SMS {count}/{result.Count} Completed");
            }
        }
    }
}