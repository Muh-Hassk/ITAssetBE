using System;
using System.Collections.Generic;

namespace ITAsset.core.Data
{
    public partial class Asset
    {
        public int Id { get; set; }
        public string Brand { get; set; } = null!;
        public string SerialNumber { get; set; } = null!;
        public DateTime? WarrantyExpirationDate { get; set; }
        public string Status { get; set; } = null!;
        public DateTime? CreatedDate { get; set; }
    }
}
