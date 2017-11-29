using System.Data.Entity.Migrations;


namespace WPF_HW1.Model
{/// <summary>
/// Конфігурація, пов'язана з використанням міграції для даної моделі
/// </summary>
    internal sealed class DBConfig : DbMigrationsConfiguration<MyContext>
    {
        public DBConfig()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "WPF_HW1.MyContext";
        }

        protected override void Seed(MyContext context)
        {
            
        }
    }
   
}
