using Microsoft.EntityFrameworkCore;

namespace apicampaign.Models
{
    public class onlinecampaignContext : DbContext
    {
        public onlinecampaignContext(DbContextOptions<onlinecampaignContext> options)
        : base(options)
        {

        }

        public DbSet<TodoItem> todoItems { get; set; }
        public DbSet<WO_MAS_CAMPAIGN> WoMasCampaigns { get; set; }
    }
}