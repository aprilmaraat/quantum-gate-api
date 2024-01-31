using QuantumGate.BookCatalog.Models;

namespace QuantumGateAPI.Tests.MockData
{
    public class CategoryMockData
    {
        public static List<Category> List()
        {
            return new List<Category>
            {
                new Category 
                { 
                    //Id = 1,
                    Name = "Fantasy" 
                },
                new Category 
                { 
                    //Id = 2,
                    Name = "Educational"
                },
                new Category 
                { 
                    //Id = 3, 
                    Name = "Space"
                }
            };
        }
    }
}
