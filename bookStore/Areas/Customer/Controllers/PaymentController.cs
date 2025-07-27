
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace bookStore.Areas.Customer.Controllers
{
    public class PaymentController : Controller
    {
        [HttpPost]
        public async Task<ActionResult> VerifyKhalti()
        {
            string jsonString;
            using (var reader = new StreamReader(Request.Body))
            {
                jsonString = reader.ReadToEnd();
            }

            // Deserialize JSON to KhaltiPayload
            var payload = JsonSerializer.Deserialize<KhaltiPayload>(jsonString);

            // Prepare HTTP client to verify payment with Khalti
           

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "7082655db5b14b14a6faa11272b85845");

            var data = new
            {
                token = payload.token,
                amount = payload.amount
            };

            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://khalti.com/api/v2/payment/verify/", content);
            var responseString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return Json(new { success = true, message = "Payment successful" });
            }

            return Json(new { success = false, message = "Verification failed", error = responseString });
        }
    }

    public class KhaltiPayload
    {
        public string token { get; set; }
        public int amount { get; set; }
    }
}


