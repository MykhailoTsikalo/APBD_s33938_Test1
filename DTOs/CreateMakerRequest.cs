namespace Test.DTOs
{
    public class CreateMakerRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<MakerProductRequestDto> Products { get; set; } = new List<MakerProductRequestDto>();

    }
}
