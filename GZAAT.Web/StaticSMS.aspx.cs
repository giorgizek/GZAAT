using GZAAT.DAL;
using System;
using System.Linq;

namespace GZAAT.Web
{
    public partial class StaticSMS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            rdtpSendDate.SelectedDate = DateTime.Now;
        }

        protected void btnSaveForSend_Click(object sender, EventArgs e)
        {
            if (!IsValid) return;

            var mobileList =  txtMobiles.Text.Replace("\r", "").Replace(" ", "").Split('\n').Select(m => DictionaryHelper.ParsedMobileNumber(m)).Where(x => x.Length > 0).Distinct();
            SMSHelper.SaveSMS(rdtpSendDate.SelectedDate.Value, mobileList, txtMessage.Text.Trim());

            txtMobiles.Text = string.Empty;
            txtMessage.Text = string.Empty;
            
            gridSMS.Rebind();
        }
    }
}