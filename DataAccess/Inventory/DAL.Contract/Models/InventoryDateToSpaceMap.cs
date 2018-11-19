using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.DAL.Contract.Models
{
    [Table(name: "inventorydatetospacemap")]
    public class InventoryDateToSpaceMap
    {
        [Column(name: "inventorydateid")]
        int InventoryDateId { get; set; }

        [Column(name: "inventoryspaceid")]
        int InventorySpaceId { get; set; }

        [Column(name: "personfromwarehouseid")]
        int PersonFromWarehouseId { get; set; }

        [Column(name: "personfromofficeid")]
        int PersonFromOfficeId { get; set; }
    }
}
