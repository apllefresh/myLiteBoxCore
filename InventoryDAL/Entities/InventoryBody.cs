using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryDAL.Entities
{
    [Table(name: "inventorybody")]
    public class InventoryBody
    {
        [Column(name: "id")]
        public int Id { get; set; }
        [Column(name: "rownumber")]
        public int RowNumber { get; set; }
        [Column(name: "goodid")]
        public int goodId { get; set; }
        [Column(name: "count")]
        public decimal Count { get; set; }
        [Column(name: "inventoryheadid")]
        public int InventoryHeadId { get; set; }
    }
}
