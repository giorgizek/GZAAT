using GZAAT.DAL.WS1C;
using GZAAT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Zek.Configuration;
using Zek.Data;
using Zek.Extensions;

namespace GZAAT.DAL
{
    public class DebtHelper
    {
        public static void Save(DateTime date, string ip, List<Contragents> wsResponse)
        {
            using (var ctx = new DBEntities(60 * 10))
            {
                var template = AppConfigHelper.GetString("SMSTemplateDebt");

                var mobileList = new List<DD_Mobile>();
                foreach (var item in wsResponse)
                {
                    item.Code = item.Code.Replace(" ", string.Empty).Trim();
                    item.TIN = item.TIN.Replace(" ", string.Empty).Trim();
                    item.SplitMobiles();

                    mobileList.AddRange(item.StudentMobileArray);
                    mobileList.AddRange(item.MotherMobileArray);
                    mobileList.AddRange(item.FatherMobileArray);
                }

                var comparer = new PropertyComparer<DD_Mobile>("Mobile");
                mobileList = mobileList.Distinct(comparer).ToList();


                var contragentComparer = new PropertyComparer<T_Contragent>("Code1C");
                var contragentList = wsResponse.Select(x => new T_Contragent
                {
                    Code1C = x.Code,
                    Name = x.Name,
                    PersonalNumber = x.TIN
                }).Distinct(contragentComparer).ToList();



                #region LINQ
                //var studentList = wsResponse
                //    .Select(x => x.Mobile)
                //    .Distinct();

                //var motherList = wsResponse
                //    .Select(x => x.MotherMobile)
                //    .Distinct();

                //var fatherList = wsResponse
                //    .Select(x => x.FatherMobile)
                //    .Distinct();

                //var mobileList = studentList.Union(motherList).Union(fatherList).ToList();
                #endregion

                DictionaryHelper.SaveMobiles(mobileList);
                DictionaryHelper.SaveContragentsByCode1C(contragentList);

                var mobileDictionary = DictionaryHelper.GetMobileDictionary(mobileList.Select(x => x.Mobile).ToArray());

                var tmpCode1List = contragentList.Select(x => x.Code1C);
                var contragentDictionary = DictionaryHelper.GetContragentDictionary(tmpCode1List, true);

                foreach (var ws in wsResponse)
                {
                    var debt = ctx.T_Debt.Create();
                    debt.ContragentID = contragentDictionary[ws.Code];
                    debt.Date = date;
                    debt.Amount = Convert.ToDecimal(ws.Debt);
                    debt.Currency = ws.CurrenciesCod;
                    debt.CreateDate = DateTime.Now;
                    debt.IP = ip;

                    debt.Message = template.Replace("{student}", ws.Name).Replace("{amount}", ws.Debt.ToString("f0")).Replace("{currency}", ws.CurrenciesCod);
                    ctx.T_Debt.Add(debt);

                    var lst = new List<string>();
                    foreach (var dd in ws.StudentMobileArray.Where(x => !lst.Contains(x.Mobile)))
                    {
                        var d1 = ctx.T_DebtDetail.Create();
                        d1.T_Debt = debt;
                        d1.MobileID = mobileDictionary[dd.Mobile];
                        d1.RelationTypeID = (byte)RelationType.Student;
                        d1.StatusID = (byte)SMSStatus.Pending;
                        d1.TryCount = 0;
                        ctx.T_DebtDetail.Add(d1);
                        lst.Add(dd.Mobile);
                    }

                    foreach (var dd in ws.MotherMobileArray.Where(x => !lst.Contains(x.Mobile)))
                    {
                        var d2 = ctx.T_DebtDetail.Create();
                        d2.T_Debt = debt;
                        d2.MobileID = mobileDictionary[dd.Mobile];
                        d2.RelationTypeID = (byte)RelationType.Mother;
                        d2.StatusID = (byte)SMSStatus.Pending;
                        d2.TryCount = 0;
                        ctx.T_DebtDetail.Add(d2);
                        lst.Add(dd.Mobile);
                    }

                    foreach (var dd in ws.FatherMobileArray.Where(x => !lst.Contains(x.Mobile)))
                    {
                        var d3 = ctx.T_DebtDetail.Create();
                        d3.T_Debt = debt;
                        d3.MobileID = mobileDictionary[dd.Mobile];
                        d3.RelationTypeID = (byte)RelationType.Father;
                        d3.StatusID = (byte)SMSStatus.Pending;
                        d3.TryCount = 0;
                        ctx.T_DebtDetail.Add(d3);
                        lst.Add(dd.Mobile);
                    }
                }

                ctx.SaveChanges();
            }
        }


