using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryDAL.Entities
{
    [Table(name: "department")]
    public class Department
    {
        [Column(name: "id")]
        public int Id {get;set;}
        [Column(name: "name")]
        public string Name {get;set;}
    }
}
