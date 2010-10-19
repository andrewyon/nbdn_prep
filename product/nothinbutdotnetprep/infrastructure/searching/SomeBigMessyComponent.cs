using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class SomeBigMessyComponent
    {
        ConnectionStringResolver resolver;
        MessyComponent component;
        Func<string, IDbConnection> connection_factory;

        public SomeBigMessyComponent():this(new DefaultResolver(),
            new DefaultOtherMessyComponent(),
            x => new SqlConnection(x))
        {
        }

        public SomeBigMessyComponent(ConnectionStringResolver resolver, MessyComponent component, Func<string, IDbConnection> connection_factory)
        {
            this.resolver = resolver;
            this.component = component;
            this.connection_factory = connection_factory;
        }

        public void do_something_that_will_be_difficult_to_test()
        {
            var connection = connection_factory(resolver.get_the_connection_string());
            component.do_something_with(connection);
        }
    }
}