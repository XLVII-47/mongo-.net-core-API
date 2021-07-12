using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BranchsApi.Models
{    
    

    public class Coordinate
    {
        public int lat { get; set; }
        public int lng { get; set; }
    }

    public class Branch
    {
     
        [BsonElement("Name")]
        public string branchName { get; set; }

        public int id { get; set; }

        public Coordinate coordinate { get; set; }

    }
}