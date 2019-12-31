using System.Collections.Generic;

namespace EPAM_entity.Entities
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}