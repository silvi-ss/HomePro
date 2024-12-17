using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomePro.Data.Models
{
    public class UserFavoriteService
    {
        public Guid UserId { get; set; }
        public virtual ApplicationUser User { get; set; } = null!;
        public Guid ServiceCatalogId { get; set; }
        public virtual ServiceCatalog Service { get; set; } = null!;

    }
}
