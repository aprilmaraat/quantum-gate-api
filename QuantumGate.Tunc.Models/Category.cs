namespace QuantumGate.BookCatalog.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category() 
        {
            Id = 0;
            Name = string.Empty;
        }
    }
}
