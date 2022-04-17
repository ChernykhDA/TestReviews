using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review.Shared
{
    public class UToken
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public string Token { get; set; }

        public DateTime ExpiryDate { get; set; }

        public virtual User? User { get; set; }
    }
}
