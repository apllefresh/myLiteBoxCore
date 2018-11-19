using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryDAL.Entities
{
    [Table(name: "good")]
    public class Good
    {
        [Column(name: "id")]
        public int Id { get; set; }
        [Column(name: "ean")]
        public string Ean { get; set; }
        [Column(name: "name")]
        public string Name { get; set; }
        [Column(name: "price")]
        public decimal Price { get; set; }

        [Column(name: "departmentid")]
        public int DepartmentId { get; set; }
        [Column(name: "goodgroupid")]
        public int GoodGroupId { get; set; }
    }
}
