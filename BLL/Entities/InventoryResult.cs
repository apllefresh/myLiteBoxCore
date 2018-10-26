namespace BLL.Entities
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

        Department department { get; set; }
        InventoryDate inventoryDate { get; set; }
    }
}
