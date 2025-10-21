using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace system4.API
{
    [Authorize]
    [ApiController]
    public class Docs : ControllerBase
    {
        [HttpGet("api/dadata/{address}")]
        public async Task<string> Dadata(string address)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                    client.DefaultRequestHeaders.Add("Authorization", $"Token {Secret.Dadata["Token"]}");

                    HttpResponseMessage response = await client.PostAsJsonAsync(Secret.Dadata["Url"], new { query = address });

                    if (!response.IsSuccessStatusCode)
                    {
                        return string.Empty;
                    }

                    return await response.Content.ReadAsStringAsync();
                }
                catch (Exception)
                {
                    return string.Empty;
                }
            }
        }
    }
}
