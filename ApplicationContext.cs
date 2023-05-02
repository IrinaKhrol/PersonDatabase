using Microsoft.EntityFrameworkCore;

namespace PersonDatabase
{
    public class ApplicationContext : DbContext
    {
        private static ApplicationContext? _instance;
        public DbSet<Person> Persons { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Address> Addresses { get; set; }

        readonly StreamWriter sw = new(@"C:\Users\Irina\Documents\Log.txt", true);
        private ApplicationContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public static ApplicationContext GetApplicationContext() 
        {
            _instance??= new ApplicationContext();
            return _instance;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=helloappdb;Trusted_Connection=True;Encrypt=False;");
            optionsBuilder.LogTo(sw.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfiguration(new PersonConfigurations());
        }
    }
}
