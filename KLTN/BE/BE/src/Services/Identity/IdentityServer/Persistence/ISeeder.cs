namespace IdentityServer.Persistence
{
    public interface ISeeder
    {
        void SeedData(IdentityDbContext dbContext);
    }
}
