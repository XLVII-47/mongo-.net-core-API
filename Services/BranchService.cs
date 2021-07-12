using BranchsApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace BranchsApi.Services
{
    public class BranchService
    {
        private readonly IMongoCollection<Branch> _branchs;

        public BranchService(IBranchDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _branchs = database.GetCollection<Branch>(settings.BranchCollectionName);
        }

        public List<Branch> Get() =>
            _branchs.Find(branch => true).ToList();

        
        public Branch Get(int id) =>
            _branchs.Find<Branch>(branch => branch.id == id).FirstOrDefault();
        
        public Branch Create(Branch branch)
        {
            _branchs.InsertOne(branch);
            return branch;
        }
        
        public void Update(int id, Branch branchIn) =>
            _branchs.ReplaceOne(branch => branch.id == id, branchIn);

        public void Remove(Branch branchIn) =>
            _branchs.DeleteOne(branch => branch.id == branchIn.id);

        public void Remove(int id) =>
            _branchs.DeleteOne(branch => branch.id == id);
        
    }
}