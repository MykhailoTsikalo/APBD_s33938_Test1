namespace Test.DTOs
{
    public class VendorsRequestDto
    {
        public int Code { get; set; }
        public string Name { get; set; } = null!;
        public int Amount { get; set; }
        public decimal Price { get; set; }
    }
}
