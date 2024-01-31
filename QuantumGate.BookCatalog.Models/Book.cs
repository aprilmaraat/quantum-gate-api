namespace QuantumGate.BookCatalog.Models
{
    public class Book
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishDateUtc { get; set; }
        public Category Category { get; set; }

        public Book() 
        {
            Id = 0;
            CategoryId = 0;
            Title = string.Empty;
            Description = string.Empty;
            PublishDateUtc = DateTime.MinValue;
            Category = new Category();
        }
    }
}
