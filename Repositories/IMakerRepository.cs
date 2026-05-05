using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using Test.DTOs;

namespace Test.Repositories
{
    public interface IMakerRepository
    {
        Task<ManufacturerRequestDto> GetMakerAsync(int id);
        Task CreateMakerAsync(CreateMakerRequest request);
    }
}
