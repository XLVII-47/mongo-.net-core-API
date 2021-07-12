
namespace BranchsApi.Models
{
    public class LayerDatabaseSettings : ILayerDatabaseSettings
    {
        public string LayerCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ILayerDatabaseSettings
    {
        string LayerCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
