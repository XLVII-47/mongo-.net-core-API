using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BranchsApi.Models
{   
    public class Properties
    {

    }
     public class Geometry
    {
        public string type { get; set; }

        public List<List<List<List<double>>>> coordinates { get; set; }

    }

    public class Layer
    {
        public string type { get; set; }
        public Properties properties { get; set; }
        public Geometry geometry { get; set; }
    }

    public class extendLayer
    {   
        public ObjectId id { get; set; }
        public int BranchId { get; set; }

        public string LayerName { get; set; }

        public Geometry Geo { get; set; }
    }
}
