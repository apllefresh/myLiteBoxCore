using System.ComponentModel.DataAnnotations.Schema;

namespace Products.DAL.Models
{
    [Table(name: "product")]
    public class Product
    {
        [Column(name: "id")]
        public int Id { get; set; }

        [Column(name: "ean")]
        public string Ean { get; set; }

        [Column(name: "name")]
        public string Name { get; set; }

        [Column(name: "price")]
        public decimal Price { get; set; }

        [Column(name: "productgroupid")]
        public int ProductGroupId { get; set; }

        [Column(name: "departmentid")]
        public int DepartmentId { get; set; }
    }
}
