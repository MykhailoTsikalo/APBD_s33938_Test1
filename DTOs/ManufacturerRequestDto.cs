namespace Test.DTOs
{
    public class ManufacturerRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<MakerProductRequestDto> Products { get; set; } = new();

    }
}
