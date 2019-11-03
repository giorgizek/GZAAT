using GZAAT.Model;
using System.Linq;
using System.Xml.Serialization;

namespace GZAAT.DAL.WS1C
{
    public partial class Contragents
    {
        public void SplitMobiles()
        {
            var tmpStudentMobileArray = DictionaryHelper.ParsedMobileNumbers(StudentMobilePhone).Split(',', ';').Where(x => (x.Length == 9 && x.StartsWith("5")) || (x.Length == 12 && x.StartsWith("9955"))).ToArray();
            var tmpMotherMobileArray = DictionaryHelper.ParsedMobileNumbers(MotherMobilePhone).Split(',', ';').Where(x => (x.Length == 9 && x.StartsWith("5")) || (x.Length == 12 && x.StartsWith("9955"))).ToArray();
            var tmpFatherMobileArray = DictionaryHelper.ParsedMobileNumbers(FatherMobilePhone).Split(',', ';').Where(x => (x.Length == 9 && x.StartsWith("5")) || (x.Length == 12 && x.StartsWith("9955"))).ToArray();


            StudentMobileArray = new DD_Mobile[tmpStudentMobileArray.Length];
            for (int i = 0; i < tmpStudentMobileArray.Length; i++)
                StudentMobileArray[i] = new DD_Mobile { Mobile = tmpStudentMobileArray[i], Name = Name };

            MotherMobileArray = new DD_Mobile[tmpMotherMobileArray.Length];
            for (int i = 0; i < tmpMotherMobileArray.Length; i++)
                MotherMobileArray[i] = new DD_Mobile { Mobile = tmpMotherMobileArray[i], Name = MotherFirstAndLastName };

            FatherMobileArray = new DD_Mobile[tmpFatherMobileArray.Length];
            for (int i = 0; i < tmpFatherMobileArray.Length; i++)
                FatherMobileArray[i] = new DD_Mobile { Mobile = tmpFatherMobileArray[i], Name = FatherFirstAndLastName };
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



        //[NonSerialized]
        //private DD_Mobile[] _StudentMobileArray;
        //public DD_Mobile[] StudentMobileArray
        //{
        //    get { return _StudentMobileArray; }
        //    private set { _StudentMobileArray = value; }
        //}

        //[NonSerialized]
        //private DD_Mobile[] _MotherMobileArray;
        //public DD_Mobile[] MotherMobileArray
        //{
        //    get { return _MotherMobileArray; }
        //    private set { _MotherMobileArray = value; }
        //}

        //[NonSerialized]
        //private DD_Mobile[] _FatherMobileArray;
        //public DD_Mobile[] FatherMobileArray
        //{
        //    get { return _FatherMobileArray; }
        //    private set { _FatherMobileArray = value; }
        //}
    }
}
