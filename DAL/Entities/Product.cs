namespace EPAM_entity.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public Supplier Supplier { get; set; }
        public int SupplierId { get; set; }
    }
}