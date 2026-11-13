using baitapvenha.Models;

namespace baitapvenha.Data
{
    public static class SeedData
    {
        public static List<Category> Categories = new List<Category>
        {
            new Category { Id = 1, Name = "Điện thoại" },
            new Category { Id = 2, Name = "Máy tính xách tay" }
        };

        public static List<Product> Products = new List<Product>();
    }
}