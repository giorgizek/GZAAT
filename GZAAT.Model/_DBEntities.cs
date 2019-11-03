using System.Data.Entity.Infrastructure;

namespace GZAAT.Model
{
    public partial class DBEntities
    {
        public DBEntities(int? commandTimeOut)
        {
            var objectContext = (this as IObjectContextAdapter).ObjectContext;

            // Sets the command timeout for all the commands
            objectContext.CommandTimeout = commandTimeOut;
        }
        //public DBEntities(string connectionString) : base(connectionString) { }
        //public DBEntities(string connectionString, int? commandTimeOut)
        //    : base(connectionString)
        //{
        //    var objectContext = (this as IObjectContextAdapter).ObjectContext;

        //    // Sets the command timeout for all the commands
        //    objectContext.CommandTimeout = commandTimeOut;
        //}
        //private void SetDbTransactionOnEntityConnection(EntityConnection ec, SqlTransaction sqlTran)
        //{
        //    FieldInfo fldCurrTran = typeof(EntityConnection).GetField("_currentTransaction", BindingFlags.NonPublic | BindingFlags.Instance);
        //    if (fldCurrTran.GetValue(ec) == null) // Only set if no transaction active yet 
        //    {
        //        object[] args = new object[2] { ec, sqlTran };
        //        EntityTransaction et = (EntityTransaction)Activator.CreateInstance(typeof(EntityTransaction), BindingFlags.NonPublic | BindingFlags.Instance, null, args, CultureInfo.CurrentCulture);
        //        fldCurrTran.SetValue(ec, et);
        //    }
        //}
    }
}
