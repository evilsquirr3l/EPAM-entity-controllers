using System.Collections.Generic;

namespace EPAM_entity.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }

    }
}