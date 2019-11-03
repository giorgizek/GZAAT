using System;
using System.Web.UI;
using Zek.Web;

namespace GZAAT.Web.App_Master
{
    public partial class Base : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Page.BindValidatorScript();
        }


        protected override void Render(HtmlTextWriter writer)
        {
            Page.BindValidatorScript();
            base.Render(writer);
        }
    }
}