using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.DAL.Contract.Models
{
    [Table(name: "inventoryresult")]
    public class InventoryResult
    {
        [Column(name: "id")]
        public int Id { get; set; }

        [Column(name: "countfact")]
        public decimal CountFact { get; set; }
        [Column(name: "sumfact")]
        public decimal SumFact { get; set; }

        [Column(name: "countreal")]
        public decimal CountReal { get; set; }
        [Column(name: "sumreal")]
        public decimal SumReal { get; set; }

        [Column(name: "countdiff")]
        public decimal CountDiff { get; set; }
        [Column(name: "sumdiff")]
        public decimal SumDiff { get; set; }

        [Column(name: "goodgroupid")]
        public int GoodGroupId { get; set; }
        [Column(name: "departmentid")]
        public int DepartmentId { get; set; }
        [Column(name: "inventorydateid")]
        public int InventoryDateId { get; set; }
    }
}
