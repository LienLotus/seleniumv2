using SeleniumFramework.Database;
using System;
using System.Data.SqlClient;

namespace SeleniumFramework.Models
{
    public class Article : Entity
    {
        public string Title
        {
            get; set;
        }
        public string Description
        {
            get; set;
        }
        public string Content
        {
            get; set;
        }
        public string Tag
        {
            get; set;
        }


        public override ProcCall ToProcCall()
        {
            throw new NotImplementedException();
        }
    }
}
