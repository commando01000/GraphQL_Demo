
using GraphQL.Types;
using GraphQL_Demo.Query;

namespace GraphQL_Demo
{
    public class MenuSchema : Schema
    {
        public MenuSchema(MenuQuery menuQuery)
        {
            Query = menuQuery;
        }
    }
}
