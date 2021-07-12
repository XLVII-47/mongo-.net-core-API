using BranchsApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System;
namespace BranchsApi.Services
{
 
      
    public class LayerService
    {

        private readonly IMongoCollection<extendLayer> _layers;

        public LayerService(ILayerDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            Console.WriteLine(settings.DatabaseName);
            _layers = database.GetCollection<extendLayer>(settings.LayerCollectionName);
        }
        public List<extendLayer> Get() =>
            _layers.Find(layer => true).ToList();

        public List<extendLayer> Get(int idl) =>
            _layers.Find(layer => layer.BranchId == idl).ToList();

        public extendLayer Create(extendLayer layer)
        {
            
                _layers.InsertOne(layer);
            

            return layer;
        }


    }
}
