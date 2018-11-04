namespace BLL.Entities
{
    public class Good
    {
        public int Id { get; set; }
        public string Ean { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int DepartmentId { get; set; }
        public int GoodGroupId { get; set; }
    }
}
