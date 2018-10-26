using System;
using System.Collections.Generic;

namespace BLL.Entities
{
    public class InventoryDate
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal DateGet2Price { get; set; }

        IEnumerable<InventoryHead> inventoryHeads { get; set; }
    }
}
