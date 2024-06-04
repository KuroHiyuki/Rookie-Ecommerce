using EcommerceWeb.Mvc.Models.Common;
using Newtonsoft.Json;

namespace EcommerceWeb.Mvc.Extensions
{
    public static class Extension
    {
        public async static Task<string> ErrorRespone(dynamic response)
        {
            var Content = await response.Content.ReadAsStringAsync();
            var error = JsonConvert.DeserializeObject<ErrorResponse>(Content)!;
            return error.tilte;
        }
    }
}
