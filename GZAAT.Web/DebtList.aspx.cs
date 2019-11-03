using System;

namespace GZAAT.Web
{
    public partial class SMSList : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
    
            if (IsPostBack) return;

            //var exp = new RadFilterBetweenFilterExpression<DateTime>("Date");
            //exp.LeftValue = DateTime.Now.Date;
            //exp.RightValue = DateTime.Now.Date.AddDays(1);
            //rfGrid.RootGroup.AddExpression(exp);
        }

        protected override void OnPreRenderComplete(EventArgs e)
        {
            base.OnPreRenderComplete(e);
        }
    }
}