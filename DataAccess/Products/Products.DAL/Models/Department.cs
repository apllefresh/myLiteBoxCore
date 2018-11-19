using System.ComponentModel.DataAnnotations.Schema;

namespace Products.DAL.Models
{
    [Table(name: "department")]
    public class Department
    {
        [Column(name: "id")]
        public int Id { get; set; }

        [Column(name: "name")]
        public string Name { get; set; }

        [Column(name: "isofficedeprtment")]
        public bool isOfficeDeprtment { get; set; }
    }
}
