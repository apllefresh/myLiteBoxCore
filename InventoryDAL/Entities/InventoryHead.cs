using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryDAL.Entities
{
    [Table(name: "inventoryhead")]
    public class InventoryHead
    {
        [Column(name: "id")]
        public int Id { get; set; }
        [Column(name: "createdon")]
        public DateTime CreatedOn { get; set; }
        [Column(name: "createdby")]
        public int CreatedBy { get; set; }
        [Column(name: "number")]
        public int Number { get; set; }

        [Column(name: "inventorydateid")]
        public int InventoryDateId { get; set; }
    }
}
