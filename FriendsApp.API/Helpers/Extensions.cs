using Microsoft.AspNetCore.Http;

namespace FriendsApp.API.Helpers
{
    public static class Extensions
    {
        public static void AddErrorToHeader(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }
    }
}