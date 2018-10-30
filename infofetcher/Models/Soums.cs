using System;
using System.Collections.Generic;

namespace infofetcher.Models
{
    public partial class Soums
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int? Age { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Language { get; set; }
    }
}
