namespace BranchsApi.Models
{
    public class BranchDatabaseSettings : IBranchDatabaseSettings
    {
        public string BranchCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IBranchDatabaseSettings
    {
        string BranchCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}