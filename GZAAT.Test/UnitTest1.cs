using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zek.Data;

namespace GZAAT.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var t = EPPlusHelper.GetDataTableFromExcel(@"d:\gzekalashvili\Desktop\sms.xls");

            var x = t;
            x.ToString();
            //EPPlusHelper.GetClassFromExcel<ExcelTemplate>(@"d:\gzekalashvili\Desktop\sms-ID correction-1.xlsx");
        }
    }
}
