using System.ComponentModel.DataAnnotations.Schema;

namespace QuantumGate.BookCatalog.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public Category() 
        {
            Id = 0;
            Name = string.Empty;
        }
    }
}
