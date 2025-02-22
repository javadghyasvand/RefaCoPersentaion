
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ServiceHost
{
    public class IpInfoLanguageMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _ipInfoToken;

        public IpInfoLanguageMiddleware(RequestDelegate next, string ipInfoToken)
        {
            _next = next;
            _ipInfoToken = ipInfoToken;
        }

        public async Task Invoke(HttpContext context)
        {
            // Check for user-selected language in a cookie
            var userSelectedLanguage = context.Request.Cookies["UserLanguage"];
            if (!string.IsNullOrEmpty(userSelectedLanguage))
            {
                // Apply user preference
                SetCulture(context, userSelectedLanguage);
                await _next(context);
                return;
            }

            // Fallback to IP-based detection
            var ipAddress =  context.Connection.RemoteIpAddress?.ToString();
           
           
            if (string.IsNullOrEmpty(ipAddress) || ipAddress == "::1")
            {
                ipAddress = "5.160.0.0"; // Example IP for testing
            }

            try
            {
                using var httpClient = new HttpClient();
                var response = await httpClient.GetFromJsonAsync<IpInfoResponse>(
                    $"https://ipinfo.io/{ipAddress}?token={_ipInfoToken}");

                if (response != null && !string.IsNullOrEmpty(response.Country))
                {
                    var culture = response.Country switch
                    {
                        "RU" => "ru-RU", // Russian
                        "IR" => "fa-IR", // Farsi
                        "AR" => "ar", // Arabic
                        "OM" => "ar", // Arabic
                        "AE" => "ar", // Arabic
                        "EG" => "ar", // Arabic
                        _ => "en-US"     // Default to English
                    };

                    SetCulture(context, culture);

                    // Optional: Log for debugging
                    Console.WriteLine($"Detected country: {response.Country}, Culture: {culture}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in IP info middleware: {ex.Message}");
            }

            await _next(context);
        }

        private void SetCulture(HttpContext context, string culture)
        {
            var requestCulture = new RequestCulture(culture);

            context.Features.Set<IRequestCultureFeature>(
                new RequestCultureFeature(requestCulture, new QueryStringRequestCultureProvider()));

            CultureInfo.CurrentCulture = new CultureInfo(culture);
            CultureInfo.CurrentUICulture = new CultureInfo(culture);
        }
    }

    // Helper class for deserializing ipinfo.io response
    public class IpInfoResponse
    {
        public string Country { get; set; }
    }
}
