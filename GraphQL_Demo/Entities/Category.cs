namespace GraphQL_Demo.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;

        // has menus
        public List<Menu> Menus { get; set; } = new List<Menu>();
    }
}
