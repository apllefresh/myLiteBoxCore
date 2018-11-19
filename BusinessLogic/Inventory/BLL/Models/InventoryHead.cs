using System;

namespace Inventory.BLL.Models
{
    public class InventoryHead
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int Number { get; set; }

        public int PersonFromWarehouseId { get; set; }
        public int PersonFromOfficeId { get; set; }
        public int InventorySpaceId { get; set; }
        public int InventoryDateId { get; set; }
    }
}
