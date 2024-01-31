using QuantumGate.BookCatalog.Models;

namespace QuantumGateAPI.Tests
{
    public class BookMockData
    {
        public static List<Book> List()
        {
            return new List<Book> 
            {
                new Book
                {
                    //Id = 1,
                    //CategoryId = 1,
                    Title = "Journey Through Time",
                    Description = "An exhilarating exploration of history's most pivotal moments, seen through the eyes of those who lived them.",
                    PublishDateUtc = new DateTime(2021, 5, 15, 0, 0, 0, DateTimeKind.Utc)
                },
                new Book
                {
                    //Id = 2,
                    //CategoryId = 2,
                    Title = "Mysteries of the Deep",
                    Description = "Dive into the unknown depths of the ocean to uncover secrets hidden beneath the waves.",
                    PublishDateUtc = new DateTime(2022, 8, 22, 0, 0, 0, DateTimeKind.Utc)
                },
                new Book
                {
                    //Id = 3,
                    //CategoryId = 2,
                    Title = "Galactic Endeavors",
                    Description = "A captivating journey through the cosmos, exploring distant galaxies and the mysteries of the universe.",
                    PublishDateUtc = new DateTime(2023, 3, 10, 0, 0, 0, DateTimeKind.Utc)
                }
            };
        }

        public static List<Book> EmptyList() 
        {
            return new List<Book>();
        }

        public static Book New()
        {
            return new Book
            {
                Title = "The Art of Cuisine",
                Description = "A delightful exploration of culinary arts, blending traditional techniques with modern innovation.",
                PublishDateUtc = new DateTime(2024, 1, 5, 0, 0, 0, DateTimeKind.Utc)
            };
        }
    }
}
