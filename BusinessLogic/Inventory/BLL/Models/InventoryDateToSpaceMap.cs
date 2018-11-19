namespace Inventory.BLL.Models
{
    public class InventoryDateToSpaceMap
    {
        int InventoryDateId { get; set; }
        int InventorySpaceId { get; set; }
        int PersonFromWarehouseId { get; set; }
        int PersonFromOfficeId { get; set; }
    }
}
