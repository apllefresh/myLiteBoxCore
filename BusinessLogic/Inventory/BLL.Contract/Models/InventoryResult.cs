namespace Inventory.BLL.Contract.Models
{
    public class InventoryResult
    {
        public int Id { get; set; }
        public decimal CountFact { get; set; }
        public decimal SumFact { get; set; }
        public decimal CountReal { get; set; }
        public decimal SumReal { get; set; }
        public decimal CountDiff { get; set; }
        public decimal SumDiff { get; set; }

        public int GoodGroupId { get; set; }
        public int DepartmentId { get; set; }
        public int InventoryDateId { get; set; }
    }
}
