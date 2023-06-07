using MagnesiaPcShop.Mvc.Models;
using System.Text.Json;

namespace MagnesiaPcShop.Mvc.Extensions
{
    public static class SessionExtensions
    {
        public static void SetJson<T>(this ISession session, string key, T value)
        {
            var serialized = JsonSerializer.Serialize<T>(value);
            session.SetString(key, serialized);
        }

        public static T GetJson<T>(this ISession session, string key)
        {
            var serializedString = session.GetString(key);
            if (serializedString == null)
            {
                return default(T);
            }
            return JsonSerializer.Deserialize<T>(serializedString);
        }
    }
}
