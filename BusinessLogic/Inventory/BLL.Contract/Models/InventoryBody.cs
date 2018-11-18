namespace Inventory.BLL.Contract.Models
{
    public class InventoryBody
    {
        public int Id { get; set; }
        public int RowNumber { get; set; }
        public int goodId { get; set; }
        public decimal Count { get; set; }
        public int InventoryHeadId { get; set; }
    }
}
