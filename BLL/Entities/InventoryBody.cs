namespace BLL.Entities
{
    public class InventoryBody
    {
        public int Id { get; set; }
        public int RowNumber { get; set; }

        public int goodid { get; set; }
        public decimal Count { get; set; }

        public int InventoryHeadId { get; set; }
    }
}
