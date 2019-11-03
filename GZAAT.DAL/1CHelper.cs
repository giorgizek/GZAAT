using GZAAT.DAL.WS1C;
using Zek.Configuration;

namespace GZAAT.DAL
{
    public class _1CHelper
    {
        public static ContragentsTable Get()
        {
            using (var service = new Service1cPortTypeClient("Service1cSoap"))
            {
                service.ClientCredentials.UserName.UserName = AppConfigHelper.GetString("1CContragentsWSUser");
                service.ClientCredentials.UserName.Password = AppConfigHelper.GetString("1CContragentsWSPassword");
                return service.CreateContragents();
            }
        }

    }
}
