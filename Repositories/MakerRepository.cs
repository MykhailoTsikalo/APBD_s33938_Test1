using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Test.DTOs;

namespace Test.Repositories
{
    public class MakerRepository : IMakerRepository
    {
        private readonly IConfiguration _config;

        public MakerRepository(IConfiguration config)
        {
            _config = config;
        }

        async Task<ManufacturerRequestDto> IMakerRepository.GetMakerAsync(int id)
        {
            var maker = new ManufacturerRequestDto();


            using var conn = new SqlConnection(_config.GetConnectionString("Default"));
            await conn.OpenAsync();

            var cmd = new SqlCommand("" +
                "SELECT m.Id, m.Name, p.Id, p.Name, p.Description, p.StickerPrice, pt.Id, pt.Name, v.VendorCode, v.Amount, v.PricePerUnit" +
                "FROM Makers m" +
                "JOIN Products p ON m.Id = p.MakerId" +
                "JOIN ProductTypes pt ON p.ProductTypeId = pt.Id" +
                "JOIN VendorProduct v ON p.VendorId = v.Id" +
                "WHERE m.Id = @id", conn);

            cmd.Parameters.AddWithValue("@id", id);
            
            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync()) 
            { 
                int MakerId = reader.GetInt32(0);
                string MakerName = reader.GetString(1);
                List<MakerProductRequestDto> products = new List<MakerProductRequestDto>();

                    while (await reader.ReadAsync())
                {
                    int ProductId = reader.GetInt32(3);
                    string ProductName = reader.GetString(4);
                    string ProductDescription = reader.GetString(5);
                    //....

                    products.Add(new MakerProductRequestDto
                    {
                        Id = ProductId,
                        Name = ProductName,
                        Description = ProductDescription,
                        //...
                    });

                    maker.Id = MakerId;
                    maker.Name = MakerName;
                    maker.Products = products;
                }
            }

            return maker;

        }


        async Task IMakerRepository.CreateMakerAsync(CreateMakerRequest request)
        {
            using var conn = new SqlConnection(_config.GetConnectionString("Default"));
            await conn.OpenAsync();

            var cmd = new SqlCommand("INSERT INTO Makers (Id, Name) VALUES (@id, @name); SELECT SCOPE_IDENTITY();", conn);
            cmd.Parameters.AddWithValue("@id", request.Id);
            cmd.Parameters.AddWithValue("@name", request.Name);



        }
    }
}
