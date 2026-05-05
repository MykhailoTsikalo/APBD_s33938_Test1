namespace Test.DTOs
{
    public class MakerProductRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public List<ProductTypeRequestDto> ProductType = new();
        public List<VendorsRequestDto> Vendors = new();

    }
}
