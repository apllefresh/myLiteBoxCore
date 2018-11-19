using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.DAL.Contract.Models
{
    [Table(name: "inventoryspace")]
    public class InventorySpace
    {
        [Column(name: "id")]
        int Id { get; set; }
        [Column(name: "name")]
        string Name { get; set; }
    }
}
