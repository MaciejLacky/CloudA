using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudA.Data
{
    public class CloudAContext : DbContext
    {
        public CloudAContext(DbContextOptions<CloudAContext> options)
            : base(options)
        {
        }
        public DbSet<Client> Client { get; set; }

        public DbSet<Event> Event { get; set; }

    }
}
