using System.Data;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public interface MessyComponent
    {
        void do_something_with(IDbConnection connection);
    }

    public class DefaultOtherMessyComponent : MessyComponent
    {
        public void do_something_with(IDbConnection connection)
        {
            using (connection)
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}