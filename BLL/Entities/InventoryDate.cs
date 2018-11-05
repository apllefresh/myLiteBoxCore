using System;
using System.Collections.Generic;

namespace BLL.Entities
{
    public class InventoryDate
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public DateTime dateget2price { get; set; }

        IEnumerable<InventoryHead> inventoryHeads { get; set; }
    }
}
