//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GZAAT.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class VW_SMSDetail_List
    {
        public int ID { get; set; }
        public int MobileID { get; set; }
        public System.DateTime Date { get; set; }
        public string Mobile { get; set; }
        public byte StatusID { get; set; }
        public Nullable<System.DateTime> SentDate { get; set; }
        public byte TryCount { get; set; }
        public string Message { get; set; }
        public string MobileOwner { get; set; }
    }
}
