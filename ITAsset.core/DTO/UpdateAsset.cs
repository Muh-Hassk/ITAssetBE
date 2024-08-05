using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITAsset.core.DTO
{
    public class UpdateAsset
    {
        public int Id { get; set; }
        public string Brand { get; set; } = null!;
        public string SerialNumber { get; set; } = null!;
        public DateTime? WarrantyExpirationDate { get; set; }
        public int? StatusId { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
