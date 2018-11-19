using System.ComponentModel.DataAnnotations.Schema;

namespace Products.DAL.Models
{
    [Table(name: "productgroup")]
    public class ProductGroup
    {
        [Column(name: "id")]
        public int Id { get; set; }

        [Column(name: "name")]
        public string Name { get; set; }

        [Column(name: "departmentid")]
        public int DepartmentId { get; set; }
    }
}
