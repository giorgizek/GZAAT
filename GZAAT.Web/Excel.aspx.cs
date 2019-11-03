using GZAAT.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using Zek.Data;

namespace GZAAT.Web
{
    public partial class Excel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            if (RadUpload1.UploadedFiles.Count < 1) return;
            var stream = RadUpload1.UploadedFiles[0].InputStream;

            GridDataSource = EPPlusHelper.GetClassFromExcel<ExcelTemplate>(stream);

            RadGrid1.Rebind();
        }


        private List<ExcelTemplate> GridDataSource
        {
            get
            {
                if (ViewState["GridDataSource"] == null) return null;
                else return (List<ExcelTemplate>)ViewState["GridDataSource"];
            }
            set
            {
                ViewState["GridDataSource"] = value;
            }
        }

        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            RadGrid1.DataSource = GridDataSource;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (GridDataSource == null) return;

            DebtHelper.Save(DateTime.Now.Date, Request.UserHostAddress, GridDataSource.Where(x => x.Debt > 0d).ToList());

            GridDataSource = null;
            btnGet.Enabled = btnSave.Enabled = false;
            RadGrid1.Rebind();
        }
    }
}