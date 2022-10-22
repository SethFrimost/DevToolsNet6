using DevToolsNet.DB.Generator.Interfaces;
using DevToolsNet.DB.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace DevToolsNet.DB.Generator
{
    public class TableCode 
    {
        public string Table { get; set; }
        public string Code { get; set; }
    }
}
