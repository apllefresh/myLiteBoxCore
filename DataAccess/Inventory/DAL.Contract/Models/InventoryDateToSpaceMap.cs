using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.DAL.Contract.Models
{
    [Table(name: "inventorydatetospacemap")]
    public class InventoryDateToSpaceMap
    {
        [Column(name: "id")]
        public int Id { get; set; }

        [Column(name: "inventorydateid")]
        public int InventoryDateId { get; set; }

        [Column(name: "inventoryspaceid")]
        public int InventorySpaceId { get; set; }

        [Column(name: "personfromwarehouseid")]
        public int PersonFromWarehouseId { get; set; }

        [Column(name: "personfromofficeid")]
        public int PersonFromOfficeId { get; set; }
    }
}
