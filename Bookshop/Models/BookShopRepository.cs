namespace Bookshop.Models
{
    public class BookShopRepository : IBookShopRepository
    {
        public string BookCollectionName { get; set; }

        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }

    public interface IBookShopRepository
    {
        string BookCollectionName { get; set; }

        string ConnectionString { get; set; }

        string DatabaseName { get; set; }
    }
}