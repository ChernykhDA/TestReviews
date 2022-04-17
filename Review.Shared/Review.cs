using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review.Shared
{
    /// <summary>
    /// Модель отзыв
    /// </summary>
    public class ReviewModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? Rating { get; set; }

        public string? OrgName { get; set; }

        public string? OrgAddress { get; set; }

        public string? NotLike { get; set; }

        public string Like { get; set; }

        public string? Comment { get; set; }

        public int? UserId { get; set; }

        public virtual User? User { get; set; }
    }
}
