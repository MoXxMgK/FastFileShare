using Microsoft.EntityFrameworkCore;

using FileShareApi.DataModels;

namespace FileShareApi.Data
{
    public class FileDataBaseContext : DbContext
    {
        public DbSet<DataBaseFileInfo> Files { get; set; }

        public FileDataBaseContext(DbContextOptions<FileDataBaseContext> options) : base (options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetConnectionString("FilesDataBase");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DataBaseFileInfo>().ToTable("Files");
        }

        public async Task<DataBaseFileInfo?> CheckFile(string fileHash)
        {
            return await Files.FirstOrDefaultAsync(f => f.FileHash == fileHash);
        }

        public async Task<DataBaseFileInfo?> GetFile(string accessString)
        {
            return await Files.FirstOrDefaultAsync(f => f.AccessString == accessString);
        }

        public async Task<IEnumerable<DataBaseFileInfo>> GetAllPublicFiles()
        {
            IEnumerable<DataBaseFileInfo> files = Files.Where(f => f.PublicFile).ToList();
            return await Task.FromResult(files);
        }
    }
}
