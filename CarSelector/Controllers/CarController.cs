using Microsoft.AspNetCore.Mvc;

namespace CarSelector.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public CarController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpGet("getMakes")]
        public async Task<IActionResult> GetMakes()
        {
            var response = await _httpClient.GetStringAsync("https://vpic.nhtsa.dot.gov/api/vehicles/getallmakes?format=json");
            return Ok(response);
        }

        [HttpGet("getVehicleTypes/{makeId}")]
        public async Task<IActionResult> GetVehicleTypes(int makeId)
        {
            var response = await _httpClient.GetStringAsync($"https://vpic.nhtsa.dot.gov/api/vehicles/GetVehicleTypesForMakeId/{makeId}?format=json");
            return Ok(response);
        }

        [HttpGet("getModels/{makeId}/{year}/{vehicleType}")]
        public async Task<IActionResult> GetModels(int makeId, int year, string vehicleType)
        {
            var response = await _httpClient.GetStringAsync($"https://vpic.nhtsa.dot.gov/api/vehicles/GetModelsForMakeIdYear/makeId/{makeId}/modelyear/{year}?format=json");
            return Ok(response);
        }
    }
}
