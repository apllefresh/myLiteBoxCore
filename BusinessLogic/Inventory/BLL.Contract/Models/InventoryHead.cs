using System;

namespace Inventory.BLL.Contract.Models
{
    public class InventoryHead
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int Number { get; set; }

        public int InventoryDateId { get; set; }
    }
}
