using System.Data.Entity;

namespace WPF_HW1.Model
{
    class MyContext : DbContext
    {

        public MyContext()
            : base("SanyaConnection")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<MyContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyContext, DBConfig>("SanyaConnection"));
        }

        
        public DbSet<User> Users { get; set; }
        public DbSet<TimeClock> TimeClocks { get; set; }

       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new User.UserEntityConfiguration());
            modelBuilder.Configurations.Add(new TimeClock.TimeClockConfiguration());
        }
    }
}