        public static void Save(DateTime date, string ip, List<ExcelTemplate> wsResponse)
        {
            using (var db = new DBEntities(60 * 10))
            {
                var template = AppConfigHelper.GetString("SMSTemplateDebt");



                var mobileList = new List<DD_Mobile>();
                var smsMaxLength = AppConfigHelper.GetInt32("SMSMaxLength");
                foreach (var ws in wsResponse)
                {
                    var sms = template.Replace("{student}", $"{ws.StudentName}").Replace("{amount}", ws.Debt.ToString("f0")).Replace("{currency}", ws.CurrencyCode);
                    if (smsMaxLength > 0 && sms.Length > smsMaxLength)
                    {
                        throw new Exception("Max Length: " + smsMaxLength + "\nSMS Length:" + sms.Length + "\nSMS: " + sms);
                    }

                    ws.StudentID = ws.StudentID.IfNullEmpty().Replace(" ", string.Empty).Trim();
                    ws.SplitMobiles();

                    //mobileList.AddRange(ws.StudentMobileArray);
                    mobileList.AddRange(ws.MotherMobileArray);
                    mobileList.AddRange(ws.FatherMobileArray);
                }

                var comparer = new PropertyComparer<DD_Mobile>("Mobile");
                mobileList = mobileList.Distinct(comparer).ToList();


                //var contragentComparer = new PropertyComparer<T_Contragent>("PersonalNumber");
                //var contragentList = wsResponse.Select(x => new T_Contragent
                //{
                //    Code1C = string.Empty,
                //    Name = $"{x.LastName} {x.FirstName}",
                //    PersonalNumber = x.StudentID
                //}).Distinct(contragentComparer).ToList();




                DictionaryHelper.SaveMobiles(mobileList);
                //DictionaryHelper.SaveContragentsPersonalNumber(contragentList);

                var mobileDictionary = DictionaryHelper.GetMobileDictionary(mobileList.Select(x => x.Mobile).ToArray());
                foreach (var ws in wsResponse)
                {
                    var contragent = db.T_Contragent.FirstOrDefault(c => c.PersonalNumber == ws.StudentID && c.Name == ws.StudentName);
                    if (contragent == null)
                    {
                        contragent = new T_Contragent { Code1C = string.Empty, Name = ws.StudentName, PersonalNumber = ws.StudentID };
                        db.T_Contragent.Add(contragent);
                    }

                    var debt = db.T_Debt.Create();
                    debt.T_Contragent = contragent;
                    debt.Date = date;
                    debt.Amount = Convert.ToDecimal(ws.Debt);
                    debt.Currency = ws.CurrencyCode.IfNullEmpty().Length > 0 ? ws.CurrencyCode : "GEL";
                    debt.CreateDate = DateTime.Now;
                    debt.IP = ip;
                    debt.Grade = ws.Grade.IfNullEmpty();
                    debt.Message = template.Replace("{student}", $"{ws.StudentName}").Replace("{amount}", ws.Debt.ToString("f0")).Replace("{currency}", ws.CurrencyCode);
                    db.T_Debt.Add(debt);

                    var lst = new List<string>();
                    foreach (var dd in ws.MotherMobileArray.Where(x => !lst.Contains(x.Mobile)))
                    {
                        var d2 = db.T_DebtDetail.Create();
                        d2.T_Debt = debt;
                        d2.MobileID = mobileDictionary[dd.Mobile];
                        d2.RelationTypeID = (byte)RelationType.Mother;
                        d2.StatusID = (byte)SMSStatus.Pending;
                        d2.TryCount = 0;
                        db.T_DebtDetail.Add(d2);
                        lst.Add(dd.Mobile);
                    }

                    foreach (var dd in ws.FatherMobileArray.Where(x => !lst.Contains(x.Mobile)))
                    {
                        var d3 = db.T_DebtDetail.Create();
                        d3.T_Debt = debt;
                        d3.MobileID = mobileDictionary[dd.Mobile];
                        d3.RelationTypeID = (byte)RelationType.Father;
                        d3.StatusID = (byte)SMSStatus.Pending;
                        d3.TryCount = 0;
                        db.T_DebtDetail.Add(d3);
                        lst.Add(dd.Mobile);
                    }
                }

                db.SaveChanges();
            }
        }
    }
}
