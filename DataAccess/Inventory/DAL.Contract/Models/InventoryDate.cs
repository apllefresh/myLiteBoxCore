﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.DAL.Contract.Models
{
    [Table(name: "inventorydate")]
    public class InventoryDate
    {
        [Column(name: "id")]
        public int Id { get; set; }

        [Column(name: "date")]
        public DateTime Date { get; set; }

        [Column(name: "dateget2price")]
        public DateTime DateGet2Price { get; set; }
    }
}
