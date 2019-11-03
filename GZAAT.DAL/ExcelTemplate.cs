using GZAAT.Model;
using System;
using System.Linq;
using System.Xml.Serialization;
using Zek.Extensions;

namespace GZAAT.DAL
{
    [Serializable]
    public class ExcelTemplate
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Grade { get; set; }
        public string StudentID { get; set; }
        public string Parent1LastName { get; set; }
        public string Parent1FirstName { get; set; }
        public string Parent1Mobile { get; set; }
        public string Parent2LastName { get; set; }
        public string Parent2FirstName { get; set; }
        public string Parent2Mobile { get; set; }
        public string CurrencyCode { get; set; }
        public double Debt { get; set; }
        //public double Debt { get; set; }
        //public string CurrencyCode { get; set; }
        public string StudentName => LastName.Add(" ", FirstName);
        //public string PersonalNumber { get; set; }
        //public string StudentMobilePhone { get; set; }
        //public string MotherFirstAndLastName { get; set; }
        //public string MotherMobilePhone { get; set; }
        //public string FatherFirstAndLastName { get; set; }
        //public string FatherMobilePhone { get; set; }


        public void SplitMobiles()
        {
            //var tmpStudentMobileArray = DictionaryHelper.ParsedMobileNumbers(StudentMobilePhone).Split(',', ';').Where(x => (x.Length == 9 && x.StartsWith("5")) || (x.Length == 12 && x.StartsWith("9955"))).ToArray();
            var tmpMotherMobileArray = DictionaryHelper.ParsedMobileNumbers(Parent1Mobile).Split(',', ';').Where(x => (x.Length == 9 && x.StartsWith("5")) || (x.Length == 12 && x.StartsWith("9955"))).ToArray();
            var tmpFatherMobileArray = DictionaryHelper.ParsedMobileNumbers(Parent2Mobile).Split(',', ';').Where(x => (x.Length == 9 && x.StartsWith("5")) || (x.Length == 12 && x.StartsWith("9955"))).ToArray();


            //StudentMobileArray = new DD_Mobile[tmpStudentMobileArray.Length];
            //for (int i = 0; i < tmpStudentMobileArray.Length; i++)
            //    StudentMobileArray[i] = new DD_Mobile { Mobile = tmpStudentMobileArray[i], Name = this.StudentName };

            MotherMobileArray = new DD_Mobile[tmpMotherMobileArray.Length];
            for (var i = 0; i < tmpMotherMobileArray.Length; i++)
                MotherMobileArray[i] = new DD_Mobile
                {
                    Mobile = tmpMotherMobileArray[i],
                    Name =
                    $"{Parent1FirstName} {Parent1LastName}"
                };

            FatherMobileArray = new DD_Mobile[tmpFatherMobileArray.Length];
            for (var i = 0; i < tmpFatherMobileArray.Length; i++)
                FatherMobileArray[i] = new DD_Mobile
                {
                    Mobile = tmpFatherMobileArray[i],
                    Name =
                    $"{Parent2FirstName} {Parent2LastName}"
                };
        }

        [XmlIgnore]
        public DD_Mobile[] StudentMobileArray
        {
            get;
            private set;
        }
        [XmlIgnore]
        public DD_Mobile[] MotherMobileArray
        {
            get;
            private set;
        }
        [XmlIgnore]
        public DD_Mobile[] FatherMobileArray
        {
            get;
            private set;
        }


    }
}
