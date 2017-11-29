using System.Data.Entity;

namespace WPF_HW1.Model
{
    /// <summary>
    /// Клас управляє об'єктами сутностей, тобто заповнює об'єкти з даними з БД, відстежує зміни та зберігає дані в БД
    /// </summary>
    class MyContext : DbContext
    {

        public MyContext()
            : base("SanyaConnection")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<MyContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyContext, DBConfig>("SanyaConnection"));
        }

        /// <summary>
        /// Колекції вказаних об'єктів в контексті
        /// </summary>
        public DbSet<User> Users { get; set; }
        public DbSet<TimeClock> TimeClocks { get; set; }

       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new User.UserEntityConfiguration());
            modelBuilder.Configurations.Add(new TimeClock.TimeClockConfiguration());
        }
    }
}
