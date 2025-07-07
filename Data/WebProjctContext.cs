using WebProjct.Models;
using Microsoft.EntityFrameworkCore;
using WebProjct.Service;

namespace WebProjct.Data
{
    public class WebProjctContext : DbContext
    {
        public WebProjctContext(DbContextOptions<WebProjctContext> options)
        : base(options)
        {

        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecords { get; set; }


    }

}