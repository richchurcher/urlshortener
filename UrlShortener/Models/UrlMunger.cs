using System;
using System.Linq;

namespace UrlShortener.Models
{
    public static class UrlMunger
    {
        public static string Shortform(string url)
        {
            UrlShortenerDbContext context = new UrlShortenerDbContext();

            url = url.Substring(url.IndexOf(":") + 3);

            int length = 1;
            string shortForm = "";
            do
            {
                shortForm = SemiRandomString(length);
                length++;
            } while (context.Urls.Any(u => u.Shortform == shortForm));

            if (shortForm.Length < url.Length)
            {
                return shortForm;
            }
            return url;
        }

        private static string SemiRandomString(int length)
        {
            // Thanks, SO.
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvxyz0123456789-._@!()";
            Random random = new Random();
            return new string(Enumerable
                .Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)])
                .ToArray());
        }
    }
}