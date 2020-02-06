using System.Collections.Generic;
using System.Text;

namespace BunnyCdn.Serialization
{
    internal static class DictionaryHelper
    {
        public static string ToQueryString(Dictionary<string, string> dic)
        {
            var sb = new StringBuilder();

            sb.Append('?');

            foreach (var entry in dic)
            {
                if (sb.Length > 1)
                {
                    sb.Append('&');
                }

                sb.Append(entry.Key);
                sb.Append('=');
                sb.Append(entry.Value);
            }

            return sb.ToString();
        }
    }
}