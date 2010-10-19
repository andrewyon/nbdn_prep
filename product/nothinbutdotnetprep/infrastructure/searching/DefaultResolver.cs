using System;
using System.Configuration;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class DefaultResolver : ConnectionStringResolver
    {
        public string get_the_connection_string()
        {
            return ConfigurationManager.ConnectionStrings[0].ConnectionString;
        }
    }
}