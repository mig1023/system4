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

        [HttpGet("api/foxprice/{address}/{center}/{oversize}")]
        public async Task<string> FoxPrice(string address, int center, int oversize)
        {
            var type = DAL.Constants.ThisIsSaintPetersburg(center) ? "SPb" : "Moscow";
            var url = Secret.Fox["Url"]["Calc"];
            var login = $"login={Secret.Fox[type]["Login"]}";
            var password = $"password={Secret.Fox[type]["Password"]}";
            var sender = $"senderAddress={Secret.Fox[type]["SenderAddress"]}";
            var oversizeWeight = oversize == 1 ? "0.6" : "0.3";
            var weight = $"weight={oversizeWeight}";
            var recipient = $"recipientAddress={address}";

            var request = $"{url}{login}&{password}&{sender}&{recipient}&{weight}&qty=1";

            using (var client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(request);

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
