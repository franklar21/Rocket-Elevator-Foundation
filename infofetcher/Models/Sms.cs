using System;
using System.Collections.Generic;

namespace infofetcher.Models
{
    public partial class Sms
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
