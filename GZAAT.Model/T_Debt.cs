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
    
    public partial class T_Debt
    {
        public T_Debt()
        {
            this.T_DebtDetail = new HashSet<T_DebtDetail>();
        }
    
        public int ID { get; set; }
        public int ContragentID { get; set; }
        public System.DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Message { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string IP { get; set; }
        public string Grade { get; set; }
    
        public virtual T_Contragent T_Contragent { get; set; }
        public virtual ICollection<T_DebtDetail> T_DebtDetail { get; set; }
    }
}
