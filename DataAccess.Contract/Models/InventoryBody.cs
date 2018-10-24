using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DataAccess.Contract.Models
{
    public class InventoryBody
    {
        public string Id { get; set; }
        public Good Good { get; set; }
        public decimal Netto { get; set; }
        public decimal Price { get; set; }

        public int Active { get; set; }
    }
}
