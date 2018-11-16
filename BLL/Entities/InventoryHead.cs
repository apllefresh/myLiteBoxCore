using System;

namespace BLL.Entities
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
