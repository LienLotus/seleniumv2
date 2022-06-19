using SeleniumFramework.Database;
using System;

namespace SeleniumFramework.Models
{
    public abstract class Entity
    {

        public String Feature { get; set; }

        public String LocationCodeFeature { get;set; }
        public void Populate(string[][] args)
        {
            for (int i = 0; i < args[0].Length; i++)
            {
                var property = this.GetType().GetProperty(args[0][i]?.Trim());
                if (property != null)
                {
                    property.SetValue(this, args[1][i]);
                }
                
            }
        }

        public abstract ProcCall ToProcCall();

    }
}
