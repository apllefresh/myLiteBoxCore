using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryDAL.Entities
{
    [Table(name: "goodgroup")]
    public class GoodGroup
    {
        [Column(name: "id")]
        public int Id { get; set; }
        [Column(name: "name")]
        public string Name { get; set; }
        [Column(name: "departmentid")]
        public int DepartmentId { get; set; }
    }
}