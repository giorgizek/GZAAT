using System;
using System.Windows.Forms;
using Zek.Service.SMS;
using Zek.Windows.Forms;

namespace GZAAT.Scheduler
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            txtLog.Text = string.Empty;
            var url = string.Empty;
            var response = string.Empty;

            try
            {
                Application.DoEvents();
                Cursor = Cursors.WaitCursor;

                switch (Schedule.MobileProvider.ToLowerInvariant())
                {
                    case "magti":
                        Schedule.Ping();

                        url = MagtiHttpToSMS.GetFormatedURL(Schedule.MagtiUserName, Schedule.MagtiPassword, Schedule.MagtiClientID, txtMobile.Text, txtMessage.Text);
                        response = HttpToSMSBase.SendWebRequest(url);
                        break;
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            txtLog.Text = @"URL: " + url + @"
Respponse: " + response;
        }

        private void btnSerialize_Click(object sender, EventArgs e)
        {
            try
            {
                Application.DoEvents();
                Cursor = Cursors.WaitCursor;

                var data = DAL._1CHelper.Get();

                var dlg = new SaveFileDialog() { Filter = @"Text File|*.txt|All Files|*.*" };
                if (dlg.ShowDialog() != DialogResult.OK) return;

                Zek.Data.Serialization.SerializationHelper.SerializeXmlFile(data, dlg.FileName);
            }
            catch (Exception ex)
            {
                ExceptionHelper.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
    }
}
