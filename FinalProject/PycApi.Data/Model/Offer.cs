using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PycApi.Data
{
    public class Offer
    {
        public virtual int Id { get; set; }
        public virtual int? Amount { get; set; }
        public virtual int? Percentage { get; set; }
        public virtual int? ProductId { get; set; }
    }
}
