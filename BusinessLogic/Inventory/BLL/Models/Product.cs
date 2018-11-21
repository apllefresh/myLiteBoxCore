namespace Inventory.BLL.Contract.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Ean { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int ProductGroupId { get; set; }
        public int DepartmentId { get; set; }
    }
}
