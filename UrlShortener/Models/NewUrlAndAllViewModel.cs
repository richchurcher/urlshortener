using System.Collections.Generic;

namespace UrlShortener.Models
{
    public class NewUrlAndAllViewModel
    {
        public Url NewUrl { get; set; } 
        public IEnumerable<Url> All { get; set; }
    }
}