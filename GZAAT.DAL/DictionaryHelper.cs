using GZAAT.Model;
using System.Collections.Generic;
using System.Linq;
using Zek.Data;

namespace GZAAT.DAL
{
    public class DictionaryHelper
    {
        public static string ParsedMobileNumbers(string mobiles)
        {
            if (mobiles == null) return string.Empty;

            var result = string.Empty;
            foreach (var c in mobiles)
                if (char.IsNumber(c) || c == ';' || c == ',') result += c;

            return result;
        }
        public static string ParsedMobileNumber(string mobile)
        {
            if (mobile == null) return string.Empty;

            var result = string.Empty;
            foreach (var c in mobile)
                if (char.IsNumber(c)) result += c;

            return result;
        }


        public static void SaveMobiles(IEnumerable<DD_Mobile> dd_MobileList)
        {
            using (var ctx = new DBEntities(60 * 10))
            {
                var tmpMobile = dd_MobileList.Select(x => x.Mobile).ToArray();
                var dbList = ctx.T_Mobile.Where(m => tmpMobile.Contains(m.Mobile)).ToList();

                foreach (var mobile in dd_MobileList)
                {
                    var row = dbList.FirstOrDefault(x => x.Mobile == mobile.Mobile);
                    if (row == null)
                    {
                        var m = ctx.T_Mobile.Create();
                        m.Mobile = mobile.Mobile;
                        m.Name = mobile.Name;
                        ctx.T_Mobile.Add(m);
                    }
                    else if (!string.IsNullOrEmpty(mobile.Name) && row.Name != mobile.Name)
                    {
                        row.Name = mobile.Name;
                    }
                }

                ctx.SaveChanges();
            }
        }
        public static void SaveContragentsByCode1C(List<T_Contragent> contragentList)
        {
            using (var ctx = new DBEntities(60 * 20))
            {
                var code1CList = contragentList.Select(x => x.Code1C).Distinct();
                var dbList = ctx.T_Contragent
                                        .Where(m => code1CList.Contains(m.Code1C))
                                        .ToList();

                foreach (var item in dbList)
                {
                    var c = contragentList.FirstOrDefault(x => x.Code1C == item.Code1C);
                    if (c == null) continue;

                    item.Name = c.Name;
                    item.PersonalNumber = c.PersonalNumber;
                }

                var notExistList = new List<T_Contragent>(contragentList);
                notExistList.RemoveAll(x => dbList.Select(db => db.Code1C).Contains(x.Code1C));
                foreach (var item in notExistList)
                {
                    ctx.T_Contragent.Add(item);
                }
                ctx.SaveChanges();
            }
        }
        public static void SaveContragentsPersonalNumber(List<T_Contragent> contragentList)
        {
            using (var ctx = new DBEntities(60 * 20))
            {
                var personalNumberList = contragentList.Select(x => x.PersonalNumber).Distinct();
                var dbList = ctx.T_Contragent
                                        .Where(m => personalNumberList.Contains(m.PersonalNumber))
                                        .ToList();

                foreach (var item in dbList)
                {
                    var c = contragentList.FirstOrDefault(x => x.PersonalNumber == item.PersonalNumber);
                    if (c == null) continue;

                    item.Name = c.Name;
                    item.PersonalNumber = c.PersonalNumber;
                }

                var notExistList = new List<T_Contragent>(contragentList);
                notExistList.RemoveAll(x => dbList.Select(db => db.PersonalNumber).Contains(x.PersonalNumber));
                foreach (var item in notExistList)
                {
                    ctx.T_Contragent.Add(item);
                }
                ctx.SaveChanges();
            }
        }

        public static Dictionary<string, int> GetMobileDictionary(IEnumerable<string> mobileList)
        {
            using (var ctx = new DBEntities(60 * 10))
            {
                return ctx.T_Mobile.Where(m => mobileList.Contains(m.Mobile)).ToDictionary(m => m.Mobile, m => m.ID);
            }
        }

        private class KeyValue
        {
            public string Key { get; set; }
            public int Value { get; set; }
        }
        public static Dictionary<string, int> GetContragentDictionary(IEnumerable<string> list, bool code1C)
        {
            using (var ctx = new DBEntities(60 * 10))
            {
                var result = new Dictionary<string, int>();

                if (code1C)
                {
                    var comparer = new PropertyComparer<KeyValue>("Key");
                    return ctx.T_Contragent
                                    .Where(c => list.Contains(c.Code1C))
                                    .Select(c => new KeyValue { Key = c.Code1C, Value = c.ID })
                                    .ToList()
                                    .Distinct(comparer)
                                    .ToDictionary(x => x.Key, x => x.Value);
                }
                else
                {
                    var comparer = new PropertyComparer<KeyValue>("Key");
                    return ctx.T_Contragent
                                   .Where(c => list.Contains(c.PersonalNumber))
                                   .Select(c => new KeyValue { Key = c.PersonalNumber, Value = c.ID })
                                   .ToList()
                                   .Distinct(comparer)
                                   .ToDictionary(x => x.Key, x => x.Value);
                }
            }
        }
    }
}
