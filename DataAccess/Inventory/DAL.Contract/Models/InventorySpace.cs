using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.DAL.Contract.Models
{
    [Table(name: "inventoryspace")]
    public class InventorySpace
    {
        [Column(name: "id")]
        public int Id { get; set; }
        [Column(name: "name")]
        public string Name { get; set; }
    }
}
