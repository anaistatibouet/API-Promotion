using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_PromotionsCodes.Datas
{
    public class APIPromotionCodesContext : DbContext
    {

        public APIPromotionCodesContext(DbContextOptions<APIPromotionCodesContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Promotions> PromotionsList { get; set; }
    }
}
