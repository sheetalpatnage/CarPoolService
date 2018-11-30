using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using MongoDB.Driver.Builders;



namespace CarPoolService.Models
{
    public class DataAccess
    {
        MongoClient _client;
        MongoServer _server;
        MongoDatabase _db;

        public DataAccess()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _server = _client.GetServer();
            _db = _server.GetDatabase("CarPoolDB");
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _db.GetCollection<Employee>("Employee").FindAll();
        }

        public Employee GetEmployee(ObjectId id)
        {
            var res = Query<Employee>.EQ(Emp => Emp.Id, id);
            return _db.GetCollection<Employee>("Employee").FindOne(res);
        }
        public void AddEmployee(Employee Emp)
        {
            _db.GetCollection<Employee>("Employee").Save(Emp);
        }

        public void UpdateEmployee(ObjectId id, Employee Emp)
        {
            Emp.Id = id;
            var res = Query<Employee>.EQ(p => p.Id, id);
            var oper = Update<Employee>.Replace(Emp);
            _db.GetCollection<Employee>("Employee").Update(res, oper);
        }
    }
}