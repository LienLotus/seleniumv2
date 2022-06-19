using System.Collections.Generic;
using System.Data.SqlClient;

namespace SeleniumFramework.Database
{
    public class ProcCall
    {
        private string _schemaName = "dbo";
        private string _procName = "SELENIUM_";

        public string SchemaName { get { return _schemaName; } }
        public string ProcName
        {
            get { return _procName; }
        }

        public List<SqlParameter> _procParameters = new List<SqlParameter>();
        public List<SqlParameter> ProcParameters { 
            get 
            {
                return _procParameters;
            }
        }

        public ProcCall(string name)
        {
            _procName += name;
        }

    }
}
