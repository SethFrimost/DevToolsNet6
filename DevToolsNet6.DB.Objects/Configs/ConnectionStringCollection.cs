using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsNet.DB.Objects.Configs
{
    public class ConnectionStringGroupCollection
    {
        public List<ConnectionStringGroup> connectionGroups { get; set; }



        public List<ConnectionString> GetAllConnectionStrings()
        {
            if (connectionGroups != null)
            {
                List<ConnectionString> cs = new List<ConnectionString>();
                connectionGroups.ForEach(x => cs.AddRange(getRecusive(x)));
                return cs;
            }
            else return new List<ConnectionString>();
        }

        public List<ConnectionString> GetByName(string name)
        {
            return GetAllConnectionStrings().FindAll(x=>x.Name==name);
        }

        private List<ConnectionString> getRecusive(ConnectionStringGroup g)
        {
            if(g != null) { 
                List<ConnectionString> cs = new List<ConnectionString>();
                cs.AddRange(g.connectionStrings);
                if (g.Groups != null) g.Groups.ForEach(x => cs.AddRange(getRecusive(x)));
                return cs;
            }
            else 
            {
                return new List<ConnectionString>();
            }
        }
    }
}
