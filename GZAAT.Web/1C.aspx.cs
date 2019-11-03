using GZAAT.DAL;
using GZAAT.DAL.WS1C;
using System;
using System.Linq;

namespace GZAAT.Web
{
    public partial class _1C : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private ContragentsTable GridDataSource
        {
            get
            {
                return (ContragentsTable)ViewState["GridDataSource"];
            }
            set
            {
                ViewState["GridDataSource"] = value;
            }
        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            //todo წაშაშლელია
            //var response = Zek.Data.Serialization.SerializationHelper.DeserializeFromFile<ContragentsTable>(SerializationFormat.Xml, @"d:\gzaat.txt");
            //GridDataSource = response;
            //var rnd = new Random();
            //var response = new ContragentsTable();
            //response.Add(new Contragents() { Code = "1", TIN = "01010013858", Name = "Giorgi", StudentMobilePhone = "597000333", MotherMobilePhone = "599390807", MotherFirstAndLastName = "Nino ChKhikvadze", FatherMobilePhone = "555 257599;597 111222", FatherFirstAndLastName = "Aleko Makharadze", Debt = rnd.Next(10, 200), CurrenciesCod = "GEL" });
            //response.Add(new Contragents() { Code = "2", TIN = "02020202020", Name = "Beka", StudentMobilePhone = "597000333", Debt = rnd.Next(10, 200), CurrenciesCod = "GEL" });
            //response.Add(new Contragents() { Code = "3", TIN = "02020202020", Name = "Beka", StudentMobilePhone = "597000333", Debt = rnd.Next(10, 200), CurrenciesCod = "GEL" });
            //response.Add(new Contragents() { Code = "4", TIN = "01011234564", Name = "Giorgi", StudentMobilePhone = "597000333", MotherMobilePhone = "599390807", MotherFirstAndLastName = "Nina ChKhikvadze", FatherMobilePhone = "555 257599;597 111222", FatherFirstAndLastName = "Ako Makharadze", Debt = rnd.Next(10, 200), CurrenciesCod = "GEL" });
            //GridDataSource = response;

            GridDataSource = _1CHelper.Get();
            RadGrid1.Rebind();
        }

        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            RadGrid1.DataSource = GridDataSource;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (GridDataSource == null) return;

            //throw new NotImplementedException("გათიშულია მოთხოვნის გამო (v2)");
            DebtHelper.Save(DateTime.Now.Date, Request.UserHostAddress, GridDataSource.Where(x => x.Debt > 0d).ToList());

            GridDataSource = null;
            btnGet.Enabled = btnSave.Enabled = false;
            RadGrid1.Rebind();
        }
    }
}