namespace Inventory.BLL.Contract.Models
{
    public class InventoryDateToSpaceMap
    {
        public int Id { get; set; }
        public int InventoryDateId { get; set; }
        public int InventorySpaceId { get; set; }
        public int PersonFromWarehouseId { get; set; }
        public int PersonFromOfficeId { get; set; }
    }
}
