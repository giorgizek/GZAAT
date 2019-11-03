using GZAAT.Model;
using System.Collections.Generic;
using Zek.DataModel;

namespace GZAAT.Web.Code
{
    public class CacheHelper : Zek.Web.BaseCacheHelper
    {
        public static List<DD_Dictionary<int>> GetRelationTypes()
        {
            var result = new List<DD_Dictionary<int>>
            {
                new DD_Dictionary<int>((int)RelationType.Student, RelationType.Student.ToString(), Resources.ApplicationResources.Student),
                new DD_Dictionary<int>((int)RelationType.Mother, RelationType.Mother.ToString(), Resources.ApplicationResources.Mother),
                new DD_Dictionary<int>((int)RelationType.Father, RelationType.Father.ToString(), Resources.ApplicationResources.Father)
            };
            return result;
        }

        public static List<DD_Dictionary<int>> GetDebtStatuses()
        {
            var result = new List<DD_Dictionary<int>>
            {
                new DD_Dictionary<int>((int) SMSStatus.Pending, SMSStatus.Pending.ToString(), Resources.ApplicationResources.Pending), 
                new DD_Dictionary<int>((int) SMSStatus.Sent, SMSStatus.Sent.ToString(), Resources.ApplicationResources.Sent),
                new DD_Dictionary<int>((int) SMSStatus.Error, SMSStatus.Error.ToString(), Resources.ApplicationResources.Error)
            };
            return result;
        }
    }
}