using System;
using System.Linq;
using System.Windows.Forms;
using Zek.Utils;

namespace GZAAT.Scheduler
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            var service = false;
            if (args.Contains("static"))
            {
                service = true;
                if (!Zek.Threading.MutexHelper.IsAlreadyRunning(false, true, false, "static"))
                    RunStatic();
            }
            if (args.Contains("debt"))
            {
                service = true;
                if (!Zek.Threading.MutexHelper.IsAlreadyRunning(false, true, false, "debt"))
                    RunDebt();
            }


            if (service) return;

            if (Zek.Threading.MutexHelper.IsAlreadyRunning(false, true, false))
            {
                Zek.Win32.Win32Native.SwitchToCurrentInstance();
                return;
            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
        static void RunStatic()
        {
            try
            {
                var s = new Schedule();
                s.RunStaticSms();
            }
            catch (Exception ex)
            {
                ExceptionLogHelper.Write(ex);
            }
            return;
        }

       

        static void RunDebt()
        {
            try
            {
                var s = new Schedule();
                s.RunDebtSms();
            }
            catch (Exception ex)
            {
                ExceptionLogHelper.Write(ex);
            }
            return;
        }
    }
}
